using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRangedAttackCooldownScript : MonoBehaviour {
    public Slider cooldownMeter;

    void Update() {
        if(cooldownMeter.value == cooldownMeter.maxValue) {
            cooldownMeter.gameObject.SetActive(false);
            GameObject.Find("rangedAttackButton").GetComponent<Button>().interactable = true;
        } else {
            cooldownMeter.gameObject.SetActive(true);
            GameObject.Find("rangedAttackButton").GetComponent<Button>().interactable = false;
        }
        // cooldownMeter.maxValue = GameObject.Find("Player(Clone)").GetComponent<PlayerRangedAttack>().cooldownTime;
        // cooldownMeter.value = GameObject.Find("Player(Clone)").GetComponent<PlayerRangedAttack>().CooldownProgress();
    }
}
