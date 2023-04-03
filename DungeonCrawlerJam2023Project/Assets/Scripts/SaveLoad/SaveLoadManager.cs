using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoadManager : MonoBehaviour {

    public static SaveLoadManager Instance { get; private set; }

    void Awake(){
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public void NewGame() {
        SaveData data = new SaveData();
        data.currentLevel = GameManagerScript.Instance.levels[0];
        data.savedPlayerPos = GameObject.Find("Player(Clone)").transform.position;
        data.savedLevelNumber = 1;
        data.savedXPCount = 0;
        data.savedPlayerRotation = GameObject.Find("Player(Clone)").transform.rotation; 
        SaveGame(1, data);
    }

    public SaveData LoadGame(int slot) {
        BinaryFormatter bf = new BinaryFormatter();
        string savePath = GetSavePath(slot);
        //if current save data exists, load it
        if(File.Exists(savePath)) {
            FileStream file = File.Open(savePath, FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);

            GameObject.Find("GameManager").GetComponent<GameManagerScript>().GenerateSpawner();

            //run function to set level, stats, and XP count here
            GameObject.Find("Player(Clone)").GetComponent<PlayerLevelScript>().setLevelValuesFromSave(data.savedLevelNumber, data.savedXPCount);
            GameObject.Find("Player(Clone)").transform.position = data.savedPlayerPos;
            GameObject.Find("Player(Clone)").transform.rotation = data.savedPlayerRotation;

            bf.Serialize(file, data);
            file.Close();
            Debug.Log("Save data loaded.");
            return data;
        } else {
            Debug.LogError("Save file not found at " + savePath);
            return default(SaveData);
        }
    }

    public void SaveGame(int slot, SaveData data) {
        BinaryFormatter formatter = new BinaryFormatter();
        string savePath = GetSavePath(slot);
        FileStream stream = new FileStream(savePath, FileMode.Create);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    private string GetSavePath(int slot) {
        return Application.persistentDataPath + "/save" + slot.ToString() + ".dat";
    }
}
