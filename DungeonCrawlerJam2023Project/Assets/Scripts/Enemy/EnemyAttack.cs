using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
    public Transform player;
    public float attackRange = 1.0f;
    public float attackCooldown = 2.5f;
    public LayerMask playerLayerMask;
    public LayerMask obstacleLayerMask;

    private float lastAttackTime = 0.0f;
    private bool playerInRange = false;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.Find("Player(Clone)").transform;
    }

    // Update is called once per frame
    void Update() {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, player.position - transform.position, out hit, Mathf.Infinity, playerLayerMask)) {
            if (hit.distance <= attackRange && !Physics.Linecast(transform.position, player.position, obstacleLayerMask)) {
                playerInRange = true;
            } else {
                playerInRange = false;
            }
        } else {
            playerInRange = false;
        }

        if (playerInRange && Time.time - lastAttackTime >= attackCooldown){
            Attack();
        }
    }

    void Attack() {
        player.gameObject.GetComponent<PlayerHealth>().SubtractHP(Mathf.RoundToInt(player.gameObject.GetComponent<PlayerHealth>().maxHealth * .15f)); //chip off 15% of player's health for each attack
        lastAttackTime = Time.time;
    }
}
