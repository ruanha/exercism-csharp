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
        Name = UniqueName();
        Names.Add(Name);
    }

    private string UniqueName() {
        var suggestedName = GenerateRandomLetters(2) + GenerateRandomNumerics(3);
        if (!Robot.Names.Contains(suggestedName)) {
            return suggestedName;
        }
        return UniqueName();
    }

    private string GenerateRandomLetters(int length) {
        const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string result = "";
        for (int i = 0; i < length; i++) {
            result += letters[random.Next(letters.Length)];
        }
        return result;
    }

    private string GenerateRandomNumerics(int length) {
        string result = "";
        for (int i = 0; i < length; i++) {
            result += random.Next(0, 10).ToString();
        }
        return result;
    }
}