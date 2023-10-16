using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangedAttack : MonoBehaviour {
    public int dmgNumber;
    public float cooldownTime;
    private float lastAttackTime;
    public AudioClip attackSFX;
    public GameObject swordObj;

    public AnimationClip[] animations;

    void Start() {
        dmgNumber = this.gameObject.GetComponent<PlayerLevelScript>().currentLevel.newLevelDmg;
    }

    public void AttackCheck() {
        if(this.gameObject.GetComponent<PlayerMagicka>().currMagicka > 0){
            Debug.Log("Fireball launched!");
            this.gameObject.GetComponent<PlayerMagicka>().SubtractMP(25);
        }
    }

    public float CooldownProgress() {
        float currentTime = Time.time;
        return currentTime - lastAttackTime;
    }
}
