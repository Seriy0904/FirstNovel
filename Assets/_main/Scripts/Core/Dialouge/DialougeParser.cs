using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeParser
{
    public static DIALOUGE_LINE Parse(string rawLine)
    {
        Debug.Log($"Parsing line - '{rawLine}'")

        (string speaker, string dialouge, string commands) = RipContent(rawLine);

        return new DIALOUGE_LINE(speaker, dialouge, commands);

        return null;
    }
    private static (string, string, string) RipContent(string rawLine)
    {
        string speaker = "", dialouge = "", commands = "";

        int dialougeStart = -1;
        int dialougeEnd = -1;
        

        return (speaker, dialouge, commands);
    }
}
