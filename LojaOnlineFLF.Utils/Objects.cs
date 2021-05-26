using System;

namespace LojaOnlineFLF.Utils
{
    public static class Objects
    {
        public static void CheckArgumentNonNull(object nonNull, string paramName, string message = null)
        {
            if (nonNull is null)
            {
                throw new ArgumentNullException(paramName, message);
            }
        }
    }
}
