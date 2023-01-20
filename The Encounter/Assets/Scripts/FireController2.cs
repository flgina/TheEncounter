using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController2 : MonoBehaviour
{
    // move
    private Vector2 destination = new Vector2(-8,3);
    private float speed = 5.0f;

    // player
    private PlayerController playerController;

    // light
    LightController lightController;

    // awake
    void Awake()
    {
        playerController = GameObject.FindObjectOfType<PlayerController>();
        lightController = GameObject.FindObjectOfType<LightController>();
    }

    // Update is called once per frame
    void Update()
    { 
        if (lightController.target == 6)
        {
            transform.position = Vector2.MoveTowards(transform.position, destination, Time.deltaTime * speed);
        }
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
