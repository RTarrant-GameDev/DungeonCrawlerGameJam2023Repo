using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballLaunchScript : MonoBehaviour {
    public GameObject projectile;
    public float launchVelocity = 700.0f;

    public void ShootFireball() {
        GameObject fireBall = Instantiate(projectile, transform.position, transform.rotation);

        fireBall.GetComponent<Rigidbody>().AddForce(fireBall.transform.forward * launchVelocity);
    }
}
