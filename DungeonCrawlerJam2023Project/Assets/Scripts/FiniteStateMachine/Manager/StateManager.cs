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
}