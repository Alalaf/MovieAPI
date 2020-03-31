using Microsoft.AspNetCore.Http;
using MovieAPI.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static MovieAPI.Validations.ContentTypeValidetor;

namespace MovieAPI.Helpers
{
    public class PersonCreationDTO
    {  
        [Required]
        public string Name { get; set; }
        public String Biography { get; set; }
        public DateTime BirthDate { get; set; }
        [FileSizeValidator(4)]
        [ContentTypeValidetor(contenttype.Image)]
        public IFormFile Picture { get; set; }
    }
}
