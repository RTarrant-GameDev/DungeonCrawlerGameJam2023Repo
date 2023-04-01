using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollisionDetection : MonoBehaviour {
    public Ray rayLeft;
    public Ray rayRight;
    public Ray rayForward;
    public Ray rayBackward;
    public bool canMoveLeft;
    public bool canMoveRight;
    public bool canMoveForward;
    public bool canMoveBackward;

    public Vector3 currDirection;

    void Awake() {
        canMoveLeft = true;
        canMoveRight = true;
        canMoveForward = true;
        canMoveBackward = true;
    }

    void FixedUpdate() {
        currDirection = this.gameObject.transform.position;

        rayLeft = new Ray(currDirection, -transform.right);
        rayRight = new Ray(currDirection, transform.right);
        rayForward = new Ray(currDirection, transform.forward);
        rayBackward = new Ray(currDirection, -transform.forward);

        Debug.DrawRay(rayLeft.origin, rayLeft.direction*2.0f, Color.black);
        Debug.DrawRay(rayForward.origin, rayForward.direction*2.0f, Color.black);
        Debug.DrawRay(rayRight.origin, rayRight.direction*2.0f, Color.black);
        Debug.DrawRay(rayBackward.origin, rayBackward.direction*2.0f, Color.black);
    }

    void Update() {
        canMoveLeft = RayHit(rayLeft);
        canMoveForward = RayHit(rayForward);
        canMoveRight = RayHit(rayRight);
        canMoveBackward = RayHit(rayBackward);
    }

    bool RayHit(Ray ray) {
        RaycastHit other = new RaycastHit();
        if((Physics.Raycast(ray.origin, ray.direction, out other) && other.distance <= 1.0f) && (other.transform.gameObject.tag != "Exit")) {
            return false;
        } else {
            return true;
        }
    }
}
