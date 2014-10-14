using System;
using System.Reflection;
using System.Linq;
using System.Text;

namespace Snip.BP.Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple=false)]
    public class BaseAttribute : Attribute
    {
        public string ErrorMessage { get; set; }

        internal virtual string IsValid(PropertyInfo propiedad, object objeto)
        {
            return ErrorMessage;
        }
    }
}
