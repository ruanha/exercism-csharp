using System;
using System.Linq;
using System.Collections.Generic;

public enum Schedule
{
    Teenth,
    First,
    Second,
    Third,
    Fourth,
    Last
}

public class Meetup
{
    private readonly int month, year;
    public Meetup(int month, int year)
    {
        this.month = month;
        this.year = year;
    }

    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
    {
        var specificWeekdayForMonth = getSpecificDaysOfWeek(dayOfWeek);
        
        switch(schedule)
        {
            case Schedule.First: return specificWeekdayForMonth.ElementAt(0);
            case Schedule.Second: return specificWeekdayForMonth.ElementAt(1);
            case Schedule.Third: return specificWeekdayForMonth.ElementAt(2);
            case Schedule.Fourth: return specificWeekdayForMonth.ElementAt(3);
            case Schedule.Last: return specificWeekdayForMonth.Last();
            case Schedule.Teenth: return specificWeekdayForMonth.First(day => day.Day > 12);
            default: throw new ArgumentOutOfRangeException();
        }
    }

    private IEnumerable<DateTime> getSpecificDaysOfWeek(DayOfWeek dayOfWeek) {
        return Enumerable
            .Range(1, DateTime.DaysInMonth(year, month))
            .Select(day => new DateTime(year, month, day))
            .Where(day => day.DayOfWeek == dayOfWeek);
    }
}