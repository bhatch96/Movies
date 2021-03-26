using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Models
{
    public class Movie
    {
        [Required]
        [Key]
        public int MovieID { get; set; }

        [Required(ErrorMessage = "Please enter a category")]
        public string Category { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Range(1900, 2022)]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        [Required]
        public bool Edited { get; set; }

        public string LentTo { get; set; }

        [MaxLength(25)]
        public string Notes { get; set; }
    }
}
