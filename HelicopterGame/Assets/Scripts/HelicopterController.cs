using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;

    [Header("Audio")]
    public AudioClip pickupClip;

    private Rigidbody2D rb;
    private Vector2 movement;
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

        if (GameManager.Instance != null && GameManager.Instance.isGameOver)
            return;

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.velocity = movement.normalized * moveSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
  
        if (other.CompareTag("Soldier") && GameManager.Instance.CanPickUp())
        {
    
            if (pickupClip != null && audioSource != null)
            {
                audioSource.PlayOneShot(pickupClip);
            }

            GameManager.Instance.PickUpSoldier();
            Destroy(other.gameObject);

            Debug.Log("Picked up soldier. In helicopter: " + GameManager.Instance.soldiersInHelicopter);
        }


        if (other.CompareTag("Hospital"))
        {
            GameManager.Instance.UnloadAtHospital();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
 
        if (collision.gameObject.CompareTag("Tree"))
        {
            GameManager.Instance.GameOver();
            rb.velocity = Vector2.zero;
        }
    }
}