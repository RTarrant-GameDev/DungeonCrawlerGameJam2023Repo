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

    void Update() {
        if(this.currHealth <= 0) {
            GameManagerScript.Instance.SavePlayerData();
            StateManager.InstanceRef.SwitchState(new StartState(StateManager.InstanceRef)); 
            StateManager.InstanceRef.GameState = gameState.GameOver;
        } else if (currHealth >= maxHealth) {
            currHealth = maxHealth;
        }
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
        }
    }

    public void SetHealthPostLevelUp(int healthValueToSet) {
        maxHealth = healthValueToSet;
        currHealth = maxHealth; //resets HP upon level-up
    }
}
