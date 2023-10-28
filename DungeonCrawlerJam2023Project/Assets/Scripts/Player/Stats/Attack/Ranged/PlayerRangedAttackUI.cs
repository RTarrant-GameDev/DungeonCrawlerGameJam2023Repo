using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangedAttackUI : MonoBehaviour {
    public void AttackButtonFunction() {
        GameObject.Find("Player(Clone)").GetComponent<PlayerRangedAttack>().AttackCheck();
    }
}
