using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct PlayerLevel {
    public int levelNumber;
    public int xpToReachLevel;
    public int newLevelHP;
    public int newLevelDmg;
    public Sprite levelMeterCustomSprite;
}
