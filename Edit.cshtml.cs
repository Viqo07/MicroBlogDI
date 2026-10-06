using MicroBlog.Models;
using MicroBlog.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MicroBlog.Pages
{
	public class EditModel : PageModel
	{
		private readonly IBlogRepository _repository;

		[BindProperty]
		public Post? Post { get; set; }

		public EditModel(IBlogRepository repository)
		{
			_repository = repository;
		}

		public IActionResult OnGet(int id)
		{
			Post = _repository.GetById(id);

			if (Post == null)
			{
				return NotFound();
			}

			return Page();
		}

		public IActionResult OnPost()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			if (Post == null)
			{
				return NotFound();
			}

			bool updated = _repository.Update(Post);

			if (!updated)
			{
				return NotFound();
			}

			return RedirectToPage("/Details", new { id = Post.Id });
		}
	}
}