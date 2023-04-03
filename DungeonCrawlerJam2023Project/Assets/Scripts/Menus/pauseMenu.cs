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
                mainPauseMenu.SetActive(false); 
                break;

            case "SaveGame":
                mainPauseMenu.SetActive(false); 
                pauseSaveMenu.SetActive(true);
                break;
            
            case "LoadGame":
                mainPauseMenu.SetActive(false); 
                pauseLoadMenu.SetActive(true);
                break;

            case "ReturnToMainMenu":
                StateManager.InstanceRef.GameState = gameState.MainMenu;
                StateManager.InstanceRef.SwitchState(new StartState(StateManager.InstanceRef));
                Time.timeScale = 1.0f;
                break;

            case "BackFromLoad":
                mainPauseMenu.SetActive(false);
                this.gameObject.SetActive(true); 
                break;

            default:
                break;
        }
    }

    public void saveGame(int slot) {
        SaveData data = new SaveData();
        data.saveSlot = slot;
        data.savedXPCount = GameObject.Find("Player(Clone)").GetComponent<PlayerLevelScript>().currXP;
        data.savedLevelNumber = GameObject.Find("Player(Clone)").GetComponent<PlayerLevelScript>().currentLevel.levelNumber;
        data.savedPlayerPos = GameObject.Find("Player(Clone)").transform.position;
        data.savedPlayerRotation = GameObject.Find("Player(Clone)").transform.rotation;
        data.currentLevel = GameManagerScript.Instance.currentLevel;
        SaveLoadManager.Instance.SaveGame(slot, data);

        // Show a save success message
        if (saveSuccessfulMessage != null) {
            saveSuccessfulMessage.SetActive(true);
        }
    }    
}
