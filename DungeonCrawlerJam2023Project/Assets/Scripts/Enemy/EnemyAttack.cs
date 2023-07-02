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
    public AnimationClip attackAnim;
    public AnimationClip idleAnim;
    public AudioClip attackSFX;
    private float lastAttackTime = 0.0f;
    private bool playerInRange = false;
    private bool isAttacking = false;

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

        if (playerInRange && Time.time - lastAttackTime >= attackCooldown && !isAttacking){
            StartCoroutine(Attack());
        }
    }

    public IEnumerator Attack() {
        isAttacking = true;
        attackAnim.wrapMode = WrapMode.Once;
        this.gameObject.GetComponent<Animator>().Play(attackAnim.name, -1, 0f);
        yield return new WaitForSeconds(attackAnim.length);
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(attackSFX);
        player.gameObject.GetComponent<PlayerHealth>().SubtractHP(attackDmg);
        this.gameObject.GetComponent<Animator>().Play(idleAnim.name, -1, 0f);

        isAttacking = false;
        lastAttackTime = Time.time;
    }
}
