using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    // move
    public Vector2 player = new Vector2(-8,0);

    //health
    private int health = 5;

    // block
    private int block = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), player, 3 * Time.deltaTime);
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
