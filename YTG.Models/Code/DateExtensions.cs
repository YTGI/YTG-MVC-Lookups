// --------------------------------------------------------------------------------
/*  Copyright © 2020, Yasgar Technology Group, Inc.

    Purpose: Date Extension Methods

    Description: Various date extension methods for use throughout applications

*/
// --------------------------------------------------------------------------------

using System;

namespace YTG.Models.Code
{
    public static class DateExtensions
    {

        /// <summary>
        /// Convert a date to a short date string, empty if min or max value
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToShortDateDisplay(this DateTime value)
        {
            if (value == null) { return string.Empty; }

            if ((value == DateTime.MaxValue) || (value == DateTime.MinValue))
            {
                return string.Empty;
            }
            else
            {
                return value.ToShortDateString();
            }
        }

        /// <summary>
        /// Convert a date to a short date string, empty if min or max value
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToShortDateDisplay(this DateTime? value)
        {
            if (value == null) { return string.Empty; }

            if ((value == DateTime.MaxValue) || (value == DateTime.MinValue))
            {
                return string.Empty;
            }
            else
            {
                return value.Value.ToShortDateString();
            }
        }

        /// <summary>
        /// Convert a date to a short date/time string, empty if min or max value
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToShortDateTimeDisplay(this DateTime? value)
        {
            if (value == null) { return string.Empty; }

            if ((value == DateTime.MaxValue) || (value == DateTime.MinValue))
            {
                return string.Empty;
            }
            else
            {
                return value.Value.ToShortDateString() + " " + value.Value.ToShortTimeString();
            }
        }

        /// <summary>
        /// Convert a date to a short date/time string, empty if min or max value
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToShortDateTimeDisplay(this DateTime value)
        {
            if (value == null) { return string.Empty; }

            if ((value == DateTime.MaxValue) || (value == DateTime.MinValue))
            {
                return string.Empty;
            }
            else
            {
                return value.ToShortDateString() + " " + value.ToShortTimeString();
            }
        }

        /// <summary>
        /// Convert a date to CCYYMMDD string format
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToCCYYMMDD(this DateTime value)
        {
            if (value == DateTime.MaxValue)
            {
                return "99999999";
            }
            else
            {
                return value.Year.ToString() + value.Month.ToString("0#") + value.Day.ToString("0#");
            }
        }

        /// <summary>
        /// Find the date of the first day of the week, that day being passed in 
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        /// <param name="value"></param>
        /// <param name="startOfWeek"></param>
        /// <returns></returns>
        public static DateTime StartOfWeek(this DateTime value, DayOfWeek startOfWeek)
        {
            int diff = value.DayOfWeek - startOfWeek;
            if (diff < 0)
            {
                diff += 7;
            }
            return value.AddDays(-1 * diff).Date;
        }

        /// <summary>
        /// Evaluates if a day is on a weekend
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsWeekend(this DateTime value)
        {
            return (value.DayOfWeek == DayOfWeek.Sunday || value.DayOfWeek == DayOfWeek.Saturday);
        }

        /// <summary>
        /// Gets the last day of the month
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime EndOfTheMonth(this DateTime date)
        {
            var endOfTheMonth = new DateTime(date.Year, date.Month, 1)
                .AddMonths(1)
                .AddDays(-1);

            return endOfTheMonth;
        }

        /// <summary>
        /// Gets the first day of the month
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime BeginningOfTheMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }


        /// <summary>
        /// Converts a DateTimeOffset DateTime to a DateTime in a particular TimeZone by Name
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        /// <param name="date"></param>
        /// <param name="TimeZoneName"></param>
        /// <returns></returns>
        public static DateTimeOffset ToSpecificTimeZone(this DateTimeOffset date, string TimeZoneName)
        {
            if (!string.IsNullOrWhiteSpace(TimeZoneName))
            {
                if (date != DateTime.MinValue)
                {
                    return new DateTimeOffset(date.DateTime, TimeZoneInfo.FindSystemTimeZoneById(TimeZoneName).BaseUtcOffset);
                }
                else
                {
                    return DateTime.MinValue;
                }
            }
            else
            {
                return date;
            }
        }

        /// <summary>
        /// Converts a DateTimeOffset DateTime to a DateTime in a particular TimeZone by Name
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        /// <param name="date"></param>
        /// <param name="TimeZoneName"></param>
        /// <returns></returns>
        public static DateTimeOffset ToSpecificTimeZone(this DateTime date, string TimeZoneName)
        {
            if (!(date == null))
            {
                if (date.Kind == DateTimeKind.Unspecified) { date = DateTime.SpecifyKind(date, DateTimeKind.Utc); }
                if (!string.IsNullOrWhiteSpace(TimeZoneName))
                {
                    return TimeZoneInfo.ConvertTime(date, TimeZoneInfo.FindSystemTimeZoneById(TimeZoneName));
                }
                else
                {
                    return new DateTimeOffset(date);
                }
            }
            else
            {
                return new DateTimeOffset(DateTime.MinValue);
            }
        }


        /// <summary>
        /// Retrieve a DateTime string to the milliseconds for time stamps etc.
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToDateTimeTimeStampString(this DateTime value)
        {
            if (value == null || value == DateTime.MinValue)
            { return "1111111111111111111"; }
            if (value == DateTime.MaxValue)
            { return "9999999999999999999"; }

            string _timestamp = value.Year.ToString() + value.Month.ToString("0#") + value.Day.ToString("0#");
            _timestamp += value.Hour.ToString() + value.Minute.ToString("0#") + value.Second.ToString("0#");
            _timestamp += value.Millisecond.ToString("0000#");

            return _timestamp;

        }



    }
}
