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

    private int currentCount;

    // player
    private PlayerController playerController;

    // awake
    void Awake()
    {
        playerController = GameObject.FindObjectOfType<PlayerController>();
    }

    // count
    public void UpdateCount(int count)
    {
        currentCount += count;
        while (currentCount == 2)// || currentCount == 4 || currentCount == 6 || currentCount == 8 || currentCount == 10)
        {
            transform.position = Vector2.MoveTowards(transform.position, destination, Time.deltaTime * speed);
        }
    }

    // Update is called once per frame
    /*private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, destination, Time.deltaTime * speed);
    }*/

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
