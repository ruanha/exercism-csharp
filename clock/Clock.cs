using System;

public class Clock
{
    private int hours;
    public int Hours
    {
        get { return hours; }
        set { hours = value; }
    }

    private int minutes;
    public int Minutes
    {
        get { return minutes; }
        set { minutes = value; }
    }
    
    
    public Clock(int hours, int minutes)
    {
        Hours = hours;
        Minutes = minutes;
    }

    public Clock Add(int minutesToAdd)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public Clock Subtract(int minutesToSubtract)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public override string ToString()
    {
        return Hours.ToString("D2") + ":" + Minutes.ToString("D2");
    } 
}
