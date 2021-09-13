using System;
using System.ComponentModel.DataAnnotations;

namespace NetChill.Backend.Domain
{
    public class Movie
    {
        [Key]
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required, MaxLength(255, ErrorMessage = "Not more than 255 characters.")]
        public string Name { get; set; }

        [Required, MaxLength(255, ErrorMessage = "Not more than 255 characters.")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Year must be in YYYY format.")]
        public int YearOfRelease { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public DateTime AvailabilityStarts { get; set; }

        [Required, MaxLength(8000, ErrorMessage = "Not more than 8000 characters.")]
        public string Description { get; set; }

        [Required]
        public bool IsFeatured { get; set; }

        [Required(ErrorMessage = "JPG or PNG format only.")]
        public string PosterPath { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public string ContentPath { get; set; }
    }
}
