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

    // target
    public TextMeshProUGUI targetText;
    public int target;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

        // target
        target = 0;
        targetText.text = "Enemies: " + target.ToString() + "/6";
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
        if (collision.gameObject.tag == "Elf")
        {
            collision.gameObject.SetActive(false);
            target += 1;
            targetText.text = "Enemies: " + target.ToString() + "/6";
        }
    }
}
