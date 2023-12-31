using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectorUIScript : MonoBehaviour
{
    public GameObject LevelGrid;
    public GameObject LevelPrefab;
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

    public void PopulateLevelGrid(LevelPack levelPack) {
        ClearLevelGrid();
        foreach (String levelId in levelPack.levelIds) {
            Level level = mainMenuLogicScript.GetLevel(levelPack.id, levelId);
            GameObject levelObject = Instantiate(LevelPrefab);
            levelObject.transform.Find("Level Name").GetComponent<Text>().text = level.name;
            levelObject.transform.Find("Play Button").GetComponent<Button>().onClick.AddListener(GetLevelButtonListener(level));
            levelObject.transform.SetParent(LevelGrid.transform, false);
        }
    }

    UnityEngine.Events.UnityAction GetLevelButtonListener(Level level) {
        return () => {
            mainMenuLogicScript.LoadLevel(level);
        };
    }

    void ClearLevelGrid() {
        foreach (Transform childTransform in LevelGrid.transform) {
            Destroy(childTransform.gameObject);
        }
    }
}
