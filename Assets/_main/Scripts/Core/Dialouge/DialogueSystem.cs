using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    private TextArchitecture dialogueTextArchitecture;
    public TextMeshProUGUI dialogueName;
    //private TextArchitecture dialogueNameArchitecture;
    void Start()
    {
        dialogueTextArchitecture = new TextArchitecture(dialogueText);
        //dialogueNameArchitecture = new TextArchitecture(dialogueName);
    }

    void Update()
    {
    }
    public void DialogueTextSet(string text)
    {
        dialogueTextArchitecture.Build(text);
    }
    public void DialogueNametSet(string name)
    {
        dialogueName.text = name;
    }
}