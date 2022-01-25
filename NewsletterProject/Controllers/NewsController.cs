using Microsoft.AspNetCore.Mvc;
using NewsletterProject.DbOperations;
using NewsletterProject.Models;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewsletterProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly NewsletterDbContext _context;

        public NewsController(NewsletterDbContext context)
        {
            _context = context;
        }
        // GET: api/<NewsController>
        [HttpGet]
        public IActionResult Get()
        {
            var newsList = _context.News.OrderBy(x => x.NewsId).ToList<News>();
            if (newsList is not null)
                return Ok(newsList);

            return BadRequest();
        }

        // GET api/<NewsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int newsId)
        {
            var news = _context.News.SingleOrDefault(x => x.NewsId == newsId);

            if (news is not null)
                return Ok(news);

            return BadRequest();

        }


        // POST api/values
        //this method will insert the new data
        [HttpPost]
        public IActionResult Post([FromBody] News _news)
        {
            var news = _context.News.SingleOrDefault(x => x.Title == _news.Title);

            if (news is not null)
                return BadRequest();

            _context.News.Add(_news);
            _context.SaveChanges();
            return Ok();
        }

        // PUT api/values/5
        //this method will update the data selected with id
        [HttpPut("{id}")]
        public IActionResult Put(int newsId, [FromQuery] News _news)
        {
            var news = _context.News.SingleOrDefault(x => x.NewsId == newsId);

            if (news is null)
                return BadRequest();

            news.Title = _news.Title != default ? _news.Title : news.Title;
            news.Content = _news.Content != default ? _news.Content : news.Content;
            news.Title = _news.Title != default ? _news.Title : news.Title;
            news.PhotoUrl = _news.PhotoUrl != default ? _news.PhotoUrl : news.PhotoUrl;
            news.VideoUrl = _news.VideoUrl != default ? _news.VideoUrl : news.VideoUrl;
            news.Status = _news.Status != default ? _news.Status : news.Status;
            _context.SaveChanges();
            return Ok();
        }

        // DELETE api/values/5
        //this method will delete the data selected with id
        [HttpDelete("{id}")]
        public IActionResult Delete(int newsId)
        {
            var news = _context.News.SingleOrDefault(x => x.NewsId == newsId);

            if (news is null)
                return BadRequest();

            _context.News.Remove(news);
            _context.SaveChanges();
            return Ok();
        }
    }
}
