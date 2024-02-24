using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6_0108_ReedStewart.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        [Required(ErrorMessage = "Title is Required")]
        public required string Title {  get; set; }
        [Range(1888, int.MaxValue, ErrorMessage = "You must enter a year above 1888")]
        public required int Year { get; set; }
        public string? Director {  get; set; }
        public string? Rating {  get; set; }
        [Required(ErrorMessage = "Edited is Required")]
        public required int Edited {  get; set; }
        public string? LentTo {  get; set; }
        [Required(ErrorMessage = "Copied to Plex is Required")]
        public required int CopiedToPlex { get; set; }
        [MaxLength(25)] //Limit notes to 25 characters
        public string? Notes {  get; set; }
    }
}
