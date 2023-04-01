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
        }
    }

    void GenerateLevel(LevelObject levelToGenerate) {
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
