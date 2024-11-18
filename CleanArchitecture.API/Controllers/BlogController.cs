using CleanArchitecture.Application.Blogs.Commands.CreateBlog;
using CleanArchitecture.Application.Blogs.Commands.UpdateBlog;
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
    public async Task<IActionResult> GetAll()
    {
        var blogs = await Mediator.Send(new GetBlogQuery());
        return Ok(blogs);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var blog = await Mediator.Send(new GetBlogByIdQuery() { BlogId = id});
        if(blog == null)
        {
            return NotFound();
        }
        return Ok(blog);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBlogCommand command)
    {
        var createdBlog = await Mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = createdBlog.Id }, createdBlog);
    }

    [HttpPut]
    public async Task<IActionResult> Update(int id, UpdateBlogCommand command)
    {
        if( id != command.Id )
        {
            return BadRequest();
        }

        await Mediator.Send(command);
        return NoContent();
    }
}
