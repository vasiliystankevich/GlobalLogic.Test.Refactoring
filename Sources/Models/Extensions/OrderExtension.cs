using System;

namespace GlobalLogic.Test.Refactoring.Models.Extensions
{
    public static class OrderExtension
    {
        public static int ToNumber(this Order sender, string input)
        {
            var canBeConverted = false;
            var n = 0;
            try
            {
                n = Convert.ToInt32(input);
                if (n != 0) canBeConverted = true;
            }
            catch
            {
                // ignored
            }

            return canBeConverted ? n : 0;
        }
    }
}
