using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TextFiles : MonoBehaviour
{
    [SerializeField] private DialogueSystem dialogueSystem;
    [SerializeField] private CharacterController characterController;

    [SerializeField] private TextAsset fileName;
    private List<string> readedLines;
    private int currentLine = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Run());
    }
    IEnumerator Run()
    {
        List<string> lines = FileManager.ReadTextAsset(fileName, false);
        readedLines = lines;
        yield return null;
    }
    public void nextLineRun()
    {
        string[] currentLineParsed = readedLines[currentLine].Split(new string[] { "\\(", "\\)" }, StringSplitOptions.None);
        string currentLineCommand = currentLineParsed[0];
        string[] arguments = currentLineParsed[1].Split("\\,");
        switch (currentLineCommand) {
            case "say":
                dialogueSystem.DialogueNametSet(arguments[0]);
                dialogueSystem.DialogueTextSet(arguments[1]);
                break;
            case "move":
                if (characterController.getCharacter(arguments[0], out GameObject selectedCharacter))
                {
                    characterController.moveCharacter(selectedCharacter, Screen.width/10f * short.Parse(arguments[1]) , Screen.height / 10f * short.Parse(arguments[2]));
                }
                break;
        }
        if (readedLines.Count<= currentLine+1)
        {
            currentLine = 0;
            return;
        }
        currentLine += 1;
        try
        {
            if (Convert.ToBoolean(currentLineParsed[2]))
            {
                nextLineRun();
            }
        }
        catch (FormatException)
        {

        }
    }
}
