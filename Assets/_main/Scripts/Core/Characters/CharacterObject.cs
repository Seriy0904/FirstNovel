using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CharacterObject : MonoBehaviour
{
    //Emotions fields
    [SerializeField] public Sprite defaultSprite;
    [SerializeField] public Sprite cuteSmile;
    [SerializeField] public Sprite hardAngry;
    [SerializeField] public Sprite lightAngry;

    private int characterSpeed = 250;
    private float maxAndMinPos = 5f;
    private Vector3 target = new Vector3(0.0f,0.0f,0.0f);
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(target != transform.position){
            transform.position = Vector3.MoveTowards(transform.position,target,characterSpeed*Time.deltaTime);
        }
    }
    public void moveCharacter(short x, short y){
        target.x =Screen.width/(maxAndMinPos*2) *x;
        target.y = Screen.height/(maxAndMinPos*2) * y;
    }
    public void instantMoveCharacter(short x, short y){
        transform.position = new Vector3(Screen.width/(maxAndMinPos*2)*x,Screen.height/(maxAndMinPos*2)*y,0.0f);
        target = transform.position;
    }
    public void changeSprite(string spriteName){
        Image childImage = gameObject.GetComponentInChildren<Image>();
        switch(spriteName){
            case "cuteSmile":
                Debug.Log("WORKS");
                childImage.sprite = emotionFirst;
                break;
            case "hardAngry":
                childImage.sprite = emotionSecond;
                break;
            case "lightAngry":
                childImage.sprite = emotionThird;
                break;
        }
    }
}
