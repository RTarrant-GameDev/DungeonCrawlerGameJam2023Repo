using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoadManager : MonoBehaviour {
    public void getSaveData() {
        //if current save data exists, load it
        if(File.Exists(Application.persistentDataPath+"/SaveData.dat")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/SaveData.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);

            GameObject.Find("GameManager").GetComponent<GameManagerScript>().GenerateLevel(data.currentLevel);

            //run function to set level, stats, and XP count here
            GameObject.Find("Player(Clone)").GetComponent<PlayerLevelScript>().setLevelValuesFromSave(data.savedLevelNumber, data.savedXPCount);
            GameObject.Find("Player(Clone)").transform.position = data.savedPlayerPos;
            GameObject.Find("Player(Clone)").transform.rotation = data.savedPlayerRotation;

            bf.Serialize(file, data);
            file.Close();
            Debug.Log("Save data loaded.");
        } else { //create default save data
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/SaveData.dat");
            SaveData data = new SaveData();

            data.savedLevelNumber = GameObject.Find("Player(Clone)").GetComponent<PlayerLevelScript>().currentLevel.levelNumber;
            data.savedXPCount = GameObject.Find("Player(Clone)").GetComponent<PlayerLevelScript>().currXP;
            //set defaults in save data file

            bf.Serialize(file, data);
            file.Close();

            Debug.Log("Set default data and created save data file.");
        }
    }
}
