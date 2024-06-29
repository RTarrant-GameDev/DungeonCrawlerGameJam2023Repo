using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    public int currHP;
    public int maxHP;
    public int enemyXP;

    public bool KilledByMagic;

    public AudioClip damageSFX;
    public AudioClip deathSFX;

    void Start() {
        currHP = maxHP;
    }

    void Update()
    {
        if (currHP <= 0)
        {
            if (this.gameObject.tag == "Enemy")
            {
                if (KilledByMagic == false)
                {
                    Debug.Log("Enemy attacked with melee");
                    GameObject.Find("Player(Clone)").GetComponent<PlayerLevelScript>().AddXP(
                    (200 * GameObject.Find("Player(Clone)").GetComponent<PlayerLevelScript>().currentLevel.levelNumber));
                }
                else if (KilledByMagic == true)
                {
                    Debug.Log("Enemy attacked with magic");
                }
            }
            else if (this.gameObject.tag == "Boss")
            {
                GameObject.Find("Player(Clone)").GetComponent<PlayerLevelScript>().AddXP(enemyXP);
            }
            GameObject.Find("Player(Clone)").GetComponent<PlayerMagicka>().AddMP(enemyXP);
            this.gameObject.GetComponent<AudioSource>().PlayOneShot(deathSFX);
            Destroy(this.gameObject);
        }
    }

    public void SubtractHP(int hpToSubtract, bool GiveXP) {

        Debug.Log($"Attacked by Magic: {!GiveXP}");
        
        currHP-= hpToSubtract;
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(damageSFX);

        KilledByMagic = !GiveXP; //set to true if GiveXP is false, and vice versa
    }
}
