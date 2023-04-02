using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;

public class loadGame : MonoBehaviour {
    public GameObject saveSlotPrefab;
    public Transform saveSlotsPanel;

    // Start is called before the first frame update
    void Start() {
        string[] saveFiles = Directory.GetFiles(Application.persistentDataPath, "*.dat");

        foreach(string saveFile in saveFiles) {
            GameObject saveSlot = Instantiate(saveSlotPrefab, saveSlotsPanel);
            int saveSlotNumber;
            if (int.TryParse(Path.GetFileNameWithoutExtension(saveFile), out saveSlotNumber)) {
                saveSlot.GetComponentInChildren<TextMeshProUGUI>().text = "Save " + saveSlotNumber.ToString();
                saveSlot.GetComponent<Button>().onClick.AddListener(() => LoadGame(saveSlotNumber));
            } else {
                Debug.LogWarning("Unable to parse save slot number from file: " + saveFile);
            }
        }
    }

    void LoadGame(int slot) {
        SaveData data = SaveLoadManager.Instance.LoadGame(slot);

        if(data != null) {
            // Add any other code here to transition to the game scene.
        }
    }

    public void Back() {
        this.gameObject.SetActive(false);
    }
}
