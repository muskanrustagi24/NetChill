using System;
using System.ComponentModel.DataAnnotations;

namespace NetChill.Backend.Domain
{
    public class MovieList
    {
        [Key]
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set;}
        public User User { get; set;}
        public Guid UserId { get; set; }
        public Movie Movie { get; set; }
        public Guid MovieId { get; set; }
    }
}
