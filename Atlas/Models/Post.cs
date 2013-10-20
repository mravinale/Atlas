
using System.ComponentModel.DataAnnotations;

namespace Atlas.Models
{
    public class Post
    {
        [Key]
        public int id { get; set; }
        public string type { get; set; }
        public string content { get; set; }
        public string title { get; set; }
    }     
     
}