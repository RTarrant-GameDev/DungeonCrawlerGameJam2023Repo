using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelScript : MonoBehaviour {
    public PlayerLevel currentLevel;
    public PlayerLevel[] levels;
    public int currXP;

    // Start is called before the first frame update
    void Start() {
        currXP = 0;
        currentLevel = levels[0];
    }

    // Update is called once per frame
    void Update() {
        if(currentLevel.levelNumber < levels.Length) {
            checkXPForLevelUp();
        }
    }

    public void AddXP(int xpToAdd) {
        if(currentLevel.levelNumber < levels.Length) {
            currXP += xpToAdd;
        }
    }

    void checkXPForLevelUp() {
        if(currXP >= levels[currentLevel.levelNumber].xpToReachLevel) {
            levelUp(currentLevel.levelNumber); //have level number act as index for next level - brilliant!
        }
    }
    
    void levelUp(int levelNumber) {
        currentLevel = levels[levelNumber];
        currXP -= currentLevel.xpToReachLevel;
        //set health and damage here
    }

    public void setLevelValuesFromSave(int levelNum, int xpCount) {
        currXP = xpCount; 

        foreach(PlayerLevel level in levels) {
            if(levelNum == level.levelNumber) {
                currentLevel = level;
                //set damage and hp in next two lines before breaking from foreach loop
                break;
            }
        }
    }
}
