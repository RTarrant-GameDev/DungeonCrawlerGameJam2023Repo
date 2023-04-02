using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum gameState { Default, MainMenu, Play, Pause, Cinematic, Gameover }
public class StateManager : MonoBehaviour {
    private IBaseState IActiveState;
    public static StateManager InstanceRef = null;
    private static StateManager instanceRef;
    public GameObject mainCam;
    public gameState GameState;

    void Awake() {
        mainCam = GameObject.FindWithTag("MainCamera"); 

        if(instanceRef != null)
        {
            DestroyImmediate(gameObject);
        }

        else
        {
            instanceRef = this;
            DontDestroyOnLoad(instanceRef);
            InstanceRef = this;
        }
    }

    void Update() {
        mainCam = GameObject.FindWithTag("MainCamera");

        if(IActiveState != null) {
            IActiveState.StateUpdate();
        }

        switch(GameState) {
            case gameState.MainMenu:
                this.gameObject.GetComponentInChildren<UIHandler>().setCanvasState("Main Menu");
                break;

            case gameState.Cinematic:
                this.gameObject.GetComponentInChildren<UIHandler>().setCanvasState("LoadingScreen");
                break;

            case gameState.Play:
                this.gameObject.GetComponentInChildren<UIHandler>().setCanvasState("Gameplay");
                break;

            default:
                break;
        }
    }

    public void SwitchState(IBaseState nextState) {
        IActiveState = nextState;
    }
}