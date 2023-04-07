using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerLevelUpUI : MonoBehaviour {
    public TextMeshProUGUI levelText;
    public Slider xpMeter;
    public GameObject background;

    void Update() {
        levelText.text = "Level " + GameObject.Find("Player(Clone)").GetComponent<PlayerLevelScript>().currentLevel.levelNumber;
        if(GameObject.Find("Player(Clone)").GetComponent<PlayerLevelScript>().currentLevel.levelNumber < GameObject.Find("Player(Clone)").GetComponent<PlayerLevelScript>().levels.Length) {
             xpMeter.maxValue = GameObject.Find("Player(Clone)").GetComponent<PlayerLevelScript>().levels[GameObject.Find("Player(Clone)").GetComponent<PlayerLevelScript>().currentLevel.levelNumber].xpToReachLevel;
        }
        xpMeter.value = GameObject.Find("Player(Clone)").GetComponent<PlayerLevelScript>().currXP;
        background.GetComponent<Image>().sprite = GameObject.Find("Player(Clone)").GetComponent<PlayerLevelScript>().currentLevel.levelMeterCustomSprite;
    }
}
