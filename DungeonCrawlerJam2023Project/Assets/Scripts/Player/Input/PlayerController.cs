using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public bool smoothTransition = false;
    public float transitionSpeed = 10.0f;
    public float transitionRotationSpeed = 500.0f;

    Vector3 targetGridPos;
    Vector3 currentGridPos;
    Vector3 targetRotation;

    private void Start() {
        targetGridPos = Vector3Int.RoundToInt(transform.position);
    }

    private void FixedUpdate() {
        MovePlayer();
    }

    void MovePlayer() {
        if(true) {
            currentGridPos = targetGridPos;
            Vector3 targetPos = targetGridPos;

            if(targetRotation.y > 270 && targetRotation.y < 361.0f) targetRotation.y = 0.0f; 
            if(targetRotation.y < 0.0f) targetRotation.y = 270.0f;

            if(!smoothTransition) { //if teleporting from grid to grid
                transform.position = targetPos;
                transform.rotation = Quaternion.Euler(targetRotation);
            } else { //if transitioning smoothly from gridpoint to gridpoint
                transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * transitionSpeed);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetRotation), Time.deltaTime * transitionRotationSpeed);
            }

        } else {
            targetGridPos = currentGridPos; //set target grid position to current position if can't move further
        }
    }

    public void RotateLeft() { if (atRest) targetRotation -= Vector3.up * 90.0f; }
    public void RotateRight() { if (atRest) targetRotation += Vector3.up * 90.0f; }
    public void MoveFoward() { if (atRest) targetGridPos += transform.forward; }
    public void MoveBackward() { if (atRest) targetGridPos -= transform.forward; }
    public void MoveLeft() { if (atRest) targetGridPos -= transform.right; }
    public void MoveRight() { if (atRest) targetGridPos += transform.right; }

    bool atRest {
        get {
            if((Vector3.Distance(transform.position, targetGridPos) < 0.05f) && 
                (Vector3.Distance(transform.eulerAngles, targetRotation) < 0.05f))
                    return true;
            else 
                return false;
        }
    }
}
