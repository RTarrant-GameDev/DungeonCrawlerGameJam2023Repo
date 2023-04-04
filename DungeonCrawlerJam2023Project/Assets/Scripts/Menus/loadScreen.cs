using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class loadScreen : MonoBehaviour {
    public TextMeshProUGUI storyText;

    public void DisplayLoadingText(string textToDisplay) {
        storyText.text = textToDisplay;
    }

    public void StartLevel() {
        StateManager.InstanceRef.SwitchState(new PlayState(StateManager.InstanceRef));
    }
}
