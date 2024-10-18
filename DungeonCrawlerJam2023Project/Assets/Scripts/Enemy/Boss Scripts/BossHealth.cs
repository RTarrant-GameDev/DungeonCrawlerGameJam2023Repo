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

    void Update()
    {
        if (currHP <= 0)
        {
            GameObject.Find("Player(Clone)").GetComponent<PlayerMagicka>().AddMP(enemyXP);
            this.gameObject.GetComponent<AudioSource>().PlayOneShot(deathSFX);
            Destroy(this.gameObject);
        }
    }

    public void SubtractHP(int hpToSubtract) {
        currHP-= hpToSubtract;
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(damageSFX);
    }
}
