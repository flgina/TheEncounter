using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Destroy Light
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Light")
        {
            Destroy(gameObject);
            //target += 1;
        }
    }
}
