using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Validations
{
    public class ContentTypeValidetor:ValidationAttribute
    {
        private readonly string[] _validetype;
        private readonly string[] imgtype = new string[] { "img/jpeg", "img/png", "img/gif" };
        public ContentTypeValidetor(string[] validtype)
        {
            _validetype = validtype;
        }

        public ContentTypeValidetor(contenttype contenttype)
        {
            switch (contenttype)
            {
                case contenttype.Image:
                    _validetype = imgtype;
                    break;
            }
        }
        public enum contenttype
        {
            Image
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            IFormFile fromfile = (IFormFile)value;

            if (fromfile == null)
            {
                return ValidationResult.Success;
            }

            if (!_validetype.Contains(fromfile.ContentType))
            {
                return new ValidationResult($"content:type should be on of the following:{string.Join(", ",_validetype)}");
            }
            return ValidationResult.Success;
        }
    }
}
