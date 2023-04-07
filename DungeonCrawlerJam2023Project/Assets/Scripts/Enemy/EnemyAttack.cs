using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
    public int attackDmg;
    public Transform player;
    public float attackRange = 1.0f;
    public float attackCooldown = 2.5f;
    public LayerMask playerLayerMask;
    public LayerMask obstacleLayerMask;
    public AudioClip attackSFX;
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
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(attackSFX);
        if(this.gameObject.tag == "Enemy") {
            player.gameObject.GetComponent<PlayerHealth>().SubtractHP(Mathf.RoundToInt(player.gameObject.GetComponent<PlayerHealth>().maxHealth * .125f)); //chip off 12.5% of player's health for each attack
        } else {
            player.gameObject.GetComponent<PlayerHealth>().SubtractHP(attackDmg);
        }

        lastAttackTime = Time.time;
    }
}
