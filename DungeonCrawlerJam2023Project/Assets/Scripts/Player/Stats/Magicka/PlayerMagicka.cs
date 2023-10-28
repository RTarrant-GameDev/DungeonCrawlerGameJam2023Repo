using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagicka: MonoBehaviour {
    public int maxMagicka;
    public int currMagicka;
    
    void Start() {
        maxMagicka = this.gameObject.GetComponent<PlayerLevelScript>().currentLevel.newLevelHP;
        currMagicka = maxMagicka;
    }

    void Update() {
        if (currMagicka >= maxMagicka) {
            currMagicka = maxMagicka;
        }
    }

    // Update is called once per frame
    public void AddMP(int mpToAdd) {
        if(currMagicka < maxMagicka) {
            currMagicka += mpToAdd;
        }
    }

    public void SubtractMP(int mpToSubtract) {
        if (currMagicka > 0) {
            currMagicka -= mpToSubtract;
        }
    }

    public void SetMagickaPostLevelUp(int magickaValueToSet) {
        maxMagicka = magickaValueToSet;
        currMagicka = maxMagicka; //resets Magicka upon level-up
    }
}
