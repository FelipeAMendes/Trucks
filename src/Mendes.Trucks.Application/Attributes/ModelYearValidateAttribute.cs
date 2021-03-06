using System.ComponentModel.DataAnnotations;

namespace Mendes.Trucks.Application.Attributes
{
	public class ModelYearValidateAttribute : ValidationAttribute
	{
		public ModelYearValidateAttribute(string propName)
		{
			PropName = propName;
		}

		private string PropName { get; }

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var otherPropertyInfo = validationContext.ObjectType.GetProperty(PropName);
			if (otherPropertyInfo == null)
				return null;

			var otherPropertyValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null)?.ToString();
			if (otherPropertyValue is null)
				return null;

			int.TryParse(value.ToString(), out var thisYear);
			int.TryParse(otherPropertyValue, out var otherYear);

			return thisYear == otherYear || thisYear == otherYear + 1
				? null
				: new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
		}
	}
}
