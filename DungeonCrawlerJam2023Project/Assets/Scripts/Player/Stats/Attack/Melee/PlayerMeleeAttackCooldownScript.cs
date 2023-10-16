using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMeleeAttackCooldownScript : MonoBehaviour {
    public Slider cooldownMeter;

    void Update() {
        if(cooldownMeter.value == cooldownMeter.maxValue) {
            cooldownMeter.gameObject.SetActive(false);
            GameObject.Find("meleeAttackButton").GetComponent<Button>().interactable = true;
        } else {
            cooldownMeter.gameObject.SetActive(true);
            GameObject.Find("meleeAttackButton").GetComponent<Button>().interactable = false;
        }
        cooldownMeter.maxValue = GameObject.Find("Player(Clone)").GetComponent<PlayerMeleeAttack>().cooldownTime;
        cooldownMeter.value = GameObject.Find("Player(Clone)").GetComponent<PlayerMeleeAttack>().CooldownProgress();
    }
}
