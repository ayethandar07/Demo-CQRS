using CleanArchitecture.Domain.Entity;
using CleanArchitecture.Domain.Repositoty;
using CleanArchitecture.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infra.Repository;

public class BlogRepository : IBlogRepository
{
    private readonly BlogDbContext _dbContext;

    public BlogRepository(BlogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Blog> CreateBlogAsync(Blog blog)
    {
        await _dbContext.Blogs.AddAsync(blog);
        await _dbContext.SaveChangesAsync();
        return blog;
    }

    public async Task<int> DeleteAsync(int id)
    {
        return await _dbContext.Blogs
            .Where(b => b.Id == id)
            .ExecuteDeleteAsync();
    }

    public async Task<List<Blog>> GetAllBlogsAsync()
    {
        return await _dbContext.Blogs .ToListAsync();
    }

    public async Task<Blog> GetByIdAsync(int id)
    {
        return await _dbContext.Blogs.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task<int> UpdateAsync(int id, Blog blog)
    {
        return await _dbContext.Blogs
             .Where(b => b.Id == id)
             .ExecuteUpdateAsync(setters => setters
             .SetProperty(m => m.Id, blog.Id)
             .SetProperty(m => m.Name, blog.Name)
             .SetProperty(m => m.Description, blog.Description)
             .SetProperty(m => m.Author, blog.Author));
    }
}
