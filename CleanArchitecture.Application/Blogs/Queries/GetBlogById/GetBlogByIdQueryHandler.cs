using AutoMapper;
using CleanArchitecture.Application.Blogs.Queries.GetBlogs;
using CleanArchitecture.Domain.Repositoty;
using MediatR;

namespace CleanArchitecture.Application.Blogs.Queries.GetBlogById;

public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, BlogVm>
{
    private readonly IBlogRepository _blogRepository;
    private readonly IMapper _mapper;

    public GetBlogByIdQueryHandler(IBlogRepository blogRepository, IMapper mapper)
    {
        _blogRepository = blogRepository;
        _mapper = mapper;
    }

    public async Task<BlogVm> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
    {
        var blog = await _blogRepository.GetByIdAsync(request.BlogId);
        return _mapper.Map<BlogVm>(blog);
    }
}
