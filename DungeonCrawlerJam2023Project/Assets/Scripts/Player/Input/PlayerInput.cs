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
        if(Input.GetKeyDown(moveForward) && collisionDetection.canMoveForward) controller.MoveFoward();
        if(Input.GetKeyDown(moveBackward) && collisionDetection.canMoveBackward) controller.MoveBackward();
        if(Input.GetKeyDown(moveLeft) && collisionDetection.canMoveLeft) controller.MoveLeft();
        if(Input.GetKeyDown(moveRight) && collisionDetection.canMoveRight) controller.MoveRight();
        if(Input.GetKeyDown(rotateLeft)) controller.RotateLeft();
        if(Input.GetKeyDown(rotateRight)) controller.RotateRight();

        if(Input.GetKeyDown(KeyCode.Escape)) {
            StateManager.InstanceRef.GameState = gameState.Pause;
        }
    }
}
