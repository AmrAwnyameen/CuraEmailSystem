using Elmah;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Infrastructure.Helpers.CustomAttributes
{
    public class GreenHouseRequiredSlugs : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                var dictionary = new Dictionary<string, string>();
                dictionary.Add("GreenHouseNumber", "3028");
                var slugName = HttpContext.Current.Request.Headers.Get("ServiceSlug");
                if (!string.IsNullOrEmpty(slugName) && (value is int || value == null))
                {
                    if (new List<string>() { "MALR-08","MALR-09","MALR-19","MALR-20"}.Any(s => s.Equals(slugName) && (value is null || (int)value == 0)))
                        return new ValidationResult(dictionary["GreenHouseNumber"]);
                }
                return ValidationResult.Success;

            }
            catch (Exception ex)
            {
                Elmah.ErrorLog.GetDefault(null).Log(new Error(ex));
                return new ValidationResult(Infrastructure.Resources.Validations.Arabic.Ar_Responses.Error);
            }
        }
    }
}
