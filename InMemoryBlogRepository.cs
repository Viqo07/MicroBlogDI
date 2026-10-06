using MicroBlog.Models;

namespace MicroBlog.Services
{
	public class InMemoryBlogRepository : IBlogRepository
	{
		private readonly List<Post> _posts = new();

		public IEnumerable<Post> GetAll()
		{
			return _posts;
		}

		public Post? GetById(int id)
		{
			return _posts.FirstOrDefault(p => p.Id == id);
		}

		public void Add(Post post)
		{
			if (post.Id == 0)
			{
				post.Id = _posts.Count == 0
					? 1
					: _posts.Max(p => p.Id) + 1;
			}

			_posts.Add(post);
		}

		public void Save()
		{
			// Nothing to save because this repository uses memory.
		}

		public bool Update(Post post)
		{
			var existingPost = _posts.FirstOrDefault(p => p.Id == post.Id);

			if (existingPost == null)
			{
				return false;
			}

			existingPost.Title = post.Title;
			existingPost.Body = post.Body;

			return true;
		}

		public void Delete(int id)
		{
			var post = _posts.FirstOrDefault(p => p.Id == id);

			if (post != null)
			{
				_posts.Remove(post);
			}
		}
	}
}
