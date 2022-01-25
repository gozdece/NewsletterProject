using Microsoft.EntityFrameworkCore;
using NewsletterProject.Models;

namespace NewsletterProject.DbOperations
{
    public class NewsletterDbContext:DbContext
    {
        public NewsletterDbContext(DbContextOptions<NewsletterDbContext> option) : base(option)
        { }

        public DbSet<News> News { get; set; }

    }
}
