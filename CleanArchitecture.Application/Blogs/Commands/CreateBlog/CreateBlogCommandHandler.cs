using AutoMapper;
using CleanArchitecture.Application.Blogs.Queries.GetBlogs;
using CleanArchitecture.Domain.Entity;
using CleanArchitecture.Domain.Repositoty;
using MediatR;

namespace CleanArchitecture.Application.Blogs.Commands.CreateBlog;

public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, BlogVm>
{
    private readonly IBlogRepository _blogRepository;
    private readonly IMapper _mapper;

    public CreateBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper)
    {
        _blogRepository = blogRepository;
        _mapper = mapper;
    }

    public async Task<BlogVm> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
    {
        var blogEntity = new Blog() { Name = request.Name, Author = request.Author, Description = request.Description };

        var res = await _blogRepository.CreateBlogAsync(blogEntity);
        return _mapper.Map<BlogVm>(res);
    }
}
