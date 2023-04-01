using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileReader : MonoBehaviour {
    public static int rowNum, colNum;
    public static void ReadFile(string filePath) {
        string text = File.ReadAllText(filePath);

        int row = 0;
        int col = 0;
        foreach (char c in text) {
            if (c == '\n') {
                //at new line, increment row and reset column
                row++;
                col = 0;
            } else {
                // Display row, column and character to console while getting next character
                Debug.LogFormat("Character '{0}' at row {1}, column {2}", c, row, col);
                col++;
            }
        }
    }
}
