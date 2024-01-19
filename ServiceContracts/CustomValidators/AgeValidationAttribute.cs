using System.ComponentModel.DataAnnotations;


namespace ServiceContracts.CustomValidators
{
    public class AgeValidationAttribute:ValidationAttribute
    {
        private readonly DateTime _validAge;
        public AgeValidationAttribute(string validAge)
        {
            _validAge = Convert.ToDateTime(validAge);
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Age can't be blank");
            }
            if (Convert.ToDateTime(value).Year < _validAge.Year)
            {
                return new ValidationResult("Should not be older than 24!");
            }
            return ValidationResult.Success;
        }
    }
}
