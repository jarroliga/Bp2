using System;

namespace Snip.BP.Validation
{
    /// <summary>
    /// La clase NotNullOrEmptyAttribute le permite asegurarse que el valor de una cadena de texto no es nula o vacía.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class NotNullOrEmptyAttribute : ValidationAttribute
    {
        public override bool IsValid(object item)
        {
            if (item is string)
            {
                return !string.IsNullOrEmpty(item as string);
            }
            return item != null;
        }
    }
}
