using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsletterProject.Models
{
    public class News
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NewsId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public string PhotoUrl { get; set; }
        public string VideoUrl { get; set; }
        public bool Status { get; set; }
       // public Comment Comments { get; set; }
        //public Category Categories { get; set; }
    }
}
