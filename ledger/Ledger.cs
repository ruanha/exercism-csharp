﻿using System;
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
    public static LedgerEntry CreateEntry(string date, string desc, int chng)
    {
        return new LedgerEntry(DateTime.Parse(date, CultureInfo.InvariantCulture), desc, chng / 100.0m);
    }

    private static CultureInfo CreateCulture(string cur, string loc)
    {
        string curSymb = null;
        int curNeg = 0;
        string datPat = null;

        if (cur != "USD" && cur != "EUR")
        {
            throw new ArgumentException("Invalid currency");
        }
        else
        {
            if (loc != "nl-NL" && loc != "en-US")
            {
                throw new ArgumentException("Invalid currency");
            }

            if (cur == "USD")
            {
                if (loc == "en-US")
                {
                    curSymb = "$";
                    datPat = "MM/dd/yyyy";
                }
                else if (loc == "nl-NL")
                {
                    curSymb = "$";
                    curNeg = 12;
                    datPat = "dd/MM/yyyy";
                }
            }

            if (cur == "EUR")
            {
                if (loc == "en-US")
                {
                    curSymb = "€";
                    datPat = "MM/dd/yyyy";
                }
                else if (loc == "nl-NL")
                {
                    curSymb = "€";
                    curNeg = 12;
                    datPat = "dd/MM/yyyy";
                }
            }
        }

        var culture = new CultureInfo(loc);
        culture.NumberFormat.CurrencySymbol = curSymb;
        culture.NumberFormat.CurrencyNegativePattern = curNeg;
        culture.DateTimeFormat.ShortDatePattern = datPat;
        return culture;
    }

    private static string PrintHead(string locale) => locale switch
        {
            "en-US" => "Date       | Description               | Change       ",
            "nl-NL" => "Datum      | Omschrijving              | Verandering  ",
            _       => throw new ArgumentException("Invalid locale")
        };

    private static string Date(IFormatProvider culture, DateTime date) => date.ToString("d", culture);

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

    private static string Change(IFormatProvider culture, decimal cgh)
    {
        return cgh < 0.0m ? cgh.ToString("C", culture) : cgh.ToString("C", culture) + " ";
    }

    private static string PrintEntry(IFormatProvider culture, LedgerEntry entry)
    {
        var formatted = "";
        var date = Date(culture, entry.Date);
        var description = Description(entry.Description);
        var change = Change(culture, entry.Change);

        formatted += date;
        formatted += " | ";
        formatted += string.Format("{0,-25}", description);
        formatted += " | ";
        formatted += string.Format("{0,13}", change);

        return formatted;
    }


    private static IEnumerable<LedgerEntry> sort(LedgerEntry[] entries)
    {
        var neg = entries.Where(e => e.Change < 0).OrderBy(x => x.Date + "@" + x.Description + "@" + x.Change);
        var post = entries.Where(e => e.Change >= 0).OrderBy(x => x.Date + "@" + x.Description + "@" + x.Change);

        var result = new List<LedgerEntry>();
        result.AddRange(neg);
        result.AddRange(post);

        return result;
    }

    public static string Format(string currency, string locale, LedgerEntry[] entries)
    {
        string formatted = PrintHead(locale);
        var culture = CreateCulture(currency, locale);

        foreach (var entry in sort(entries))
        {
            formatted += "\n" + PrintEntry(culture, entry);
        }

        return formatted;
    }
}