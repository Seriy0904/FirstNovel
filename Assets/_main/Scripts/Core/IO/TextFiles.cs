using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class TextFiles : MonoBehaviour
{
    [SerializeField] private DialogueSystem dialogueSystem;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private AnswersMainContainer answersController;
    [SerializeField] private BackgroundController backController;

    [SerializeField] public String fileName;
    public string branchName;
    private List<string> readedLines;
    private List<string> readedAdvancedLines = new List<string>();
    public int currentLine = 0;
    public int currentAdvancedLine = 0;
    public bool advancedBranch = false;
    private bool skipIsWork = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ReadMain());
    }
    IEnumerator ReadMain()
    {
        readedLines = FileManager.ReadTextFiles(fileName, false);
        yield return null;
    }
    IEnumerator ReadAdvanced()
    {
        readedAdvancedLines = FileManager.ReadTextFiles(branchName, false);
        yield return null;
    }
    public void changeBranch(string newBranch, int line = 0){
        skipIsWork = true;
        fileName = newBranch;
        StartCoroutine(ReadMain());
        currentLine = line;
        nextLineRun();
    }
    public void nextLineRun()
    {
        if(skipIsWork){
        //     if(!advancedBranch){
                readMainLine();
        //     }else{
        //         readAdvancedLine();
        //     }
        }
    }
    private void readMainLine()
    {
        if (readedAdvancedLines.Count< currentAdvancedLine+1)
        {
            advancedBranch = false;
        }
        ref int privateCurrentLine = ref currentLine;
        List<string> privateReadedLines = readedLines;
        if(advancedBranch){
            privateCurrentLine = ref currentAdvancedLine;
            privateReadedLines = readedAdvancedLines;
        }
        int firstBracket = 0;
        int secondBracket =0;
        for (int i=0;i<privateReadedLines[privateCurrentLine].Length; i++){
            if(privateReadedLines[privateCurrentLine][i] == '('){
                firstBracket = i;
                break;
            }
        }
        for (int i=privateReadedLines[privateCurrentLine].Length-1;i>0; i--){
            if(privateReadedLines[privateCurrentLine][i] == ')'){
                secondBracket = i;
                break;
            }
        }
        string[] currentLineParsed = new string[]{};
        if(firstBracket>0&&secondBracket>0){
            currentLineParsed = new string[]{privateReadedLines[privateCurrentLine].Substring(0,firstBracket),
            privateReadedLines[privateCurrentLine].Substring(firstBracket+1,secondBracket-firstBracket-1),
            secondBracket==privateReadedLines[privateCurrentLine].Length-1 ? "False" : privateReadedLines[privateCurrentLine].Substring(secondBracket+1)};
        }else{
            currentLineParsed = new string[]{"NULL", "NULL","False"};
        }
        string currentLineCommand = currentLineParsed[0];
        string[] arguments = (currentLineParsed.Length>1) ? currentLineParsed[1].Split("|") : new string[] {};
        switch (currentLineCommand) {
            case "say":
                dialogueSystem.DialogueNametSet(arguments[0]);
                dialogueSystem.DialogueTextSet(arguments[1]);
                break;
            case "spawn":
                characterController.spawnCharacter(arguments[0]);
                break;
            case "move":
                if (characterController.getCharacter(arguments[0], out CharacterObject smoothMovingCharacter))
                {
                    characterController.moveCharacter(smoothMovingCharacter, short.Parse(arguments[1]) , short.Parse(arguments[2]));
                }
                break;
            case "teleport":
                if (characterController.getCharacter(arguments[0], out CharacterObject instantMovingCharacter))
                {
                    characterController.moveInstantCharacter(instantMovingCharacter, short.Parse(arguments[1]) , short.Parse(arguments[2]));
                }
                break;
            case "branch":
                branchName = arguments[0];
                StartCoroutine(ReadAdvanced());
                currentAdvancedLine = 0;
                advancedBranch = true;
                privateCurrentLine += 1;
                nextLineRun();
                return;
                break;
            case "change_branch":
                int newBranchLine = 0;
                if(arguments.Length>1){
                    try{
                        newBranchLine = short.Parse(arguments[1]);
                    }catch(FormatException e){}
                }
                changeBranch(arguments[0], newBranchLine);
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
            case "sprite":
                if (characterController.getCharacter(arguments[0], out CharacterObject cahngeSpriteCharacter))
                {
                    characterController.changeEmotionsSprite(cahngeSpriteCharacter, arguments[1]);
                }
                break;
            case "outfit":
                if (characterController.getCharacter(arguments[0], out CharacterObject changeOutFitSprite))
                {
                    characterController.changeOutFitSprite(changeOutFitSprite, arguments[1]);
                }
                break;
            case "back":
                    backController.changeBackground(arguments[0]);
                break;

        }
        privateCurrentLine += 1;
        if (Convert.ToBoolean(currentLineParsed[2].ToLower()))
        {
            // if(advancedBranch){
            //     readAdvancedLine();
            // }else{
                nextLineRun();
            // }
        }
    }
}