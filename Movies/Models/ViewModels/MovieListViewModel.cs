using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Models
{
    public class MovieListViewModel
    {
        public IEnumerable<Movie> Movies { get; set; }

        public int MovieID { get; set; }
    }
}
