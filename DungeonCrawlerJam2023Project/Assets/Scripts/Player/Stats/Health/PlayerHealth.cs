using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    public int maxHealth;
    public int currHealth;
    
    void Start() {
        maxHealth = this.gameObject.GetComponent<PlayerLevelScript>().currentLevel.newLevelHP;
        currHealth = maxHealth;
    }

    // Update is called once per frame
    public void AddHP(int hpToAdd) {
        if(currHealth < maxHealth) {
            currHealth += hpToAdd;
        }
    }

    public void SubtractHP(int hpToSubtract) {
        if (currHealth > 0) {
            currHealth -= hpToSubtract;
        } else {
            //Game Over Condition
        }
    }

    public void SetHealthPostLevelUp(int healthValueToSet) {
        maxHealth = healthValueToSet;
        currHealth = maxHealth; //resets HP upon level-up
    }
}
