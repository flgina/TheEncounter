using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController1 : MonoBehaviour
{
    // move
    public GameObject player;
    private Transform playerPos;
    public  float speed;

    // player
    private PlayerController playerController;

    // light
    LightController lightController;

    // awake
    void Awake()
    {
        // player
        playerController = GameObject.FindObjectOfType<PlayerController>();
        // light
        lightController = GameObject.FindObjectOfType<LightController>();
    }

    void Start()
    {
        // get player position
        playerPos = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // checks if number of targets required are destroyed
        if (lightController.target >= 4)
        {
            // move
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // shield
        if (collision.gameObject.tag == "Sheild")
        {
            Destroy(gameObject);
            playerController.UpdateSheild(1);
        }

        // player
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            playerController.UpdateHealth(1);
        }
    }
} 
