using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEndpointScript : MonoBehaviour {
    void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Exit") {
            GameManagerScript.Instance.SavePlayerData();
            GameManagerScript.Instance.NextLevel();
        }
    }
}
