using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicketBooking.UI.Validations
{
	public class FirstLetterUpperCaseAttribute : ValidationAttribute
	{
		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			if (value != null)
			{
				string textBoxValue = value.ToString();
				if (!string.IsNullOrEmpty(textBoxValue))
				{
					char firstChar = textBoxValue[0];
					if (char.IsUpper(firstChar))
					{
						return ValidationResult.Success;
					}
				}
			}
			return new ValidationResult(ErrorMessage ?? "The First Letter must be UpperCase");
		}
	}
}
