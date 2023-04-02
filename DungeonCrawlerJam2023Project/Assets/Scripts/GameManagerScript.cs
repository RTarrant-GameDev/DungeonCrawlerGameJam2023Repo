using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {
    public LevelObject[] levels;
    public MazeObject[] mazeObjects;
    public GameObject mazeSpawner;
    
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

    void GenerateLevel(LevelObject levelToGenerate) {
        if(mazeSpawner.transform.childCount > 0) {
            foreach(Transform child in mazeSpawner.transform) {
                Destroy(child.gameObject);
            }
        }

        this.gameObject.GetComponentInChildren<FileReader>().ReadFile(levelToGenerate.filePath);
    }

    public void PlaceObject(char foundCharacter, float posX, float posZ) {
        foreach(MazeObject mObjs in mazeObjects) {
            if(mObjs.associatedKey == foundCharacter) {
                Instantiate(mObjs.objectToSpawn, new Vector3(posX, 1.0f, posZ), mObjs.objectToSpawn.transform.rotation).transform.parent = mazeSpawner.transform;
            }
        } 
    }
}
