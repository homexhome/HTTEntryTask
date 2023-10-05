using JoinedEntityTableTask.Data;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace JoinedEntityTableTask.Models
{
    public class ValidProductNameAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext) {
            var context = validationContext.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext ??
                throw new ArgumentNullException();
            if (!context.Products.Any(a => a.ProductName == value.ToString())){
                return ValidationResult.Success;
            }
            return new ValidationResult("Product Name already exists");
        }
    }
}
