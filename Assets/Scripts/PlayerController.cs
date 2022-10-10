using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    private Vector3 moveInput;
    private int score = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        // Setting variables for player movement
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.z = Input.GetAxisRaw("Vertical");

        // Stops player from moving faster on diagonal
        moveInput.Normalize();

        rb.velocity = moveInput * speed;
    }

    void OnTriggerEnter(Collider other)
    {
        // If the object can be picked up
        if (other.tag == "Pickup")
        {
            Destroy(other.gameObject);
            score += 1;
            Debug.Log($"Score: {score}");
        }
    }
}
