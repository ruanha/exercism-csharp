using System;
using System.Text;
using System.Collections.Generic;

public static class RnaTranscription
{
    private static readonly Dictionary<char, char> Complement = new Dictionary<char, char>
    {
        { 'G', 'C' }, { 'C', 'G' }, { 'T', 'A' }, { 'A', 'U' }
    };
    public static string ToRna(string nucleotide)
    {
        if ( String.IsNullOrWhiteSpace(nucleotide) ) {
            return String.Empty;
        }

        StringBuilder transcript = new StringBuilder("", nucleotide.Length);
        foreach (char c in nucleotide) {
            char value;
            if ( Complement.TryGetValue(c, out value) ) {
                transcript.Append(value);
            }
            else {
                InputOutOfRange(nucleotide, c);
            }
        }
        return transcript.ToString();
    }

    private static void InputOutOfRange(string nucleotide, char c) {
        throw new ArgumentOutOfRangeException(
            $"Input can only contain 'ACGT', the character" +
            $" '{c}' was found in input at position {nucleotide.IndexOf(c)}!");
    }
}