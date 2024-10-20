using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {
    [Header("Levels")]
    public LevelObject currentLevel;
    public LevelObject[] levels;

    [Header("Arrays")]
    public MazeObject[] mazeObjects;
    public Enemy[] enemies;
    public Boss[] bosses;

    [Header("Prefabs")]
    public GameObject enemyPrefab;
    public GameObject bossPrefab;
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

    public void characterMatchChecker(char foundCharacter, float posX, float posZ){
        foreach(MazeObject mObjs in mazeObjects) {
            if(mObjs.associatedKey == foundCharacter) {
                PlaceObject(mObjs.objectToSpawn, posX, posZ);
                break;
            }
        }

        foreach(Enemy eObj in enemies){
            if(eObj.associatedKey == foundCharacter) {
                PlaceEnemy(eObj, posX, posZ);
                break;
            }
        }
        if(foundCharacter=='B') {
            foreach (Boss bObj in bosses) {
                if(bObj.levelNumber == (System.Array.IndexOf(levels, currentLevel)+1)) {
                    PlaceBoss(bObj, posX, posZ);
                    break;
                }
            }
        }
    }

    public void PlaceObject(GameObject objToSpawn, float posX, float posZ) {
        if(objToSpawn.name == "Player") {
            objToSpawn.GetComponent<PlayerLevelScript>().setLevelValuesFromSave(currentPlayerLevel.levelNumber, currentXPCount);
        }
        Instantiate(objToSpawn, new Vector3(posX, 1.0f, posZ), objToSpawn.transform.rotation).transform.parent = mazeSpawner.transform;
    }

    public void PlaceEnemy(Enemy enemyType, float posX, float posZ) {
        Instantiate(enemyPrefab, new Vector3(posX, 1.0f, posZ), enemyPrefab.transform.rotation).transform.parent = mazeSpawner.transform;
        enemyPrefab.GetComponent<EnemyStartup>().Init(enemyType);
    }

    public void PlaceBoss(Boss bossType, float posX, float posZ) {
        Instantiate(bossPrefab, new Vector3(posX, 1.0f, posZ), bossPrefab.transform.rotation).transform.parent = mazeSpawner.transform;
        bossPrefab.GetComponent<BossStartup>().Init(bossType);
    }
}
