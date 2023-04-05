using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour {
    public Slider hpMeter;

    // Update is called once per frame
    void Update() {
        hpMeter.maxValue = GameObject.Find("Player(Clone)").GetComponent<PlayerHealth>().maxHealth;
        hpMeter.value = GameObject.Find("Player(Clone)").GetComponent<PlayerHealth>().currHealth;
    }
}
