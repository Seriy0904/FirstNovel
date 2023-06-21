using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject CharactersScenePath;
    public GameObject XiJinObject;
    //

    // Start is called before the first frame update
    void Start()
    {
        spawnCharacter("xi");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void spawnCharacter(string nickName)
    {
        switch (nickName)
        {
            case "xi":
                {
                    Debug.Log("Xi Jinpin");
                    Instantiate(XiJinObject, transform.position, transform.rotation).transform.parent = CharactersScenePath.transform;
                    break;
                }
        }
    }
}
