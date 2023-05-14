using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackUI : MonoBehaviour {
    public void AttackButtonFunction() {
        GameObject.Find("Player(Clone)").GetComponent<PlayerAttack>().AttackCheck();
    }
}
