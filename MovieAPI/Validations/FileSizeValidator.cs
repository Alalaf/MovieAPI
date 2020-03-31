using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Validations
{
    public class FileSizeValidator: ValidationAttribute
    {
        private readonly int _maxsize;

        public FileSizeValidator(int maxsize)
        {
            _maxsize = maxsize;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            IFormFile formfile = (IFormFile)value;

            if(formfile == null)
            {
                return ValidationResult.Success;
            }

            if (formfile.Length > _maxsize * 1024 * 1024)
            {
                return new ValidationResult($"file size cannot be bigger than {_maxsize} megabites");
            }
            return ValidationResult.Success;
        }
    }
}
