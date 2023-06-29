using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswersMainContainer : MonoBehaviour
{
    public TextBoxContainer AnswerDefault;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addVariant(string answer,string fileName){
        TextBoxContainer tempAnswer = Instantiate(AnswerDefault, transform.position, transform.rotation);
        tempAnswer.transform.SetParent(transform);
        tempAnswer.textSet(answer);
    }
}
