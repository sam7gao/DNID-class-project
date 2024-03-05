using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomBehaviour : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public float minJumpInterval = 2f;
    public float maxJumpInterval = 4f;
    public float jumpDelay = 1f;
    public Vector2 flipIntervalRange = new Vector2(3f, 6f); // Time interval to flip direction

    private Rigidbody2D rb;
    private float nextJumpTime;
    private float nextFlipTime;
    private bool isFacingRight = true; // Track the direction

    void Start()
    {
    	rb = GetComponent<Rigidbody2D>();
        nextJumpTime = Time.time + Random.Range(minJumpInterval, maxJumpInterval);
    	nextFlipTime = Time.time + Random.Range(flipIntervalRange.x, flipIntervalRange.y);

    	// Set the initial direction to left
    	isFacingRight = false;
    }

	void Update()
    {
        // Check if it's time to flip direction
        if (Time.time > nextFlipTime)
        {
            Flip();
            nextFlipTime = Time.time + Random.Range(flipIntervalRange.x, flipIntervalRange.y);
        }

        // Move the character continuously
        if (isFacingRight)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }

        // Jump randomly
        if (Time.time > nextJumpTime)
        {
            Jump();
            nextJumpTime = Time.time + Random.Range(minJumpInterval, maxJumpInterval);
        }
    }
    
    void Jump()
    {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}