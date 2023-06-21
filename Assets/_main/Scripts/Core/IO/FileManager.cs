using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileManager
{
    public static List<string> ReadTextFiles(string filePath, bool includeBlacnkLines = true)
    {
        if (!filePath.StartsWith('/'))
            filePath = FilePaths.root + filePath;
        
        List<string> lines = new List<string>();
        try 
        {
            using(StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (includeBlacnkLines || !string.IsNullOrWhiteSpace(line))
                        lines.Add(line);
                }
            }
        }
        catch (FileNotFoundException ex)
        {
            
        }
        return lines;
    }

    public static List<string> ReadTextAsset(string FilePath, bool includeBlacnkLines = true)
    {
        return null; 
    }
}
