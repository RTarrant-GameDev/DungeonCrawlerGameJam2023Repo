using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {
    public LevelObject currentLevel;
    public LevelObject[] levels;
    public MazeObject[] mazeObjects;
    public GameObject mazeSpawner;
    public GameObject mazeSpawnerPrefab;
    public string endGameLoadText;
    public Sprite endGameLoadImage;
    public bool mazeGenerated;

    public static GameManagerScript Instance { get; private set; }
    void Awake(){
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }
    
    void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            GenerateLevel(levels[0]);
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            GenerateLevel(levels[1]);
        } else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            GenerateLevel(levels[2]);
        } else if (Input.GetKeyDown(KeyCode.Alpha4)) {
            GenerateLevel(levels[3]);
        } else if (Input.GetKeyDown(KeyCode.Alpha5)) {
            GenerateLevel(levels[4]);
        } else if (Input.GetKeyDown(KeyCode.Alpha6)) {
            GenerateLevel(levels[5]);
        }
    }

    public void StartLevel(LevelObject levelToGenerate) {
        currentLevel = levelToGenerate;
        this.gameObject.GetComponentInChildren<UIHandler>().setCanvasState("LoadingScreen");
        this.gameObject.GetComponentInChildren<UIHandler>().gameCanvas[4].GetComponent<loadScreen>().DisplayLoadingText(levelToGenerate.levelLoadText);
       
    }

    public void GenerateSpawner() {
        if(mazeSpawner == null) {
            GameObject mazeSpawnerObj = Instantiate(mazeSpawnerPrefab);
            mazeSpawner = mazeSpawnerObj.transform.GetChild(0).gameObject;

            GenerateLevel(currentLevel);
        }
    }

    //So that function can be called when loading game
    public void GenerateLevel(LevelObject levelToGenerate) {
        if(mazeSpawner.transform.childCount > 0) {
            foreach(Transform child in mazeSpawner.transform) {
                Destroy(child.gameObject);
            }
        } 

        this.gameObject.GetComponent<FileReader>().ReadFile(levelToGenerate.filePath);
    }

    public void PlaceObject(char foundCharacter, float posX, float posZ) {
        foreach(MazeObject mObjs in mazeObjects) {
            if(mObjs.associatedKey == foundCharacter) {
                Instantiate(mObjs.objectToSpawn, new Vector3(posX, 1.0f, posZ), mObjs.objectToSpawn.transform.rotation).transform.parent = mazeSpawner.transform;
            }
        } 
    }
}
