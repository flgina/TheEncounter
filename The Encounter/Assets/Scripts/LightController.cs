using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LightController : MonoBehaviour
{
    // move
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    public float speed = 3.0f;

    // particle
    public ParticleSystem explosionEffect;

    // player
    private PlayerController playerController;

    void Awake()
    {
        // player
        playerController = GameObject.FindObjectOfType<PlayerController>();
    }

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }

    // Destroy Enemy
    void OnCollisionEnter2D(Collision2D collision)
    {
        // target
        if (collision.gameObject.tag == "Elf")
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            collision.gameObject.SetActive(false);
            playerController.UpdateTarget(1);
        }
    }
}
