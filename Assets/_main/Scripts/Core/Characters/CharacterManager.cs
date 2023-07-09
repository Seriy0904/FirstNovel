using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
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
    public void moveCharacter(string nickName, short x, short y)
    {
        existCharacters.TryGetValue(nickName, out CharacterObject value);
        value.moveCharacter(x,y);
    }
    public void moveInstantCharacter(string nickName,short x, short y){
        existCharacters.TryGetValue(nickName, out CharacterObject value);
        value.instantMoveCharacter(x,y);
    }
    public void changeEmotionsSprite(string nickName,string spriteName){
        existCharacters.TryGetValue(nickName, out CharacterObject value);
        value.changeEmotionsSprite(spriteName);
    }
    public void changeOutFitSprite(string nickName,string spriteName){
        existCharacters.TryGetValue(nickName, out CharacterObject value);
        value.changeOutFitSprite(spriteName);
    }
}
