using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigSQLRunnerUI
{
    public static class Extensions
    {
        public static double ToDouble(this long input)
        {
            double ret = Convert.ToDouble(input);
            return ret;
        }

        public static double ToDouble(this short input)
        {
            double ret = Convert.ToDouble(input);
            return ret;
        }

        public static int ToInt(this double input)
        {
            int ret = Convert.ToInt32(input);
            return ret;
        }

        public static string ToReadableString(this TimeSpan span)
        {
            string formatted = string.Format("{0}{1}{2}{3}",
                span.Duration().Days > 0 ? string.Format("{0:0} day{1}, ", span.Days, span.Days == 1 ? String.Empty : "s") : string.Empty,
                span.Duration().Hours > 0 ? string.Format("{0:0} hour{1}, ", span.Hours, span.Hours == 1 ? String.Empty : "s") : string.Empty,
                span.Duration().Minutes > 0 ? string.Format("{0:0} minute{1}, ", span.Minutes, span.Minutes == 1 ? String.Empty : "s") : string.Empty,
                span.Duration().Seconds > 0 ? string.Format("{0:0} second{1}", span.Seconds, span.Seconds == 1 ? String.Empty : "s") : string.Empty);

            if (formatted.EndsWith(", ")) formatted = formatted.Substring(0, formatted.Length - 2);

            if (string.IsNullOrEmpty(formatted)) formatted = "0 seconds";

            return formatted;
        }

        public static string ToReadableShortString(this TimeSpan span)
        {
            string formatted = string.Format("{0}{1}{2}{3}",
                span.Duration().Days > 0 ? string.Format("{0:0}d ", span.Days) : string.Empty,
                span.Duration().Hours > 0 ? string.Format("{0:0}h ", span.Hours) : string.Empty,
                span.Duration().Minutes > 0 ? string.Format("{0:0}m ", span.Minutes) : string.Empty,
                span.Duration().Seconds > 0 ? string.Format("{0:0}s", span.Seconds) : string.Empty);


            if (string.IsNullOrEmpty(formatted)) formatted = "0 s";

            return formatted;
        }
    }

}
