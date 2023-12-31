using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUIScript : MonoBehaviour
{
    public GameObject LevelPackSelectorUI;
    public GameObject LevelSelectorUI;
    private MainMenuLogicScript mainMenuLogicScript;
    private LevelPackSelectorUIScript levelPackSelectorLogicScript;
    private LevelSelectorUIScript levelSelectorLogicScript;

    // Start is called before the first frame update
    void Start() {
        LoadLogics();
    }

    // Update is called once per frame
    void Update() {
        
    }

    void LoadLogics() {
        mainMenuLogicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<MainMenuLogicScript>();
        levelPackSelectorLogicScript = mainMenuLogicScript.levelPackSelectorUIScript;
        levelSelectorLogicScript = mainMenuLogicScript.levelSelectorUIScript;
    }

    public void Exit() {
        Application.Quit();
    }

    public void OnPlayButtonClicked() {
        OpenLevelPackSelectorUI();
    }

    public void OpenLevelPackSelectorUI() {
        LevelPackSelectorUI.SetActive(true);
        levelPackSelectorLogicScript.LoadLogics();
        levelPackSelectorLogicScript.PopulateLevelPackGrid();
    }

    public void CloseLevelPackSelectorUI() {
        LevelPackSelectorUI.SetActive(false);
    }

    public void OpenLevelSelectorUI(LevelPack levelPack) {
        LevelSelectorUI.SetActive(true);
        levelSelectorLogicScript.LoadLogics();
        levelSelectorLogicScript.PopulateLevelGrid(levelPack);
    }

    public void CloseLevelSelectorUI() {
        LevelSelectorUI.SetActive(false);
    }
}
