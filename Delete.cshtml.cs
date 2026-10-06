using MicroBlog.Models;
using MicroBlog.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MicroBlog.Pages
{
	public class DeleteModel : PageModel
	{
		private readonly IBlogRepository _repository;

		[BindProperty]
		public Post? Post { get; set; }

		public DeleteModel(IBlogRepository repository)
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
			if (Post == null)
			{
				return NotFound();
			}

			_repository.Delete(Post.Id);

			return RedirectToPage("/Index");
		}
	}
}