using System;
using System.Collections.Generic;

public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey)
    {
        var result = "";
        foreach (char c in text) {
            result += Rotate(c, shiftKey);
        }
        return result;
    }

    private static char Rotate(char c, int shiftKey) {
        char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        LinkedList<char> linkedAlphabet = new LinkedList<char>(alphabet);

        int i;
        var node = linkedAlphabet.Find(c);
        for (i = 0; i < shiftKey; i++) {
            node = node.Next ?? linkedAlphabet.First;
        }
        return (char)(node.Value);
    }
}