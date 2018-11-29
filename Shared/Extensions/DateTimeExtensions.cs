using System;
using System.Globalization;
using System.Text;
using System.Threading;

namespace Difi.Sjalvdeklaration.Shared.Extensions
{
    public static class DateTimeExtensions
    {
        private static readonly CultureInfo CultureInfo = new CultureInfo("no-NB");

        public static string GetAsFileName(this DateTime dateTime)
        {
            return GetAsFileName(dateTime, true);
        }

        public static string GetAsFileName(this DateTime dateTime, bool viewDelimiter)
        {
            var fileName = new StringBuilder();

            fileName.Append(AddZero(dateTime.Year) + AddZero(dateTime.Month) + AddZero(dateTime.Day));

            if (viewDelimiter)
            {
                fileName.Append("_");
            }

            fileName.Append(AddZero(dateTime.Hour) + AddZero(dateTime.Minute) + AddZero(dateTime.Second));

            return fileName.ToString();
        }

        public static string GetAsDateAndTimeString(this DateTime dateTime)
        {
            return GetAsDateAndTimeString(dateTime, true);
        }

        public static string GetAsDateAndTimeString(this DateTime dateTime, bool viewDelimiter)
        {
            if (!viewDelimiter)
            {
                return GetAsDateString(dateTime, false) + GetAsTimeString(dateTime, false);
            }

            Thread.CurrentThread.CurrentCulture = CultureInfo;
            return dateTime.ToShortDateString() + " " + dateTime.ToLongTimeString();
        }

        public static string GetAsDateAndShortTimeString(this DateTime dateTime)
        {
            return GetAsDateAndShortTimeString(dateTime, true);
        }

        public static string GetAsDateAndShortTimeString(this DateTime dateTime, bool viewDelimiter)
        {
            if (!viewDelimiter)
            {
                return GetAsDateString(dateTime, false) + GetAsTimeString(dateTime, false);
            }

            Thread.CurrentThread.CurrentCulture = CultureInfo;
            return dateTime.ToShortDateString() + " " + AddZero(dateTime.Hour) + ":" + AddZero(dateTime.Minute);
        }

        public static string GetAsDateString(this DateTime dateTime)
        {
            return GetAsDateString(dateTime, true);
        }

        public static string GetAsDateString(this DateTime dateTime, bool viewDelimiter)
        {
            if (!viewDelimiter)
            {
                return dateTime.Year + AddZero(dateTime.Month) + AddZero(dateTime.Day);
            }

            Thread.CurrentThread.CurrentCulture = CultureInfo;
            return dateTime.ToShortDateString();
        }

        public static string GetAsTimeString(this DateTime dateTime)
        {
            return GetAsTimeString(dateTime, true);
        }

        public static string GetAsTimeString(this DateTime dateTime, bool viewDelimiter)
        {
            if (!viewDelimiter)
            {
                return AddZero(dateTime.Hour) + AddZero(dateTime.Minute) + AddZero(dateTime.Second);
            }

            Thread.CurrentThread.CurrentCulture = CultureInfo;
            return dateTime.ToLongTimeString();
        }

        public static int GetWeek(this DateTime dateTime)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo;
            var myCal = CultureInfo.Calendar;
            var myCwr = CultureInfo.DateTimeFormat.CalendarWeekRule;
            var myFirstDow = CultureInfo.DateTimeFormat.FirstDayOfWeek;

            return myCal.GetWeekOfYear(dateTime, myCwr, myFirstDow);
        }

        private static string AddZero(int intIn)
        {
            if (intIn < 10)
            {
                return "0" + intIn;
            }

            return intIn.ToString(CultureInfo.InvariantCulture);
        }
    }
}