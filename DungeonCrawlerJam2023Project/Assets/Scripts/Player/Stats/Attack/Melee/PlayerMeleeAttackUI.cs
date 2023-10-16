using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttackUI : MonoBehaviour {
    public void AttackButtonFunction() {
        GameObject.Find("Player(Clone)").GetComponent<PlayerMeleeAttack>().AttackCheck();
    }
}
