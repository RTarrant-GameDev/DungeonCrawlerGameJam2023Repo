using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {
    public GameObject mazeFloor;
    
    void Start() {
        FileReader.ReadFile("Assets/LevelFiles/Level1.txt");
    }
}
