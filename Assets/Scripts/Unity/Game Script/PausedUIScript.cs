using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedUIScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void OnContinueButtonPressed() {
        gameObject.SetActive(false);
    }

    public void OnRestartButtonPressed() {
        SceneManager.LoadScene("GameScene");
    }

    public void OnMenuButtonPressed() {
        SceneManager.LoadScene("MenuScene");
    }
}
