using CleanArchitecture.Application.Blogs.Queries.GetBlogById;
using CleanArchitecture.Application.Blogs.Queries.GetBlogs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers;

[Route("api/blog")]
[ApiController]
public class BlogController : ApiControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var blogs = await Mediator.Send(new GetBlogQuery());
        return Ok(blogs);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var blog = await Mediator.Send(new GetBlogByIdQuery() { BlogId = id});
        if(blog == null)
        {
            return NotFound();
        }
        return Ok(blog);
    }
}
