using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour {
    public int currHP;
    public int maxHP;
    public int enemyXP;

    public AudioClip damageSFX;
    public AudioClip deathSFX;

    void Start() {
        currHP = maxHP;
    }

    public void SubtractHP(int hpToSubtract) {
        if(currHP > 0){
            currHP-= hpToSubtract;
            this.gameObject.GetComponent<AudioSource>().PlayOneShot(damageSFX);
        } else {
            if(this.gameObject.tag == "Enemy") {
                GameObject.Find("Player(Clone)").GetComponent<PlayerLevelScript>().AddXP(
                (200*GameObject.Find("Player(Clone)").GetComponent<PlayerLevelScript>().currentLevel.levelNumber));
            } else if(this.gameObject.tag == "Boss") {
                GameObject.Find("Player(Clone)").GetComponent<PlayerLevelScript>().AddXP(enemyXP);
            }
            this.gameObject.GetComponent<AudioSource>().PlayOneShot(deathSFX);
            Destroy(this.gameObject);
        }
    }
}
