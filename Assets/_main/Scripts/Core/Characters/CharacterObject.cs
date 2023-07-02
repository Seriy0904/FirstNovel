using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CharacterObject : MonoBehaviour
{
    [SerializeField] public Sprite cuteSmile;
    [SerializeField] public Sprite hardAngry;
    [SerializeField] public Sprite laugh;
    [SerializeField] public Sprite lightAngry;
    [SerializeField] public Sprite normal;
    [SerializeField] public Sprite sad;
    [SerializeField] public Sprite smile;
    [SerializeField] public Sprite smrink;
    [SerializeField] public Sprite stoneFace;
    [SerializeField] public Sprite suprised;

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
    }
}
