using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class loadScreen : MonoBehaviour {
    public TextMeshProUGUI storyText;

    public void DisplayLoadingText(string textToDisplay) {
        storyText.SetText(textToDisplay);
    }

    public void StartLevel() {
        GameManagerScript.Instance.GenerateLevel(GameManagerScript.Instance.currentLevel);
    }
}
