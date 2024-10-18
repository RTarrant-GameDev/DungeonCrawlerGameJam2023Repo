using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour {
    void Start() {
        Destroy(this.gameObject, 2.0f);
    }
    void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Enemy") {
            if(other.gameObject.name=="BossPrefab(Clone)"){
                other.gameObject.GetComponent<BossHealth>().SubtractHP(GameObject.Find("Player(Clone)").GetComponent<PlayerRangedAttack>().dmgNumber);
            } else {
                other.gameObject.GetComponent<EnemyHealth>().SubtractHP(GameObject.Find("Player(Clone)").GetComponent<PlayerRangedAttack>().dmgNumber, false);
            }
            this.gameObject.SetActive(false);
        }
    }
}
