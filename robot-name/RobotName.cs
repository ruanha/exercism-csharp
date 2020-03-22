using System;

public class Robot
{
    private string _name;
    public Robot() {
        _name = "AB123";
    }
    public string Name
    {
        get
        {
            return _name;
        }
    }

    public void Reset()
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}