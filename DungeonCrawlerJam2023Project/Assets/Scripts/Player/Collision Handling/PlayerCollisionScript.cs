using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionScript : MonoBehaviour {
    void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Exit") {
            GameManagerScript.Instance.SavePlayerData();
            GameManagerScript.Instance.NextLevel();
        } else if (other.gameObject.tag == "Collectible") {
            this.gameObject.GetComponent<PlayerHealth>().AddHP(Mathf.RoundToInt(this.gameObject.GetComponent<PlayerHealth>().maxHealth * .35f));
        }
    }
}
