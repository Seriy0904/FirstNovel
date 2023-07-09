using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class AnswersMainContainer : MonoBehaviour
{
    public TextBoxContainer AnswerDefault;
    public TextFiles textFiles;
    public GameObject LineSeparator;
    private List<GameObject> containerLineList = new List<GameObject>();
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
        UnityAction lambda = () => {clearAnswers();textFiles.changeBranch(fileName);};
        tempAnswer.AddListener(lambda);
        containerLineList.Add(tempAnswer.gameObject);
    }
    public void addSeparator(){
        GameObject tempLine = Instantiate(LineSeparator, transform.position, transform.rotation);
        tempLine.transform.SetParent(transform);
        containerLineList.Add(tempLine.gameObject);
        
    }
    private void clearAnswers(){
        for(int i = 0;i<containerLineList.Count;i++){
            Destroy(containerLineList[i].gameObject);
        }
        containerLineList.Clear();
    }
}
