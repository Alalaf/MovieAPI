using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.DTOs
{
    public class PersonDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public String Biography { get; set; }
        public DateTime BirthDate { get; set; }
        public String Picture { get; set; }

    }
}
