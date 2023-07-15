using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStartup : MonoBehaviour {
    public AnimatorOverrideController overrideController;

    public void Init(Enemy enemyType){
        overrideController = enemyType.overrideController;
        this.gameObject.GetComponent<Animator>().runtimeAnimatorController = enemyType.overrideController;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = enemyType.enemySprite;
        this.gameObject.GetComponent<EnemyHealth>().maxHP = enemyType.enemyHP;
        this.gameObject.GetComponent<EnemyHealth>().enemyXP = enemyType.enemyXP;
        this.gameObject.GetComponent<EnemyAttack>().attackDmg = enemyType.enemyAttack;
        this.gameObject.GetComponent<EnemyAttack>().attackAnim = overrideController["enemyAttack"];
        this.gameObject.GetComponent<EnemyAttack>().idleAnim = overrideController["enemyIdle"];
    }
}
