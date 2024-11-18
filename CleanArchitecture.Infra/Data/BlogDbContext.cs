using CleanArchitecture.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infra.Data;

public class BlogDbContext: DbContext
{
    public BlogDbContext(DbContextOptions<BlogDbContext> dbContextOptions)
        :base(dbContextOptions){ }

    public DbSet<Blog> Blogs { get; set; }
}
