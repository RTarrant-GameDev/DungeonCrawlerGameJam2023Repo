using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttackCooldownScript : MonoBehaviour {
    public Slider cooldownMeter;

    void Update() {
        if(cooldownMeter.value == cooldownMeter.maxValue) {
            cooldownMeter.gameObject.SetActive(false);
        } else {
            cooldownMeter.gameObject.SetActive(true);
        }
        cooldownMeter.maxValue = GameObject.Find("Player(Clone)").GetComponent<PlayerAttack>().cooldownTime;
        cooldownMeter.value = GameObject.Find("Player(Clone)").GetComponent<PlayerAttack>().CooldownProgress();
    }
}
