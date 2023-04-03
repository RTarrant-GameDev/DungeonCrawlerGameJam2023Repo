using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseSaveMenu : MonoBehaviour {
    public Transform saveSlotsParent;
    int slotNum = 0;
    // Start is called before the first frame update
    void Start() {
        foreach (Transform child in saveSlotsParent) {
            slotNum++;
            Button button = child.gameObject.AddComponent<Button>();
            button.onClick.AddListener(delegate { this.gameObject.GetComponent<pauseMenu>().saveGame(slotNum); });
        }
    }
}
