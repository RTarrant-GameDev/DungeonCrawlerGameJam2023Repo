using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartState : IBaseState {
    private StateManager stateManager;
    private Scene scene;

    public StartState (StateManager smRef) {
        stateManager = smRef;
        scene = SceneManager.GetActiveScene();

        if(scene.name != "StartState") {
            SceneManager.LoadScene("StartState");

            stateManager.GameState = gameState.MainMenu;
        }
    }

    public void StateUpdate() {}
}