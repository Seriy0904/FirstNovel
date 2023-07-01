using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CharacterObject : MonoBehaviour
{
    // Start is called before the first frame update
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
    public void changeSprite(){
        Image childImage = gameObject.GetComponentInChildren<Image>();
    }
}
