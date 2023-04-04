using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour {
    // OnEnable is called each time the parent gameObject that the script is attached to is set to true
    void OnEnable() {
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
