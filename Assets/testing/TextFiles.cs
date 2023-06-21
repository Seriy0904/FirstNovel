using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFiles : MonoBehaviour
{
    private string fileName = "testingFiles"; 
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Run());
    }
    IEnumerator Run()
    {
        List<string> lines = FileManager.ReadTextAsset(fileName, false);
        Debug.Log("run");
        foreach (string line in lines)
                Debug.Log(line);            
        
        yield return null;
    }
}
