using System;

namespace Snip.BP.Validation
{
    /// <summary>
    /// La clase EnumNotNoneAttribute le permite asegurarse que un elemento de enumeración no tiene el valor NoDefinido (== 0).
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class EnumNotNoneAttribute : ValidationAttribute
    {
        public EnumNotNoneAttribute()
        {
        }

        public override bool IsValid(object item)
        {
            if (item.GetType().BaseType != typeof(System.Enum)) return false;
            return (int)item != 0;
        }
    }
}
