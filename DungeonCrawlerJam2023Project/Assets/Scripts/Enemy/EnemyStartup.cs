using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStartup : MonoBehaviour {
    public void Init(Enemy enemyType){
        this.gameObject.GetComponent<SpriteRenderer>().sprite = enemyType.enemySprite;
        this.gameObject.GetComponent<EnemyHealth>().maxHP = enemyType.enemyHP;
        this.gameObject.GetComponent<EnemyHealth>().enemyXP = enemyType.enemyXP;
        this.gameObject.GetComponent<EnemyAttack>().attackDmg = enemyType.enemyAttack;
        this.gameObject.GetComponent<EnemyAttack>().attackAnim = enemyType.attackAnim;
        
    }
}
