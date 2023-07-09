using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public GameObject CharactersScenePath;
    public CharacterObject XiJinObject;
    public CharacterObject MainPersonObject;
    public CharacterObject RijiyObject;
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
    public Dictionary<string, CharacterObject> getCharacters(){
        return existCharacters;
    }
    public void clearCharacters(){
        foreach(var keyVal in existCharacters){
            Destroy(keyVal.Value.gameObject);
        }
        existCharacters.Clear();
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
            case "main":
                {
                    tempChar = Instantiate(MainPersonObject, zeroPos, transform.rotation);
                    break;
                }
            case "rijiy":
                {
                    tempChar = Instantiate(RijiyObject, zeroPos, transform.rotation);
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
    public void moveInstantCharacter(CharacterObject characterOut, short x, short y){
        characterOut.instantMoveCharacter(x,y);
    }
    public void changeEmotionsSprite(CharacterObject characterOut, string spriteName){
        characterOut.changeEmotionsSprite(spriteName);
    }
    public void changeOutFitSprite(CharacterObject characterOut, string spriteName){
        characterOut.changeOutFitSprite(spriteName);
    }
}
