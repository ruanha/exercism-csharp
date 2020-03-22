using System;
using System.Linq;
using System.Collections.Generic;

public class Robot
{
    static HashSet<string> _names = new HashSet<string>();
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
        var suggestedName = GenerateRandomLetter() + GenerateRandomLetter() + GenerateRandomNumeric();
        if (!Robot._names.Contains(suggestedName)) {
            _names.Add(suggestedName);
            return suggestedName;
        }
        return GenerateName();
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