using System.ComponentModel;

namespace LoaningBank.CrossCutting.Enums
{
    public static class EnumExtension
    {
        public static string GetEnumDescription<T>(this T value) where T : Enum
        {
            var enumType = value.GetType();
            var fieldName = Enum.GetName(enumType, value);

            if (string.IsNullOrEmpty(fieldName))
            {
                return string.Empty;
            }

            return enumType.GetField(fieldName)?.GetCustomAttributes(false).OfType<DescriptionAttribute>().SingleOrDefault()?.Description ?? string.Empty;
        }
    }
}
