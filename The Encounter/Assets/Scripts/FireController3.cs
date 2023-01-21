using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController3 : MonoBehaviour
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
        playerController = GameObject.FindObjectOfType<PlayerController>();
        lightController = GameObject.FindObjectOfType<LightController>();
    }

    void Start()
    {
        playerPos = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lightController.target >= 8)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
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
