using System;
using System.ComponentModel.DataAnnotations;

public class MinAgeAttribute : ValidationAttribute
{
    private readonly int _minAge;

    public MinAgeAttribute(int minAge)
    {
        _minAge = minAge;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return new ValidationResult("La fecha de nacimiento es obligatoria.");
        }

        var dateOfBirth = (DateTime)value;
        var currentDate = DateTime.Today;

        int age = currentDate.Year - dateOfBirth.Year;

        // Restar un año si no ha cumplido los años todavía este año
        if (dateOfBirth.Date > currentDate.AddYears(-age))
        {
            age--;
        }

        if (age < _minAge)
        {
            return new ValidationResult($"Debes tener al menos {_minAge} años.");
        }

        return ValidationResult.Success;
    }
}
