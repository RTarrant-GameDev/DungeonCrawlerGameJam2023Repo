using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData {
    public int savedXPCount;
    public int savedLevelNumber;
    public Vector3 savedPlayerPos;
    public Quaternion savedPlayerRotation;
    public LevelObject currentLevel;
}
