using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    public float detectionDistance = 5.0f; // The distance at which the enemy detects the player
    public float movementSpeed = 3.0f;
    public float rotationSpeed = 90.0f;

    private Transform player;
    private bool isPlayerDetected = false;
    private bool isMovingForward = true;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update() {
        if (!isPlayerDetected) {
            // Check if the player is within detectionDistance
            if (Vector3.Distance(transform.position, player.position) <= detectionDistance) {
                // Check if the player is in front of the enemy
                Vector3 directionToPlayer = player.position - transform.position;
                if (Vector3.Dot(transform.forward, directionToPlayer.normalized) > 0.5f)
                {
                    isPlayerDetected = true;
                }
            }
        } else {
            MoveTowardsPlayer();
        }
    }

    private void MoveTowardsPlayer() {
        if (isMovingForward) {
            // Move forward towards the player
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        }

        // Check for collisions
        if (!this.gameObject.GetComponent<EnemyCollision>().canMoveForward) {
            // If there's a wall in front, turn around
            isMovingForward = false;
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        } else {
            // If there's no wall, resume moving forward
            isMovingForward = true;
        }

        // Check if the player is still within detectionDistance
        if (Vector3.Distance(transform.position, player.position) > detectionDistance) {
            isPlayerDetected = false;
        }
    }
}
