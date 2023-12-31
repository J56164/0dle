using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelPackSelectorUIScript : MonoBehaviour
{
    public GameObject LevelPackGrid;
    public GameObject LevelPackPrefab;
    private MainMenuLogicScript mainMenuLogicScript;
    private MainMenuUIScript mainMenuUIScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake() {
        LoadLogics();
    }

    public void LoadLogics()
    {
        mainMenuLogicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<MainMenuLogicScript>();
        mainMenuUIScript = mainMenuLogicScript.mainMenuUIScript;
    }

    public void PopulateLevelPackGrid() {
        ClearLevelPackGrid();
        List<LevelPack> levelPacks = mainMenuLogicScript.GetLevelPacks();
        foreach (LevelPack levelPack in levelPacks) {
            GameObject levelPackObject = Instantiate(LevelPackPrefab);
            levelPackObject.transform.Find("Level Pack Name").GetComponent<Text>().text = levelPack.name;
            levelPackObject.transform.Find("Select Button").GetComponent<Button>().onClick.AddListener(GetLevelPackButtonListener(levelPack));
            levelPackObject.transform.SetParent(LevelPackGrid.transform, false);
        }
    }

    UnityEngine.Events.UnityAction GetLevelPackButtonListener(LevelPack levelPack) {
        return () => {
            mainMenuUIScript.OpenLevelSelectorUI(levelPack);
        };
    }

    void ClearLevelPackGrid() {
        foreach (Transform childTransform in LevelPackGrid.transform) {
            Destroy(childTransform.gameObject);
        }
    }
}
