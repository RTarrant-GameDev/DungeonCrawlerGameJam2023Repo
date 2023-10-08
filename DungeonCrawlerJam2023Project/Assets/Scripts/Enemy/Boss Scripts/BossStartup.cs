using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStartup : MonoBehaviour {
    public AnimatorOverrideController overrideController;

    public void Init(Boss bossType){
        overrideController = bossType.overrideController;
        this.gameObject.GetComponent<Animator>().runtimeAnimatorController = bossType.overrideController;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = bossType.enemySprite;
        this.gameObject.GetComponent<BossHealth>().maxHP = bossType.enemyHP;
        this.gameObject.GetComponent<BossHealth>().enemyXP = bossType.enemyXP;
        this.gameObject.GetComponent<BossAttack>().attackDmg = bossType.enemyAttack;
        this.gameObject.GetComponent<BossAttack>().attackAnim = overrideController["BossAttack"];
        this.gameObject.GetComponent<BossAttack>().idleAnim = overrideController["BossIdle"];
    }
}
