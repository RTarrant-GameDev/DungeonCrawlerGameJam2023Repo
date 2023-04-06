using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    public int currHP;
    public int maxHP;

    void Start() {
        if(this.gameObject.tag == "Enemy") { //only scale enemy HP with player
            maxHP = GameManagerScript.Instance.currentPlayerLevel.newLevelHP;
        }
        
        currHP = maxHP;
    }

    public void SubtractHP(int hpToSubtract) {
        if(currHP > 0){
            currHP-= hpToSubtract;
        } else {
            GameObject.Find("Player(Clone)").GetComponent<PlayerLevelScript>().AddXP(
                (200*GameObject.Find("Player(Clone)").GetComponent<PlayerLevelScript>().currentLevel.levelNumber));
            Destroy(this.gameObject);
        }
    }
}
