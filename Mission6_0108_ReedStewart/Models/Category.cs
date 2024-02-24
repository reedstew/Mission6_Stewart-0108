using System.ComponentModel.DataAnnotations;

namespace Mission6_0108_ReedStewart.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
