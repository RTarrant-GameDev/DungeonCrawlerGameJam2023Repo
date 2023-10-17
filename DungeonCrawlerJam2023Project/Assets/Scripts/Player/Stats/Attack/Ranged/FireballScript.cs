using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour {
    void Start() {
        Destroy(this.gameObject, 2.0f);
    }
    void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Enemy") {
            this.gameObject.SetActive(false);
        }
    }
}
