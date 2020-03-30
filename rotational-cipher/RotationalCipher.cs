using System;
using System.Linq;
using System.Collections.Generic;

public static class RotationalCipher
{
    static LinkedList<char> Alphabet = new LinkedList<char>("abcdefghijklmnopqrstuvwxyz".ToCharArray());
    public static string Rotate(string text, int shiftKey) =>
        text.Aggregate("", (current, next) => current + Rotate(next, shiftKey));

    private static char Rotate(char c, int shiftKey) {
        var node = Alphabet.Find(c);
        for (int i = 0; i < shiftKey; i++) {
            node = node.Next ?? Alphabet.First;
        }
        return (char)(node.Value);
    }
}