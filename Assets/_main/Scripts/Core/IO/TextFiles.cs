using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TextFiles : MonoBehaviour
{
    [SerializeField] private DialogueSystem dialogueSystem;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private AnswersMainContainer answersController;

    [SerializeField] private String fileName;
    private List<string> readedLines;
    private List<string> readedAdvancedLines;
    private int currentLine = 0;
    private int currentAdvancedLine = 0;
    private bool advancedBranch = false;
    private bool skipIsWork = true;
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
    public void changeBranch(string newBranch){
        skipIsWork = true;
        fileName = newBranch;
        StartCoroutine(ReadMain());
        currentLine = 0;
        nextLineRun();
    }
    public void nextLineRun()
    {
        if(skipIsWork){
            if(!advancedBranch){
                readMainLine();
            }else{
                readAdvancedLine();
            }
        }
    }
    private void readMainLine()
    {
        int firstBracket = 0;
        int secondBracket =0;
        for (int i=0;i<readedLines[currentLine].Length; i++){
            if(readedLines[currentLine][i] == '('){
                firstBracket = i;
                break;
            }
        }
        for (int i=readedLines[currentLine].Length-1;i>0; i--){
            if(readedLines[currentLine][i] == ')'){
                secondBracket = i;
                break;
            }
        }
        string[] currentLineParsed = new string[]{};
        if(firstBracket>0&&secondBracket>0){
            currentLineParsed = new string[]{readedLines[currentLine].Substring(0,firstBracket),readedLines[currentLine].Substring(firstBracket+1,secondBracket-firstBracket-1),secondBracket==readedLines[currentLine].Length-1 ? "False" : readedLines[currentLine].Substring(secondBracket)};
        }else{
            currentLineParsed = new string[]{"NULL", "NULL","False"};
        }
        string currentLineCommand = currentLineParsed[0];
        string[] arguments = (currentLineParsed.Length>1) ? currentLineParsed[1].Split("\\,") : new string[] {};
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
                changeBranch(arguments[0]);
                return;
            case "answers":
                skipIsWork = false;
                if(arguments.Length%2==0)
                {
                    for (int i=0; i<arguments.Length; i+=2){
                        answersController.addVariant(arguments[i], arguments[i+1]);
                        if(i!=arguments.Length-2){
                            answersController.addSeparator();
                        }
                    }
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
            if (Convert.ToBoolean(currentLineParsed[2].ToLower()))
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
            if (Convert.ToBoolean(currentLineParsed[2].ToLower()))
            {
                readAdvancedLine();
            }
        }
        catch (FormatException)
        {

        }
    }
}
