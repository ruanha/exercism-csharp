using System;
using System.Collections.Generic;

public class Robot
{
    private static HashSet<string> _names = new HashSet<string>();
    private string _name;

    public Robot() {
        Reset();
    }
    public string Name { get => _name; }
    public void Reset()
    {
        _name = GenerateName();
        _names.Add(_name);
    }

    private string GenerateName() {
        var suggestedName = GenerateRandomLetter() + GenerateRandomLetter() + GenerateRandomNumeric();
        if (!Robot._names.Contains(suggestedName)) {
            return suggestedName;
        }
        return GenerateName();
    }

    private string GenerateRandomLetter() {
        const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";;
        Random random = new Random();
        var r = random.Next(letters.Length);
        return letters[r].ToString();
    }

    private string GenerateRandomNumeric() {
        Random random = new Random();
        return random.Next(100, 1000).ToString();
    }
}