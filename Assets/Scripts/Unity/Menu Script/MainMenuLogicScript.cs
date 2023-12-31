using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuLogicScript : MonoBehaviour
{
    public GameObject MainMenuUI;
    public GameObject LevelPackSelectorUI;
    public GameObject LevelSelectorUI;
    public MainMenuUIScript mainMenuUIScript;
    public LevelPackSelectorUIScript levelPackSelectorUIScript;
    public LevelSelectorUIScript levelSelectorUIScript;
    

    // Start is called before the first frame update
    void Start() {
        LoadLogics();
    }

    // Update is called once per frame
    void Update() {
        
    }

    void LoadLogics() {
        mainMenuUIScript = MainMenuUI.GetComponent<MainMenuUIScript>();
        levelPackSelectorUIScript = LevelPackSelectorUI.GetComponent<LevelPackSelectorUIScript>();
        levelSelectorUIScript = LevelSelectorUI.GetComponent<LevelSelectorUIScript>();
    }

    public List<LevelPack> GetLevelPacks() {
        List<String> levelPackIds = JsonUtility.FromJson<LevelPackIds>(File.ReadAllText(Application.streamingAssetsPath + "/levelPackIds.json")).levelPackIds;
        List<LevelPack> levelPacks = new List<LevelPack>();
        foreach (String levelPackId in levelPackIds) {
            levelPacks.Add(GetLevelPack(levelPackId));
        }
        return levelPacks;
    }

    public LevelPack GetLevelPack(String levelPackId) {
        String levelPackFileName = Application.streamingAssetsPath + "/LevelPacks/" + levelPackId + ".json";
        LevelPack levelPack = JsonUtility.FromJson<LevelPack>(File.ReadAllText(levelPackFileName));
        return levelPack;
    }

    public Level GetLevel(String levelPackId, String levelId) {
        String levelFileName = Application.streamingAssetsPath + "/Levels/" + levelPackId + "/" + levelId + ".json";
        Level level = JsonUtility.FromJson<Level>(File.ReadAllText(levelFileName));;
        return level;
    }

    public void LoadLevel(Level level) {
        CrossSceneManager.loadedLevel = level;
        Debug.Log(CrossSceneManager.loadedLevel.name);
        SceneManager.LoadScene("GameScene");
    }
}
