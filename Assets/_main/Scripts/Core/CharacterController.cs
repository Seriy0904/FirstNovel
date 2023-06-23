using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public GameObject CharactersScenePath;
    public GameObject XiJinObject;
    //

    // Start is called before the first frame update
    private Dictionary<string, GameObject> existCharacters = new Dictionary<string, GameObject>(); 
    void Start()
    {
        spawnCharacter("xi");
    }

    // Update is called once per frame
    void Update()
    {

    }
    //spawn character through nick name with switch case
    public void spawnCharacter(string nickName)
    {
        switch (nickName)
        {
            case "xi":
                {
                    var tempChar = Instantiate(XiJinObject, transform.position, transform.rotation);
                    tempChar.transform.SetParent(CharactersScenePath.transform);
                    existCharacters.TryAdd(nickName, tempChar);
                    break;
                }
        }
    }
    //get charatcer from hash map, if it doesn't exist return false
    public bool getCharacter(string nickName, out GameObject characterOut)
    {
        if(existCharacters.TryGetValue(nickName, out GameObject value))
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
    public void moveCharacter(GameObject characterOut, float x, float y)
    {
        Debug.Log(Screen.width);
        characterOut.transform.position = new Vector3(x, y, 0);
    }
}
