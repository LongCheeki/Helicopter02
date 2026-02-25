using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    private int soldiersInHelicopter = 0;
    private int maxCapacity = 3;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.velocity = movement.normalized * moveSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Soldier") && soldiersInHelicopter < maxCapacity)
        {
            soldiersInHelicopter++;
            Destroy(other.gameObject);
            Debug.Log("Picked up soldier. Current: " + soldiersInHelicopter);
        }
    }
}