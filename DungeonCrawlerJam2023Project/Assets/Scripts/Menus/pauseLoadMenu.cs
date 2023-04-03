using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;

public class pauseLoadMenu : MonoBehaviour {
    public GameObject saveSlotPrefab;
    public Transform saveSlotsPanel;
    // Start is called before the first frame update
    void OnEnable() {
        LoadSaveSlots();
    }

    void LoadSaveSlots() {
        string[] saveFiles = Directory.GetFiles(Application.persistentDataPath, "*.dat");
        foreach (string saveFile in saveFiles) {
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

    void LoadGame(int saveSlot) {
        SaveData data = SaveLoadManager.Instance.LoadGame(saveSlot);
        if (data != null) {
            StateManager.InstanceRef.SwitchState(new PlayState(StateManager.InstanceRef));
        }
    }
}
