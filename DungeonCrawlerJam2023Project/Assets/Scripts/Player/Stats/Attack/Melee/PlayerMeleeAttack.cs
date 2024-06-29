using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour {
    public int dmgNumber;
    public float cooldownTime;
    private float lastAttackTime;
    public AudioClip attackSFX;
    public GameObject swordObj;
    public AnimationClip[] animations;

    void Start() {
        dmgNumber = this.gameObject.GetComponent<PlayerLevelScript>().currentLevel.newLevelDmg;
    }

    public void AttackCheck() {
        RaycastHit raycastHit;
        Ray ray = new Ray(this.gameObject.transform.position, this.gameObject.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * 0.2f, Color.black);

        if (Physics.Raycast(ray, out raycastHit, 100f)) {
            if(raycastHit.transform != null) {
                CurrentClickedGameObject(raycastHit.transform.gameObject);
            }
        }
    }

    void CurrentClickedGameObject (GameObject gameObject) {
        if (gameObject.tag == "Enemy" && Vector3.Distance(gameObject.transform.position, this.gameObject.transform.position) <= 1.5f) {
            AttackEnemy(gameObject);
        } else {
            Debug.Log("Cannot attack because player is not looking at enemy");
        }
    }

    public void AttackEnemy(GameObject enemy) {
        float currentTime = Time.time;
        if(CooldownProgress() >= cooldownTime) {
            StartCoroutine(SwordAttack());
            if(enemy.name=="BossPrefab(Clone)"){
                enemy.GetComponent<BossHealth>().SubtractHP(dmgNumber);
            } else {
                enemy.GetComponent<EnemyHealth>().SubtractHP(dmgNumber, true);
            }
            lastAttackTime = currentTime;
        }
    }

    public float CooldownProgress() {
        float currentTime = Time.time;
        return currentTime - lastAttackTime;
    }

    public IEnumerator SwordAttack() {
        animations[0].wrapMode = WrapMode.Once;
        swordObj.GetComponent<Animator>().Play(animations[0].name, -1, 0f);
        yield return new WaitForSeconds(0.3f);
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(attackSFX);
    }
}
