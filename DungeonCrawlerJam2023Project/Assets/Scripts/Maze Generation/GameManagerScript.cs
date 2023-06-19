using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {
    public LevelObject currentLevel;
    public LevelObject[] levels;
    public MazeObject[] mazeObjects;
    public Enemy[] enemies;
    public GameObject mazeSpawner;
    public GameObject mazeSpawnerPrefab;
    public string endGameLoadText;
    public PlayerLevel currentPlayerLevel;
    public int currentXPCount;
    public static GameManagerScript Instance { get; private set; }
    void Awake(){
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }

        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }

    public void NextLevel() {
        if (System.Array.IndexOf(levels, currentLevel) < levels.Length-1) {
            StartLevel(levels[System.Array.IndexOf(levels, currentLevel)+1]); //start next level
        } else {
            if(mazeSpawner != null && mazeSpawner.transform.childCount > 0) {
                foreach(Transform child in mazeSpawner.transform) {
                    Destroy(child.gameObject);
                }
            } 

            StateManager.InstanceRef.SwitchState(new StartState(StateManager.InstanceRef));
            StateManager.InstanceRef.GameState = gameState.Cinematic;
            this.gameObject.GetComponentInChildren<UIHandler>().gameCanvas[4].GetComponent<loadScreen>().DisplayLoadingText(endGameLoadText);
        }
    }

    public void StartLevel(LevelObject levelToGenerate) {
        if(mazeSpawner != null && mazeSpawner.transform.childCount > 0) {
            foreach(Transform child in mazeSpawner.transform) {
                Destroy(child.gameObject);
            }
        } 

        StateManager.InstanceRef.SwitchState(new StartState(StateManager.InstanceRef));

        currentLevel = levelToGenerate;
        StateManager.InstanceRef.GameState = gameState.Cinematic;
        this.gameObject.GetComponentInChildren<UIHandler>().gameCanvas[4].GetComponent<loadScreen>().DisplayLoadingText(levelToGenerate.levelLoadText);
    }

    public void GenerateSpawner() {
        if(mazeSpawner == null) {
            GameObject mazeSpawnerObj = Instantiate(mazeSpawnerPrefab);
            mazeSpawner = mazeSpawnerObj.transform.GetChild(0).gameObject;

            GenerateLevel(currentLevel);
        }
    }

    public void SavePlayerData() {
        currentPlayerLevel = GameObject.Find("Player(Clone)").GetComponent<PlayerLevelScript>().currentLevel;
        currentXPCount = GameObject.Find("Player(Clone)").GetComponent<PlayerLevelScript>().currXP;
    }

    //So that function can be called when loading game
    public void GenerateLevel(LevelObject levelToGenerate) {
        this.gameObject.GetComponent<FileReader>().ReadFile(levelToGenerate.file);
    }

    public void PlaceObject(char foundCharacter, float posX, float posZ) {
        foreach(MazeObject mObjs in mazeObjects) {
            if(mObjs.associatedKey == foundCharacter) {
                if(mObjs.objectToSpawn.name == "Player") {
                    mObjs.objectToSpawn.GetComponent<PlayerLevelScript>().setLevelValuesFromSave(currentPlayerLevel.levelNumber, currentXPCount);
                }
                Instantiate(mObjs.objectToSpawn, new Vector3(posX, 1.0f, posZ), mObjs.objectToSpawn.transform.rotation).transform.parent = mazeSpawner.transform;
            }
        } 
    }
}
