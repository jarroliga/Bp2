using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snip.BP.Validation
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class ValidDateRangeAttribute : ValidationAttribute
    {
        /// <summary>
        /// Gets or sets a value that determines the minimum value (inclusive) for the underlying value to be valid.
        /// </summary>
        /// <value>The minimum value.</value>
        public DateTime Min { get; set; }

        /// <summary>
        /// Gets or sets a value that determines the maximum value (inclusive) for the underlying value to be valid.
        /// </summary>
        /// <value>The maximum value.</value>
        public DateTime Max { get; set; }

        /// <summary>
        /// Determines whether the value of the underlying property falls between the Min and Max values.
        /// </summary>
        /// <param name="item">The underlying value of the propery that is being validated.</param>
        /// <returns>
        /// 	<c>true</c> if the specified item falls between Min and Max (inclusive); otherwise, <c>false</c>.
        /// </returns>
        public override bool IsValid(object item)
        {
            DateTime tempValue = Convert.ToDateTime(item);
            return tempValue.CompareTo(Min) >= 0 && tempValue.CompareTo(Max) <= 0;
        }
    }
}
