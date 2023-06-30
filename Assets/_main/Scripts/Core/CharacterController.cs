using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public GameObject CharactersScenePath;
    public CharacterObject XiJinObject;
    //

    // Start is called before the first frame update
    private Dictionary<string, CharacterObject> existCharacters = new Dictionary<string, CharacterObject>(); 
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    //spawn character through nick name with switch case
    public void spawnCharacter(string nickName)
    {
        if(existCharacters.ContainsKey(nickName)){
            return;
        }
        switch (nickName)
        {
            case "xi":
                {
                    Debug.Log("Zero");
                    var tempChar = Instantiate(XiJinObject, transform.position, transform.rotation);
                    Debug.Log("First");
                    tempChar.transform.SetParent(CharactersScenePath.transform);
                    Debug.Log("Second");
                    existCharacters.TryAdd(nickName, tempChar);
                    break;
                }
        }
    }
    //get charatcer from hash map, if it doesn't exist return false
    public bool getCharacter(string nickName, out CharacterObject characterOut)
    {
        if(existCharacters.TryGetValue(nickName, out CharacterObject value))
        {
            characterOut = value;
            return true ;
        }
        else
        {
            characterOut = null;
            return false;
        }
    }
    public void moveCharacter(CharacterObject characterOut, short x, short y)
    {
        characterOut.moveCharacter(x,y);
    }
}
