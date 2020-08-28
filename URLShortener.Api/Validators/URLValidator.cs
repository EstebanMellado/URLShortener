using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace URLShortener.Api.Validators
{
    public class URLValidator
    {
        public sealed class CheckUrlValid : ValidationAttribute
        {
            protected override ValidationResult IsValid(object url, ValidationContext validationContext)
            {
                Uri _uri;
                bool result = Uri.TryCreate(url.ToString(), UriKind.Absolute, out _uri)
                    && (_uri.Scheme == Uri.UriSchemeHttp || _uri.Scheme == Uri.UriSchemeHttps);

                return result ? ValidationResult.Success : new ValidationResult("Url no valida");
            }
        }
    }
}
