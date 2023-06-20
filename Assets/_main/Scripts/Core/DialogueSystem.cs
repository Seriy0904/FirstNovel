using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    private TextArchitecture textArchitecture;
    void Start()
    {
        textArchitecture = new TextArchitecture(dialogueText);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            textArchitecture.Build("TEsdtsd sfsdfsdf sfefsf esfdfsedh l dlgmioagmglrg ");
        }
    }
}