using MicroBlog.Models;
using MicroBlog.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MicroBlog.Pages
{
	public class CreateModel : PageModel
	{
		private readonly IBlogRepository _repository;

		[BindProperty]
		public Post Post { get; set; } = new Post();

		public CreateModel(IBlogRepository repository)
		{
			_repository = repository;
		}

		public void OnGet()
		{
		}

		public IActionResult OnPost()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			_repository.Add(Post);

			return RedirectToPage("/Index");
		}
	}
}