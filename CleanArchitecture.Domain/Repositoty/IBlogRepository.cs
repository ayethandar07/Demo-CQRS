using CleanArchitecture.Domain.Entity;

namespace CleanArchitecture.Domain.Repositoty;

public interface IBlogRepository
{
    Task<List<Blog>> GetAllBlogsAsync();

    Task<Blog> GetByIdAsync(int id);

    Task<Blog> CreateBlogAsync(Blog blog);

    Task<int> UpdateAsync(int id, Blog blog);

    Task<int> DeleteAsync(int id);
}
