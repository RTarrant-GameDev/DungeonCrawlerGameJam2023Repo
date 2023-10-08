using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Boss {
    public string enemyName;
    public int enemyHP;
    public int enemyAttack;
    public int enemyXP;
    public Sprite enemySprite;
    public AnimatorOverrideController overrideController;
    public int levelNumber;
}