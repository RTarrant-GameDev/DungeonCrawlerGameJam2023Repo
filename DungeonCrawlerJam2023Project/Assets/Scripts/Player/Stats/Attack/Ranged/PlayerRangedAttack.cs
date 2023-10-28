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
    public GameObject projectileOrigin;

    void Start() {
        dmgNumber = this.gameObject.GetComponent<PlayerLevelScript>().currentLevel.newLevelDmg;
    }

    public void AttackCheck() {
        if(this.gameObject.GetComponent<PlayerMagicka>().currMagicka > 0){
            FireAtEnemy();
        }
    }

    public void FireAtEnemy(){
        float currentTime = Time.time;
        if(CooldownProgress() >= cooldownTime) {
            StartCoroutine(FireballAttack());
            this.gameObject.GetComponent<PlayerMagicka>().SubtractMP(25);
            lastAttackTime = currentTime;
        }
    }

    public float CooldownProgress() {
        float currentTime = Time.time;
        return currentTime - lastAttackTime;
    }

    public IEnumerator FireballAttack() {
        animations[0].wrapMode = WrapMode.Once;
        swordObj.GetComponent<Animator>().Play(animations[0].name, -1, 0f);
        yield return new WaitForSeconds(0.3f);
        projectileOrigin.GetComponent<FireballLaunchScript>().ShootFireball();
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(attackSFX);
    }
}
