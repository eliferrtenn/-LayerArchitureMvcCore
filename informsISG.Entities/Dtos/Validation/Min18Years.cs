using InformsISG.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InformsISG.Entities.Dtos.Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class Min18Years : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var student = (KullaniciDTO)validationContext.ObjectInstance;

            if (!Regex.IsMatch(student.Password, "[A-Z]"))
                return new ValidationResult("Hatalı yazılım.");

            return ValidationResult.Success;

        }
    }
}
