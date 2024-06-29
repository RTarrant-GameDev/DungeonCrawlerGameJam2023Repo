using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : WallCollisionDetection {
    public GameObject player;
    public bool playerDetected;

    void Awake() {
        canMoveLeft = true;
        canMoveRight = true;
        canMoveForward = true;
        canMoveBackward = true;
    }

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate() {
        currDirection = this.gameObject.transform.position;

        rayLeft = new Ray(currDirection, -transform.right);
        rayRight = new Ray(currDirection, transform.right);
        rayForward = new Ray(currDirection, transform.forward);
        rayBackward = new Ray(currDirection, -transform.forward);
    }

    void Update() {
        playerDetected = PlayerSpotted(rayForward) || PlayerSpotted(rayRight) || PlayerSpotted(rayBackward) || PlayerSpotted(rayLeft);
        canMoveLeft = RayHit(rayLeft);
        canMoveForward = RayHit(rayForward);
        canMoveRight = RayHit(rayRight);
        canMoveBackward = RayHit(rayBackward);
    }

    public bool PlayerSpotted(Ray ray) {
        RaycastHit other = new RaycastHit();
        if(Physics.Raycast(ray.origin, ray.direction, out other) && other.transform.gameObject == player) {
            return true; //if player spotted return true
        } else {
            return false;
        }
    }

    public bool ValidGameObject(GameObject gObj){
        if(gObj == null) {
            return false;
        }

        bool isExit = gObj.CompareTag("Exit");
        bool isCollectible = gObj.CompareTag("Collectible");

        return isExit || isCollectible;
    }

    public bool RayHit(Ray ray) {
        RaycastHit other = new RaycastHit();
        if(Physics.Raycast(ray.origin, ray.direction, out other) && other.distance <= 1.0f && !ValidGameObject(other.transform.gameObject)) {
            return false;
        } else {
            return true;
        }
    }
}
