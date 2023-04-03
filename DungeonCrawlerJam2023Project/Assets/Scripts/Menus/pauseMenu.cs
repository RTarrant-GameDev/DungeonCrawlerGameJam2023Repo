using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour {
    public GameObject mainPauseMenu;
    public GameObject pauseSaveMenu;
    public GameObject pauseLoadMenu;
    public GameObject saveSuccessfulMessage;

    // OnEnable is called each time the parent gameObject that the script is attached to is set to true
    void OnEnable() {
        mainPauseMenu.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void buttonMethod(string btnFunction) {
        switch(btnFunction) { 
            case "Resume":
                Time.timeScale = 1.0f;
                StateManager.InstanceRef.GameState = gameState.Play;
                break;

            case "ReturnToMainMenu":
                StateManager.InstanceRef.GameState = gameState.MainMenu;
                StateManager.InstanceRef.SwitchState(new StartState(StateManager.InstanceRef));
                Time.timeScale = 1.0f;
                break;

            default:
                break;
        }
    } 
}
