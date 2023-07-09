using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private Sprite background1;

    public string currentBackground;
    
    public void changeBackground(string backgroundName){
        Image childImage = gameObject.GetComponentInChildren<Image>();
        switch (backgroundName){
            case "background1":
                childImage.sprite=background1;
                break;
        }
        currentBackground = backgroundName;
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
