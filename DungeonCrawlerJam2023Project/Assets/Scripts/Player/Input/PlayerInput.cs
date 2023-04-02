using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(WallCollisionDetection))]
public class PlayerInput : MonoBehaviour {

    public KeyCode moveForward = KeyCode.W;
    public KeyCode moveBackward = KeyCode.S;
    public KeyCode moveLeft = KeyCode.A;
    public KeyCode moveRight = KeyCode.D;
    public KeyCode rotateLeft = KeyCode.Q;
    public KeyCode rotateRight = KeyCode.E;

    PlayerController controller;
    WallCollisionDetection collisionDetection;

    void Awake() {
        controller = GetComponent<PlayerController>();
        collisionDetection = GetComponent<WallCollisionDetection>();
    }

    void Update() {
        if(Input.GetKeyUp(moveForward) && collisionDetection.canMoveForward) controller.MoveFoward();
        if(Input.GetKeyUp(moveBackward) && collisionDetection.canMoveBackward) controller.MoveBackward();
        if(Input.GetKeyUp(moveLeft) && collisionDetection.canMoveLeft) controller.MoveLeft();
        if(Input.GetKeyUp(moveRight) && collisionDetection.canMoveRight) controller.MoveRight();
        if(Input.GetKeyUp(rotateLeft)) controller.RotateLeft();
        if(Input.GetKeyUp(rotateRight)) controller.RotateRight();

        if(Input.GetMouseButtonDown(0)) { 
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out raycastHit, 100f)) {
                if(raycastHit.transform != null) {
                    CurrentClickedGameObject(raycastHit.transform.gameObject);
                }
            }
        }
    }

    public void CurrentClickedGameObject (GameObject gameObject) {
        if (gameObject.tag == "GateSwitch") {
            //Insert code here
        }
    }
}
