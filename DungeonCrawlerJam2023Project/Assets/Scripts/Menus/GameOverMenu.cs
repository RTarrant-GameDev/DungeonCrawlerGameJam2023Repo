using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MonoBehaviour {
    public void ButtonFunct(string btnFunction){
        switch (btnFunction){
            case "Restart":
                StateManager.InstanceRef.SwitchState(new PlayState(StateManager.InstanceRef));
                GameManagerScript.Instance.GenerateSpawner();
                break;

            case "BackToMainMenu":
                StateManager.InstanceRef.GameState = gameState.MainMenu;
                break;

            default:
                break;
        }
    }
}
