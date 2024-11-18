using CleanArchitecture.Application.Blogs.Queries.GetBlogs;
using MediatR;

namespace CleanArchitecture.Application.Blogs.Queries.GetBlogById;

public class GetBlogByIdQuery: IRequest<BlogVm>
{
    public int BlogId { get; set; }
}
