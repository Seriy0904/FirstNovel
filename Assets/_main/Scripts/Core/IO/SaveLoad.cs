using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    [SerializeField] private TextFiles textFiles;
    [SerializeField] private CharacterManager characterController;
    [SerializeField] private BackgroundController backgroundController;
    private string savingPath;
    // Start is called before the first frame update
    void Start()
    {
        savingPath =  Application.persistentDataPath + "/gamedata.json";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadButton(){
        if (File.Exists(savingPath)){
            string fileContents = File.ReadAllText(savingPath);
            SceneState currentSceneState = JsonUtility.FromJson<SceneState>(fileContents);
            backgroundController.changeBackground(currentSceneState.background);
            textFiles.fileName = currentSceneState.mainBranch.path;
            textFiles.currentLine = currentSceneState.mainBranch.line;
            if(currentSceneState.advancedBranch.path!=""){
                textFiles.advancedBranch = true;
                textFiles.branchName = currentSceneState.advancedBranch.path;
                textFiles.currentAdvancedLine = currentSceneState.advancedBranch.line;
            }
            characterController.clearCharacters();
            foreach (CharacterStates charState in currentSceneState.chacracters){
                characterController.spawnCharacter(charState.name);
                characterController.moveInstantCharacter(charState.name,charState.x_pos,charState.y_pos);
                characterController.changeEmotionsSprite(charState.name,charState.face );
                characterController.changeOutFitSprite(charState.name,charState.outFit );
                /*
                public string frontHairStye;
                public string backHairStye;
                */
            }
            textFiles.nextLineRun();
        }
    }
    public void SaveButton(){
        SceneState currentSceneState = new SceneState();
        currentSceneState.background = backgroundController.getCurrentBackground();
        Dictionary<string, CharacterObject> currentCharacters = characterController.getCharacters();
        foreach (KeyValuePair<string, CharacterObject> entry in currentCharacters){
            currentSceneState.chacracters.Add(new CharacterStates(
                entry.Key,
                entry.Value.relative_x,
                entry.Value.relative_y,
                entry.Value.currentOutFit,
                entry.Value.currentEmotion,
                entry.Value.currentFrontHairStyle,
                entry.Value.currentBackHairStyle));
        } 
        currentSceneState.mainBranch = new BranchState(textFiles.fileName,textFiles.currentLine-1);
        if(textFiles.advancedBranch){
            currentSceneState.advancedBranch = new BranchState(textFiles.branchName,textFiles.currentAdvancedLine-1);
        }
        string jsonState = JsonUtility.ToJson(currentSceneState);
        FileManager.WriteFile(savingPath, jsonState);
    }
    [System.Serializable]
    public class SceneState
    {
        public List<CharacterStates> chacracters =  new List<CharacterStates>();
        public string background;
        public BranchState mainBranch;
        public BranchState advancedBranch;
    }

    [System.Serializable]
    public class CharacterStates
    {
        public string name;
        //Position
        public short x_pos;
        public short y_pos;
        public string outFit;
        public string face;
        public string frontHairStye;
        public string backHairStye;
        public CharacterStates(string name,short x_pos,short y_pos,string outFit,string face,string frontHairStye, string backHairStye){
            this.x_pos =x_pos;
            this.y_pos =y_pos;
            this.name =name;
            this.outFit =outFit;
            this.face =face;
            this.frontHairStye =frontHairStye;
            this.backHairStye = backHairStye;
        }
    }
    [System.Serializable]
    public class BranchState
    {
        public string path="";
        public int line=0;
        public BranchState(string path, int line){
            this.path = path;
            this.line = line;
        }
    }
}
