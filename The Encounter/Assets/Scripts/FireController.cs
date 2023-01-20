using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    // move
    private Vector2 destination = new Vector2(-8,3);
    private float speed = 3;

    //health
    private int health = 5;

    // block
    private int block = 0;

    public EnemyController enemyController;

    // Start is called before the first frame update
    void Start()
    {

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
            block += 1;
        }

        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            health -= 1;
        }
    }
} 
