using System;
using System.Linq;

public class Robot
{
    private string _name;
    private string UpperCaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    public Robot() {
        _name = GenerateName();
    }
    public string Name
    {
        get
        {
            return _name;
        }
    }

    private string GenerateName() {
        return GenerateRandomLetter() + GenerateRandomLetter() + "123";
    }

    private string GenerateRandomLetter() {
        Random random = new Random();
        var r = random.Next(UpperCaseLetters.Length);
        return UpperCaseLetters[r].ToString();
    }

    public void Reset()
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}