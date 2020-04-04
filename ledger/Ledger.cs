using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public class LedgerEntry
{
    public LedgerEntry(DateTime date, string description, decimal change)
    {
        Date = date;
        Description = description;
        Change = change;
    }

    public DateTime Date { get; }
    public string Description { get; }
    public decimal Change { get; }
}

public static class Ledger
{
    private static CultureInfo culture;
    public static LedgerEntry CreateEntry(string date, string desc, int chng) =>
        new LedgerEntry(DateTime.Parse(date, CultureInfo.InvariantCulture), desc, chng / 100.0m);

    private static void CreateCulture(string currency, string locale)
    {
        Ledger.culture = new CultureInfo(locale);
        culture.NumberFormat.CurrencySymbol = CurrencySymbol(currency);
        culture.NumberFormat.CurrencyNegativePattern = CurrencyNegativePattern(locale);
        culture.DateTimeFormat.ShortDatePattern = DatePattern(locale);
    }

    private static string CurrencySymbol(string currency) => currency switch
    {
        "USD" => "$",
        "EUR" => "€",
        _     => throw new ArgumentException("Invalid currency")
    };

    private static int CurrencyNegativePattern(string locale) => locale switch 
    {
        "en-US" => 0,
        "nl-NL" => 12,
        _       => throw new ArgumentException("invalid locale")
    };
        
    private static string DatePattern(string locale) => locale switch
    {
        "en-US" => "MM/dd/yyyy",
        "nl-NL" => "dd/MM/yyyy",
        _       => throw new ArgumentException("invalid locale")
    };

    private static string PrintHead(string locale) => locale switch
        {
            "en-US" => "Date       | Description               | Change       ",
            "nl-NL" => "Datum      | Omschrijving              | Verandering  ",
            _       => throw new ArgumentException("Invalid locale")
        };

    private static string Date(DateTime date) => date.ToString("d", culture);

    private static string Description(string description) =>
        description.Length > 25 ? description.Substring(0, 22) + "..." : description;

    private static string Change(decimal cgh)
    {
        return cgh < 0.0m ? cgh.ToString("C", culture) : cgh.ToString("C", culture) + " ";
    }

    private static string PrintEntry(LedgerEntry entry) =>
        $"\n{Date(entry.Date)} | {Description(entry.Description),-25} | {Change(entry.Change),13}";



    private static IEnumerable<LedgerEntry> sort(LedgerEntry[] entries) => entries
        .OrderBy(entry => entry.Change)
        .OrderBy(entry => entry.Date + "@" + entry.Description + "@" + entry.Change)
        .ToArray();

    public static string Format(string currency, string locale, LedgerEntry[] entries)
    {
        CreateCulture(currency, locale);

        return PrintHead(locale) + PrintEntries(entries);
    }

    private static string PrintEntries(LedgerEntry[] entries) => sort(entries)
        .Select(x => PrintEntry(x))
        .Aggregate("", (agg, entry) => agg + entry);
}
