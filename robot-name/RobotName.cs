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
        return GenerateRandomLetter() + GenerateRandomLetter() + GenerateRandomNumeric();
    }

    private string GenerateRandomLetter() {
        Random random = new Random();
        var r = random.Next(UpperCaseLetters.Length);
        return UpperCaseLetters[r].ToString();
    }

    private string GenerateRandomNumeric() {
        Random random = new Random();
        return random.Next(100, 1000).ToString();
    }

    public void Reset()
    {
        _name = GenerateName();
    }
}