using System.Text.Json;
using MicroBlog.Models;

namespace MicroBlog.Services
{
	public class JsonBlogRepository : IBlogRepository
	{
		private readonly string _filePath;
		private readonly List<Post> _posts;

		public JsonBlogRepository()
		{
			_filePath = Path.Combine(
				Directory.GetCurrentDirectory(),
				"data",
				"posts.json"
			);

			Directory.CreateDirectory(
				Path.GetDirectoryName(_filePath)!
			);

			if (File.Exists(_filePath))
			{
				var json = File.ReadAllText(_filePath);

				_posts = string.IsNullOrWhiteSpace(json)
					? new List<Post>()
					: JsonSerializer.Deserialize<List<Post>>(json)
					  ?? new List<Post>();
			}
			else
			{
				_posts = new List<Post>();
			}
		}

		public IEnumerable<Post> GetAll()
		{
			return _posts;
		}

		public Post GetById(int id)
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
			Save();
		}

		public void Save()
		{
			var json = JsonSerializer.Serialize(
				_posts,
				new JsonSerializerOptions
				{
					WriteIndented = true
				}
			);

			File.WriteAllText(_filePath, json);
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

			Save();

			return true;
		}

		public void Delete(int id)
		{
			var post = _posts.FirstOrDefault(p => p.Id == id);

			if (post != null)
			{
				_posts.Remove(post);
				Save();
			}
		}
	}
}