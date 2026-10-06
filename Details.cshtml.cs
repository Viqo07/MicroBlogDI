using MicroBlog.Models;
using MicroBlog.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MicroBlog.Pages
{
	public class DetailsModel : PageModel
	{
		private readonly IBlogRepository _repository;

		public Post? Post { get; set; }

		public DetailsModel(IBlogRepository repository)
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
	}
}