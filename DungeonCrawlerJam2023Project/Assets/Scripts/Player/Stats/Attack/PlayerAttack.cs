using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
    public int dmgNumber;

    void Start() {
        dmgNumber = this.gameObject.GetComponent<PlayerLevelScript>().currentLevel.newLevelDmg;
    }

    public void AttackEnemy(GameObject enemy) {
        enemy.GetComponent<EnemyHealth>().SubtractHP(dmgNumber);
    }
}
