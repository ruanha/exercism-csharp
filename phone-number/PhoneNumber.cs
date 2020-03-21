using System;
using System.Text.RegularExpressions;

public class PhoneNumber
{
    public static string Clean(string phoneNumber)
    {
        string clean = Regex.Replace(phoneNumber, @"\D", "");
        clean = Regex.Replace(clean, @"^1", "");

        string NANPformat = @"^([2-9]\d{2}[2-9]\d{6})$";
        Match match = Regex.Match(clean, NANPformat);

        return match.Success ? match.Value : throw new ArgumentException();
    }
}