using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour {
    public int attackDmg;
    public Transform player;
    public float attackRange = 1.25f;
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
        if (Vector3.Distance(player.transform.position, this.gameObject.transform.position) 
        <= attackRange && this.gameObject.GetComponent<BossCollision>().playerDetected) {
            playerInRange = true;
        } else {
            playerInRange = false;
        }

        if (playerInRange) {
            Vector3 direction = player.transform.position - this.gameObject.transform.position;
            this.gameObject.transform.rotation = Quaternion.LookRotation(direction);
            if(Time.time - lastAttackTime >= attackCooldown && !isAttacking) {
                StartCoroutine(Attack());
            }
        }
    }

    public IEnumerator Attack() {
        isAttacking = true;
        attackAnim.wrapMode = WrapMode.Once;
        this.gameObject.GetComponent<Animator>().Play("BossAttack", -1, 0f);
        yield return new WaitForSeconds(attackAnim.length);
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(attackSFX);
        player.gameObject.GetComponent<PlayerHealth>().SubtractHP(attackDmg);
        this.gameObject.GetComponent<Animator>().Play("BossIdle", -1, 0f);

        isAttacking = false;
        lastAttackTime = Time.time;
    }
}
