using System;

public class Clock
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
        _minutes += minutesToAdd;
        return this;
    }

    public Clock Subtract(int minutesToSubtract)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public override string ToString()
    {
        var minutes = _minutes;
        var hours = _hours;

        if (hours < 0) {
            hours = 24 - Math.Abs(hours)%24;
        }
        while(minutes >= 60) {
            minutes -= 60;
            hours++;
        }
        return (hours%24).ToString("D2") + ":" + minutes.ToString("D2");
    }
}
