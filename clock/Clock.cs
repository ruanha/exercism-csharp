using System;

public class Clock : IEquatable<Clock>
{
    private int _minutes { get; set; }
    private int _hours { get; set; }
    public Clock(int hours, int minutes)
    {
        _hours = hours;
        _minutes = minutes;
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
        var minutes = _minutes;
        var hours = _hours;

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

        return (hours%24).ToString("D2") + ":" + minutes.ToString("D2");
    }

    public bool Equals(Clock other)
    {
        return this.ToString() == other.ToString();
    }
}
