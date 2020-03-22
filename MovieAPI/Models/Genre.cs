using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name Is Required")]
        public string Name { get; set; }
    }
}
