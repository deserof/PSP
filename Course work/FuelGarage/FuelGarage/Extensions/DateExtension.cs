using System;
using System.Globalization;

namespace FuelGarage.Extensions
{
    public static class DateExtension
    {
        public static string ToNormalDate(this DateTime text)
        {
            return text.ToString("dd MMMM, yyyy", new CultureInfo("ru-Ru"));
        }

        public static string ToNormalDateTime(this DateTime text)
        {
            return text.ToString("dd MMMM, yyyy. HH:mm", new CultureInfo("ru-Ru"));
        }
    }
}
