using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextBoxContainer : MonoBehaviour
{
    public TextMeshProUGUI textObject;
    public Button buttonObject;
    public void textSet(string text){
        textObject.text = text;
    }
    public void AddListener(UnityAction listener){
        buttonObject.onClick.AddListener(listener);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
