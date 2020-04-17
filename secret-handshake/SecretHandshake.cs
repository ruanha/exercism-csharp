using System;
using System.Collections.Generic;

public static class SecretHandshake
{
    enum SecretSign: int{
        Wink = 1,
        DoubleBlink = 2,
        CloseYourEyes = 4,
        Jump = 8,
        Reverse = 16
    }
    public static string[] Commands(int commandValue)
    {
        var result = new List<string>();
        if (CommandsMatch(commandValue, SecretSign.Wink))
            result.Add("wink");
        if (CommandsMatch(commandValue, SecretSign.DoubleBlink))
            result.Add("double blink");
        if (CommandsMatch(commandValue, SecretSign.CloseYourEyes))
            result.Add("close your eyes");
        if (CommandsMatch(commandValue, SecretSign.Jump))
            result.Add("jump");
        if (CommandsMatch(commandValue, SecretSign.Reverse))
            result.Reverse();

        return result.ToArray();
    }

    private static bool CommandsMatch(int command, SecretSign match) {
        return ((byte)command & (byte)match) == (byte)match;
    }
}
