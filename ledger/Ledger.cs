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
    public static LedgerEntry CreateEntry(string date, string desc, int chng)
    {
        return new LedgerEntry(DateTime.Parse(date, CultureInfo.InvariantCulture), desc, chng / 100.0m);
    }

    private static void CreateCulture(string currency, string locale)
    {
        string curSymb = null;
        int curNeg = 0;
        string datPat = null;

        if (currency == "USD")
        {
            if (locale == "en-US")
            {
                curSymb = "$";
                datPat = "MM/dd/yyyy";
            }
            else if (locale == "nl-NL")
            {
                curSymb = "$";
                curNeg = 12;
                datPat = "dd/MM/yyyy";
            }
        }

        if (currency == "EUR")
        {
            if (locale == "en-US")
            {
                curSymb = "€";
                datPat = "MM/dd/yyyy";
            }
            else if (locale == "nl-NL")
            {
                curSymb = "€";
                curNeg = 12;
                datPat = "dd/MM/yyyy";
            }
        }

        Ledger.culture = new CultureInfo(locale);
        culture.NumberFormat.CurrencySymbol = setCurrencySymbol(currency);
        culture.NumberFormat.CurrencyNegativePattern = curNeg;
        culture.DateTimeFormat.ShortDatePattern = datPat;
    }

    private static string setCurrencySymbol(string currency) => currency switch
    {
        "USD" => "$",
        "EUR" => "€",
        _     => throw new ArgumentException("Invalid currency")
    };
        

    private static bool isValidCulture(string currency, string locale)
    {
        if (currency != "USD" && currency != "EUR")
        {
            throw new ArgumentException("Invalid currency");
        }

        if (locale != "nl-NL" && locale != "en-US")
        {
            throw new ArgumentException("Invalid currency");
        }
        return true;
    }

    private static string PrintHead(string locale) => locale switch
        {
            "en-US" => "Date       | Description               | Change       ",
            "nl-NL" => "Datum      | Omschrijving              | Verandering  ",
            _       => throw new ArgumentException("Invalid locale")
        };

    private static string Date(DateTime date) => date.ToString("d", culture);

    private static string Description(string desc)
    {
        if (desc.Length > 25)
        {
            var trunc = desc.Substring(0, 22);
            trunc += "...";
            return trunc;
        }

        return desc;
    }

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
