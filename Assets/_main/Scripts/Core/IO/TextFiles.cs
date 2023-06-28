using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TextFiles : MonoBehaviour
{
    [SerializeField] private DialogueSystem dialogueSystem;
    [SerializeField] private CharacterController characterController;

    [SerializeField] private String fileName;
    private List<string> readedLines;
    private List<string> readedAdvancedLines;
    private int currentLine = 0;
    private int currentAdvancedLine = 0;
    private bool advancedBranch = false;
    private string branchName;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ReadMain());
    }
    IEnumerator ReadMain()
    {
        List<string> lines = FileManager.ReadTextFiles(fileName, false);
        readedLines = lines;
        yield return null;
    }
    IEnumerator ReadAdvanced()
    {
        readedAdvancedLines = FileManager.ReadTextFiles(branchName, false);
        yield return null;
    }
    public void nextLineRun()
    {
        // try
            if(!advancedBranch){
                readMainLine();
            }else{
                readAdvancedLine();
            }
        // }catch(e:E)
    }
    private void readMainLine()
    {
        string[] currentLineParsed = readedLines[currentLine].Split(new string[] { "\\(", "\\)" }, StringSplitOptions.None);
        string currentLineCommand = currentLineParsed[0];
        string[] arguments = currentLineParsed[1].Split("\\,");
        switch (currentLineCommand) {
            case "say":
                dialogueSystem.DialogueNametSet(arguments[0]);
                dialogueSystem.DialogueTextSet(arguments[1]);
                break;
            case "spawn":
                characterController.spawnCharacter(arguments[0]);
                break;
            case "move":
                if (characterController.getCharacter(arguments[0], out CharacterObject selectedCharacter))
                {
                    characterController.moveCharacter(selectedCharacter, short.Parse(arguments[1]) , short.Parse(arguments[2]));
                }
                break;
            case "branch":
                branchName = arguments[0];
                StartCoroutine(ReadAdvanced());
                currentAdvancedLine = 0;
                advancedBranch = true;
                break;
            case "change_branch":
                StartCoroutine(ReadMain());
                currentLine = 0;
                fileName = arguments[0];
                nextLineRun();
                return;
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
        catch (FormatException){}
        if(advancedBranch){
            readAdvancedLine();
        } 
    }
    private void readAdvancedLine(){
        string[] currentLineParsed = readedAdvancedLines[currentAdvancedLine].Split(new string[] { "\\(", "\\)" }, StringSplitOptions.None);
        string currentLineCommand = currentLineParsed[0];
        string[] arguments = currentLineParsed[1].Split("\\,");
        switch (currentLineCommand) {
            case "say":
                dialogueSystem.DialogueNametSet(arguments[0]);
                dialogueSystem.DialogueTextSet(arguments[1]);
                break;
            case "spawn":
            {
                characterController.spawnCharacter(arguments[0]);
                break;
            }
            case "move":
                if (characterController.getCharacter(arguments[0], out CharacterObject selectedCharacter))
                {
                    characterController.moveCharacter(selectedCharacter, short.Parse(arguments[1]) , short.Parse(arguments[2]));
                }
                break;
        }
        if (readedAdvancedLines.Count<= currentAdvancedLine+1)
        {
            advancedBranch = false;
            currentAdvancedLine = 0;
            return;
        }
        currentAdvancedLine += 1;
        try
        {
            if (Convert.ToBoolean(currentLineParsed[2]))
            {
                readAdvancedLine();
            }
        }
        catch (FormatException)
        {

        }
    }
}
