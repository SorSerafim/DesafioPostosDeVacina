using System;
using System.ComponentModel.DataAnnotations;

public class FutureDateAttribute : ValidationAttribute
{
    public FutureDateAttribute()
    {
        ErrorMessage = "A data de validade deve ser uma data futura.";
    }

    public override bool IsValid(object value)
    {
        if (value == null)
        {
            return true; // Not our responsibility to check for required field
        }

        var dateValue = (DateTime)value;
        return dateValue > DateTime.Now;
    }
}