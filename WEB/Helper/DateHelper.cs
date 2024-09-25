using System;
using System.Collections.Generic;
using System.Globalization;

namespace WEB.Helper
{
    public class DateHelper
    {
		public static int GetNumberOfWeeksInYear(int year, CultureInfo culture = null)
		{
			if (culture == null)
				culture = CultureInfo.InvariantCulture;

			DateTime time = new DateTime(year, 12, 31);
			DateTimeFormatInfo format = culture.DateTimeFormat;

			return culture.Calendar.GetWeekOfYear(time,
				format.CalendarWeekRule, format.FirstDayOfWeek);
		}

        public static List<DateTime> GetDatesInWeek(int year, int weekOfYear)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            
            int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;

            //var checkMod = DateTime.DaysInMonth(year, weekOfYear);
            //GetDates(year, weekOfYear);
            // Use first Thursday in January to get first week of the year as
            // it will never be in Week 52/53
            DateTime firstThursday = jan1.AddDays(daysOffset);
            var cal = CultureInfo.CurrentCulture.Calendar;
            int firstWeek = cal.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            
            var weekNum = weekOfYear;
            // As we're adding days to a date in Week 1,
            // we need to subtract 1 in order to get the right date for week #1
            if (firstWeek == 1)
            {
                weekNum -= 1;
            }

            // Using the first Thursday as starting week ensures that we are starting in the right year
            // then we add number of weeks multiplied with days
            var result = firstThursday.AddDays(weekNum * 7);

            // Subtract 3 days from Thursday to get Monday, which is the first weekday in ISO8601
            DateTime start = result.AddDays(-3);
            //DateTime start = result;

            List<DateTime> dateList = new List<DateTime>();

            for (var dt = start; dt <= start.AddDays(6); dt = dt.AddDays(1))
            {
                dateList.Add(dt);
            }

            return dateList;
        }
       /* public static List<DateTime> GetDates(int year, int month)
        {
            return Enumerable.Range(1, DateTime.DaysInMonth(year, month))  // Days: 1, 2 ... 31 etc.
                             .Select(day => new DateTime(year, month, day)) // Map each day to a date
                             .ToList(); // Load dates into a list
        }*/
        public static List<string> GetDates(int year, int month)
        {
            var dates = new List<DateTime>();
            var longDate = new List<string>();
            DateTime monthDay = new DateTime(year, month, 1);

            //var dayWeek = new List<DayOfWeek>();
            // Loop from the first day of the month until we hit the next month, moving forward a day at a time
            for (var date = new DateTime(year, month, 1); date.Month == month; date = date.AddDays(1))
            {
                var lDate = date.ToLongDateString();
                //DayOfWeek monthWeek = date.DayOfWeek;
                //dayWeek.Add(monthWeek);
                //dates.Add(date);
                longDate.Add(lDate);
            }

            return longDate;
        }
    }
}