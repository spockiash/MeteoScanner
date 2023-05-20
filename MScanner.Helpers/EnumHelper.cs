using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MScanner.Helpers
{
    public static class EnumHelper
    {
        public static Dictionary<int, string> ToDictionary(Type enumType)
        {
            if (!enumType.IsEnum)
            {
                throw new ArgumentException("Type must be an enum");
            }

            return Enum.GetValues(enumType)
                .Cast<int>()
                .ToDictionary(t => t, t => Enum.GetName(enumType, t) ?? "Undefined");
        }
    }
}
