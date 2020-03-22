using System;
using System.Collections.Generic;

public class Robot
{
    private static HashSet<string> _names = new HashSet<string>();
    private Random random = new Random();
    private string _name;
    public string Name { get => _name; }

    public Robot() {
        Reset();
    }
    public void Reset()
    {
        _name = GenerateName();
        _names.Add(_name);
    }

    private string GenerateName() {
        var suggestedName = GenerateRandomLetters(2) + GenerateRandomNumeric();
        if (!Robot._names.Contains(suggestedName)) {
            return suggestedName;
        }
        return GenerateName();
    }

    private string GenerateRandomLetters(int length) {
        const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string result = "";
        for (int i = 0; i < length; i++) {
            result += letters[random.Next(letters.Length)].ToString();
        }
        return result;
    }

    private string GenerateRandomNumeric() {
        return random.Next(100, 1000).ToString();
    }
}