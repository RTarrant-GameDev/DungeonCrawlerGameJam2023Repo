using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMagickaUI : MonoBehaviour {
    public Slider mpMeter;

    // Update is called once per frame
    void Update() {
        mpMeter.maxValue = GameObject.Find("Player(Clone)").GetComponent<PlayerMagicka>().maxMagicka;
        mpMeter.value = GameObject.Find("Player(Clone)").GetComponent<PlayerMagicka>().currMagicka;
    }
}
