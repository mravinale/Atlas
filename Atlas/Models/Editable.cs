
using System.ComponentModel.DataAnnotations;

namespace Atlas.Models
{
    public class Editable
    {
        [Key] 
        public int id { get; set; }
        public string type { get; set; }
        public string content { get; set; } 
    }     
     
}