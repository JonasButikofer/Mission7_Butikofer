using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6Movies.Models
{
    public class FormModel
    {
        [Key]
        public int MovieId { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }

        public Category? Category { get; set; }

        public string? Notes { get; set; }

        public string? LentTo { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; } = string.Empty;

        // Edited should be either 0 or 1. This range ensures that.
        [Range(0, 1, ErrorMessage = "Edited must be either 0 (No) or 1 (Yes).")]
        public int Edited { get; set; }

        public string? Rating { get; set; }

        public string? Director { get; set; }

        [Required(ErrorMessage = "Copied to Plex field is required.")]
        public int CopiedToPlex { get; set; }

        [Required(ErrorMessage = "Year is required.")]
        [Range(1888, 2100, ErrorMessage = "Year must be no less than 1888.")]
        public int Year { get; set; }
    }
}
