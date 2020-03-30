using System;
using System.Linq;
using System.Collections.Generic;

public static class RotationalCipher
{
    static LinkedList<char> Alphabet = new LinkedList<char>("abcdefghijklmnopqrstuvwxyz".ToCharArray());
    public static string Rotate(string text, int shiftKey) =>
        text.Aggregate("", (result, letter) => result + Rotate(letter, shiftKey));

    private static char Rotate(char c, int shiftKey) {
        if (!char.IsLetter(c))
            return c;

        bool isUpper = char.IsUpper(c);

        var node = Alphabet.Find(char.ToLower(c));
        for (int i = 0; i < shiftKey; i++) {
            node = node.Next ?? Alphabet.First;
        }
        return isUpper ? char.ToUpper(((char)(node.Value))) : (char)(node.Value);
    }
}