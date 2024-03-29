using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Enemy {
    public char associatedKey;
    public string enemyName;
    public int enemyHP;
    public int enemyAttack;
    public int enemyXP;
    public Sprite enemySprite;
    public AnimatorOverrideController overrideController;
}