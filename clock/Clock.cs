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

        return (_hours%24).ToString("D2") + ":" + _minutes.ToString("D2");
    } 
}
