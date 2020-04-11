using System;

public class Clock : IEquatable<Clock>
{
    readonly int _minutes;
    readonly int _hours;
    public Clock(int hours, int minutes)
    {
        while(minutes < 0 ) {
            minutes += 60;
            hours--;
        }

        while(minutes >= 60) {
            minutes -= 60;
            hours++;
        }

        if (hours < 0) {
            hours = 24 - (Math.Abs(hours)%24);
        }

        _hours = hours % 24;
        _minutes = minutes % 60;   
    }
    
    public Clock Add(int minutesToAdd)
    {
        return new Clock(_hours, _minutes + minutesToAdd);
    }

    public Clock Subtract(int minutesToSubtract)
    {
        return new Clock(_hours, _minutes - minutesToSubtract);
    }

    public override string ToString()
    {
        return $"{_hours.ToString("D2")}:{_minutes.ToString("D2")}";
    }

    public bool Equals(Clock other)
    {
        return this.ToString() == other.ToString();
    }
}
