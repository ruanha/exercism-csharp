using System;
public static class Isogram
{
    public static bool IsIsogram(string word)
    {
         for (int i = 0; i < word.Length; i++) {
            char currentChar = word[i];
            if (Char.IsLetter(currentChar)) {
                for (int j = i + 1; j < word.Length; j++) {
                    if (Char.ToLower(currentChar) == Char.ToLower(word[j]) ) {
                        return false;
                    }
                }
            }
         }
         return true;
    }
}
