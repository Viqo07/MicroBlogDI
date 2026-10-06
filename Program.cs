using MicroBlog.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

// Use the JSON repository.
// Change JsonBlogRepository to InMemoryBlogRepository to switch repositories.
builder.Services.AddSingleton<IBlogRepository, JsonBlogRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();