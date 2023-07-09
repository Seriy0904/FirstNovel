using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CharacterObject : MonoBehaviour
{
    [SerializeField] private Sprite cuteSmile;
    [SerializeField] private Sprite hardAngry;
    [SerializeField] private Sprite laugh;
    [SerializeField] private Sprite lightAngry;
    [SerializeField] private Sprite normal;
    [SerializeField] private Sprite sad;
    [SerializeField] private Sprite smile;
    [SerializeField] private Sprite smrink;
    [SerializeField] private Sprite stoneFace;
    [SerializeField] private Sprite suprised;
    [SerializeField] private Sprite BlueTShirt;

    private int characterSpeed = 250;
    private float maxAndMinPos = 5f;
    private Vector3 target = new Vector3(0.0f,0.0f,0.0f);

    public string currentEmotion;
    public string currentOutFit;
    public string currentFrontHairStyle;
    public string currentBackHairStyle;

    public short relative_x;
    public short relative_y;
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
        relative_x = x;
        relative_y = y;
        target.x =Screen.width/(maxAndMinPos*2) *x;
        target.y = Screen.height/(maxAndMinPos*2) * y;
    }
    public void instantMoveCharacter(short x, short y){
        moveCharacter(x,y);
        transform.position = new Vector3(Screen.width/(maxAndMinPos*2)*x,Screen.height/(maxAndMinPos*2)*y,0.0f);
        target = transform.position;
    }
    public void changeEmotionsSprite(string spriteName){
        try{
            Image childImage = gameObject.transform.GetChild(2).GetComponent<Image>();
        switch(spriteName){
            case "cuteSmile":
                childImage.sprite = cuteSmile;
                break;
            case "hardAngry":
                childImage.sprite = hardAngry;
                break;
            case "laugh":
                childImage.sprite = laugh;
                break;
            case "lightAngry":
                childImage.sprite = lightAngry;
                break;
            case "normal":
                childImage.sprite = normal;
                break;
            case "sad":
                childImage.sprite = sad;
                break;
            case "smile":
                childImage.sprite = smile;
                break;
            case "smrink":
                childImage.sprite = smrink;
                break;
            case "stoneFace":
                childImage.sprite = stoneFace;
                break;
            case "suprised":
                childImage.sprite = suprised;
                break;
        }
        currentEmotion = spriteName;
        }
        catch(UnityException e){

        }
    }

    public void changeOutFitSprite(string spriteName){
        try{
        Image childImage2s = gameObject.transform.GetChild(4).GetComponent<Image>();
        switch(spriteName){
            case "BlueTShirt":
                childImage2s.sprite = BlueTShirt;
                break;
            }
            currentOutFit = spriteName;
        }catch(UnityException e){

        }
}
}
