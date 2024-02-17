using System.ComponentModel.DataAnnotations;

namespace Mission6_0108_ReedStewart.Models
{
    public class Application
    {
        [Key]
        [Required]
        public int ApplicationID { get; set; }
        [Required(ErrorMessage = "Category is Required")] //Trying to handle errors
        public string Category { get; set; }
        [Required(ErrorMessage = "Title is Required")]
        public string Title {  get; set; }
        [Required(ErrorMessage = "Year is Required")]
        public string Year { get; set; }
        [Required(ErrorMessage = "Director is Required")]
        public string Director {  get; set; }
        [Required(ErrorMessage = "Rating is Required")]
        public string Rating {  get; set; }
        public bool Edited {  get; set; }
        public string LentTo {  get; set; }
        [MaxLength(25)] //Limit notes to 25 characters
        public string Notes {  get; set; }
    }
}
