using System;
using System.Collections.Generic;

public class Robot
{
    private static HashSet<string> Names = new HashSet<string>();
    private Random random = new Random();
    public string Name { get; private set; }

    public Robot() {
        Reset();
    }
    public void Reset()
    {
        Name = GenerateName();
        Names.Add(Name);
    }

    private string GenerateName() {
        var suggestedName = GenerateRandomLetters(2) + GenerateRandomNumeric();
        if (!Robot.Names.Contains(suggestedName)) {
            return suggestedName;
        }
        return GenerateName();
    }

    private string GenerateRandomLetters(int length) {
        const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string result = "";
        for (int i = 0; i < length; i++) {
            result += letters[random.Next(letters.Length)];
        }
        return result;
    }

    private string GenerateRandomNumeric() {
        return random.Next(100, 1000).ToString();
    }
}