using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
    public int dmgNumber;
    public float cooldownTime;
    private float lastAttackTime;
    public AudioClip attackSFX;

    void Start() {
        dmgNumber = this.gameObject.GetComponent<PlayerLevelScript>().currentLevel.newLevelDmg;
    }

    public void AttackEnemy(GameObject enemy) {
        float currentTime = Time.time;
        if(CooldownProgress() >= cooldownTime) {
            this.gameObject.GetComponent<AudioSource>().PlayOneShot(attackSFX);
            enemy.GetComponent<EnemyHealth>().SubtractHP(dmgNumber);
            lastAttackTime = currentTime;
        } else {
            Debug.Log("Currently cooling down");
        }
    }

    public float CooldownProgress() {
        float currentTime = Time.time;
        return currentTime - lastAttackTime;
    }
}
