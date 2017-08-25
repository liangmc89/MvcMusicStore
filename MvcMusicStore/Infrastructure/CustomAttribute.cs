using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcMusicStore.Infrastructure
{
    public class MaxWordsAttribute : ValidationAttribute
    {
        private readonly int _maxWords;
        public MaxWordsAttribute(int MaxWords):base("{0} has too many words!")
        {
            _maxWords = MaxWords;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value!=null)
            {
                var valueAsString = value.ToString();
                if (valueAsString.Split(' ').Length>_maxWords)
                {
                    var errMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errMessage);
                }
            }
           return  ValidationResult.Success;
        }
    }
}