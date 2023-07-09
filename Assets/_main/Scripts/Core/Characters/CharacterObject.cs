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

    [SerializeField] private Image faceImage;
    [SerializeField] private Image outFitImage;
    [SerializeField] private Image frontHaitStyleImage;
    [SerializeField] private Image backHairStyleImage;
    [SerializeField] private Image bodyImage;

    private int characterSpeed = 250;
    private float maxAndMinPos = 5f;
    private Vector3 target = new Vector3(0.0f,0.0f,0.0f);
    private bool fade = false;

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
    public void fadeCharacter(){
        fade = true;//TODO
    }
    public void instantMoveCharacter(short x, short y){
        moveCharacter(x,y);
        transform.position = new Vector3(Screen.width/(maxAndMinPos*2)*x,Screen.height/(maxAndMinPos*2)*y,0.0f);
        target = transform.position;
    }
    public void changeEmotionsSprite(string spriteName){
        if(faceImage!=null){
            switch(spriteName){
                case "cuteSmile":
                    faceImage.sprite = cuteSmile;
                    break;
                case "hardAngry":
                    faceImage.sprite = hardAngry;
                    break;
                case "laugh":
                    faceImage.sprite = laugh;
                    break;
                case "lightAngry":
                    faceImage.sprite = lightAngry;
                    break;
                case "normal":
                    faceImage.sprite = normal;
                    break;
                case "sad":
                    faceImage.sprite = sad;
                    break;
                case "smile":
                    faceImage.sprite = smile;
                    break;
                case "smrink":
                    faceImage.sprite = smrink;
                    break;
                case "stoneFace":
                    faceImage.sprite = stoneFace;
                    break;
              case "suprised":
                    faceImage.sprite = suprised;
                    break;
            }
            currentEmotion = spriteName;
        }
    }

    public void changeOutFitSprite(string spriteName){
        if(outFitImage!=null){
            switch(spriteName){
                case "BlueTShirt":
                    outFitImage.sprite = BlueTShirt;
                    break;
                }
                currentOutFit = spriteName;
        }
}
}
