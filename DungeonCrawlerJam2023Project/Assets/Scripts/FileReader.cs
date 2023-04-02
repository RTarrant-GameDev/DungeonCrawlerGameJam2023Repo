using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileReader : MonoBehaviour {
    public void ReadFile(string filePath) {
        string text = File.ReadAllText(filePath);

        int row = 0;
        int col = 0;
        foreach (char c in text) {
            if (c == '\n') {
                //at new line, increment row and reset column
                row++;
                col = 0;
            } else {
                this.gameObject.GetComponentInParent<GameManagerScript>().PlaceObject(c, row, col);
                col++;
            }
        }
    }
}
