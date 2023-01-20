using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    // move
    private Vector2 destination = new Vector2(-8,3);
    private float speed = 3;

    // health
    public int health;

    // block
    public int block = 0;

    // player
    private PlayerController playerController;

    // awake
    void Awake()
    {
        playerController = GameObject.FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, destination, Time.deltaTime * speed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Sheild")
        {
            Destroy(gameObject);
            playerController.UpdateSheild(1);
        }

        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            playerController.UpdateHealth(1);
        }
    }
} 
