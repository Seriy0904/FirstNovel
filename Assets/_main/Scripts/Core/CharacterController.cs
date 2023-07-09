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
        CharacterObject tempChar;
        var zeroPos = new Vector3(0.0f,0.0f,0.0f);
        switch (nickName)
        {
            case "xi":
                {
                    tempChar = Instantiate(XiJinObject, zeroPos, transform.rotation);
                    break;
                }
            default:
                    tempChar = Instantiate(XiJinObject, zeroPos, transform.rotation);
                    break;
        }
        tempChar.transform.SetParent(CharactersScenePath.transform);
        existCharacters.TryAdd(nickName, tempChar);
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
