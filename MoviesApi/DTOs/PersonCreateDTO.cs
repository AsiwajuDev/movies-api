using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApi.DTOs
{
    public class PersonCreateDTO
    {
        [Required]
        [StringLength(120)]
        public string Name { get; set; }
        public string Biograpghy { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
