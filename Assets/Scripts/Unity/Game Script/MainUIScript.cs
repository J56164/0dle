using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIScript : MonoBehaviour
{
    public GameObject PausedUI;
    public GameObject LevelNameText;
    public GameObject ObjectivesText;

    // Start is called before the first frame update
    void Start() {
        Init();
        LevelNameText.GetComponent<Text>().text = CrossSceneManager.loadedLevel.name;
    }

    // Update is called once per frame
    void Update() {
        
    }

    void Init() {
        LevelNameText = gameObject.transform.Find("Level Name").Find("Level Name Text").gameObject;
        ObjectivesText = gameObject.transform.Find("Objectives").Find("Objectives Text").gameObject;
    }

    void SetObjectivesText() {
        ObjectivesText.GetComponent<Text>().text = "Objectives:\n" + "\n";
    }

    public void OnPauseButtonPressed() {
        PausedUI.SetActive(true);
    }


}
