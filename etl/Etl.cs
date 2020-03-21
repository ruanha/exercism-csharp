using System.Collections.Generic;

public static class Etl
{
    public static Dictionary<string, int> Transform(Dictionary<int, string[]> old)
    {
        var result = new Dictionary<string, int>();

        foreach (KeyValuePair<int, string[]> entry in old)
        {
            foreach (string letter in entry.Value) {
                result.Add(letter.ToLower(), entry.Key);
            }
        }
        return result;
    }
}