using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenu : MonoBehaviour {
    public GameObject loadGameMenu;

    public void ButtonMethod (string btnFunction) {
        switch (btnFunction) {
            case "StartGame":
                StateManager.InstanceRef.GameState = gameState.Cinematic;
                GameManagerScript.Instance.StartLevel(GameManagerScript.Instance.levels[0]);
                break;
            
            case "LoadGame":
                loadGameMenu.SetActive(true);
                break;

            case "ExitGame": 
                Application.Quit();
                break;
        }
        
    }
}
