using MoviesApi.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApi.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        [Required]
        [StringLength(40)]
        [FirstLetterUppercase]
        public string Name { get; set; }

    }
}
