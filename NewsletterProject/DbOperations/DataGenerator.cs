using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NewsletterProject.Models;
using System;
using System.Linq;

namespace NewsletterProject.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new NewsletterDbContext(serviceProvider.GetRequiredService<DbContextOptions<NewsletterDbContext>>()))
            {
                if (context.News.Any())
                    return;

                context.News.AddRange(new News()
                {
                    //NewsId = 1,
                    Title = "Haber baslık1",
                    Content = "Haber context1",
                    CreatedDate = DateTime.Now,
                    PhotoUrl = "url",
                    VideoUrl = "url"
                },
                new News()
                {
                    //NewsId = 2,
                    Title = "Haber baslık2",
                    Content = "Haber context2",
                    CreatedDate = DateTime.Now,
                    PhotoUrl = "url",
                    VideoUrl = "url"
                });

                context.SaveChanges();


            }
        }
    }
}
