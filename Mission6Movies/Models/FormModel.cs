using System.ComponentModel.DataAnnotations;

namespace Mission6Movies.Models
{
    public class FormModel
    {
        [Key] // Primary key
        public int Id { get; set; }

        [MaxLength(25)]
        public string? Notes { get; set; }

        [MaxLength(25)]
        public string? Lent { get; set; }

        [Required]
        public string MovieName { get; set; } = string.Empty; // Default empty to avoid CS8618

        public bool? Edited { get; set; }

        [Required]
        public string Rating { get; set; } = string.Empty; // Default empty to avoid CS8618
    }
}
