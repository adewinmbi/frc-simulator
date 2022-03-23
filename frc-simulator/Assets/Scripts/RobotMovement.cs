using System.Collections.Generic;
using UnityEngine;

// Reused from scream jam
public class RobotMovement : MonoBehaviour {

    private Rigidbody2D rb2d;

    [SerializeField]
    private Vector2 movementSpeed = new Vector2(2, 2);
    [SerializeField]
    private float slowDownFactor = 0.75f;
    [SerializeField]
    private float stopThreshold = 0.01f;

    private readonly Dictionary<KeyCode, Vector2> inputPairs = new Dictionary<KeyCode, Vector2>() {
        {KeyCode.W, Vector2.up},
        {KeyCode.S, Vector2.down},
        {KeyCode.A, Vector2.left},
        {KeyCode.D, Vector2.right},
        {KeyCode.UpArrow, Vector2.up},
        {KeyCode.DownArrow, Vector2.down},
        {KeyCode.LeftArrow, Vector2.left},
        {KeyCode.RightArrow, Vector2.right}
    };
    
    private void Start() {
        // Initialize rigid body 2d
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        rb2d.freezeRotation = true;
    }

    // Update is called once per frame
    private void FixedUpdate() {
        Vector2 movementDirection = Vector2.zero;

        // Get directions that the player is holding down
        foreach (KeyCode k in inputPairs.Keys) {
            if (Input.GetKey(k)) {
                movementDirection += inputPairs[k];
            }
        }

        // Make sure holding multiple of the same key doesn't increase speed
        if (movementDirection.x > 1) {
            movementDirection.x = 1;
        } else if (movementDirection.x < -1) {
            movementDirection.x = -1;
        }
        if (movementDirection.y > 1) {
            movementDirection.y = 1;
        } else if (movementDirection.y < -1) {
            movementDirection.y = -1;
        }
        
        // Set velocity to direction multiplied by speed
        if (movementDirection != Vector2.zero) {
            movementDirection.Scale(movementSpeed);
            rb2d.velocity = movementDirection;
        } else {
            // If the speed is not below the threshold, slow down the player
            if (Mathf.Abs(rb2d.velocity.x) > stopThreshold || Mathf.Abs(rb2d.velocity.y) > stopThreshold) {
                Vector2 newSpeed = rb2d.velocity;
                newSpeed.Scale(new Vector2(slowDownFactor, slowDownFactor));
                rb2d.velocity = newSpeed;
            } else { // Stop the player if speed is too slow
                rb2d.velocity = Vector2.zero;
            }
        }
    }
}