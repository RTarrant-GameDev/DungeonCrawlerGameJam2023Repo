using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour {
    public GameObject[] gameCanvas;
    public string currentState;

    // Update is called once per frame
    void Update() {
        checkUIState();
    }

    public void setCanvasState(string state) {
        currentState = state;
    }

    void checkUIState() {
        switch(currentState) {
            case "Main Menu":
                enableCanvas(gameCanvas[0]);
                break;
            
            case "Gameplay":
                enableCanvas(gameCanvas[1]);
                break;

            case "Pause":
                enableCanvas(gameCanvas[2]); 
                break;

            case "Gameover":
                enableCanvas(gameCanvas[3]); 
                break;

            case "LoadingScreen":
                enableCanvas(gameCanvas[4]);
                break;
        }
    }

    void enableCanvas(GameObject canvasToEnable) {
        foreach(GameObject canvas in gameCanvas) {
            if(canvas != canvasToEnable) {
                canvas.SetActive(false);
            } else {
                canvas.SetActive(true);
            }
        }
    }
}
