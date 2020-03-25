using System;
using System.Linq;
public static class BeerSong
{
    public static string Recite(int numberOfBottles, int takeDown)
    {
        string result = "";

        while (takeDown > 0) {
            if (numberOfBottles > 1) {
                string nextEnding = numberOfBottles - 1 > 1 ? "s" : "";
                result += $"{numberOfBottles} bottles of beer on the wall, {numberOfBottles} bottles of beer.\n" +
                    $"Take one down and pass it around, {numberOfBottles - 1} bottle{nextEnding} of beer on the wall.";
            } else if (numberOfBottles == 1) {
                result += $"1 bottle of beer on the wall, 1 bottle of beer.\n" +
                    "Take it down and pass it around, no more bottles of beer on the wall.";
            } else if (numberOfBottles < 1) {
                result += "No more bottles of beer on the wall, no more bottles of beer.\n" +
                "Go to the store and buy some more, 99 bottles of beer on the wall.";
            }
            
            numberOfBottles--;
            takeDown--;
        }
        return result;
    }
}

/*
    "2 bottles of beer on the wall, 2 bottles of beer.\n" +
    "Take one down and pass it around, 1 bottle of beer on the wall.\n" +
    "\n" +
    "1 bottle of beer on the wall, 1 bottle of beer.\n" +
    "Take it down and pass it around, no more bottles of beer on the wall.\n" +
    "\n" +
    "No more bottles of beer on the wall, no more bottles of beer.\n" +
    "Go to the store and buy some more, 99 bottles of beer on the wall.";
*/