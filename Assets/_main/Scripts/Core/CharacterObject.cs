using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterObject : MonoBehaviour
{
    // Start is called before the first frame update
    private int characterSpeed = 200;
    private Vector3 target = new Vector3(0.0f,0.0f,0.0f);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,target,characterSpeed*Time.deltaTime);
    }
    public void moveCharacter(short x, short y){
        target.x =Screen.width/10f *x;
        target.y = Screen.height/10f * y;
    }
}
