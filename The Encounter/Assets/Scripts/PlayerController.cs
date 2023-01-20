using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // sheild
    public GameObject sheild;

    // health
    public TextMeshProUGUI healthText;
    public int health;
    private int currentHealth;
    public int lives;

    // block
    public TextMeshProUGUI blockText;
    public int block = 0;
    private int currentBlock;

    // timer
    public TextMeshProUGUI timeText;
    public float timer = 10;

    // start
    void Start()
    {
        // sheild
        sheild.SetActive(false);

        // health
        health = 5;
        healthText.text = "Health: " + health.ToString() + "/5";

        // block
        blockText.text = "Block: " + block.ToString() + "/1";
    }

    // Update is called once per frame
    void Update()
    {
        // sheild
        if (Input.GetKeyDown(KeyCode.Q))
        {
            sheild.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            sheild.SetActive(false);
        }

        // timer
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 0;
        }
        timeText.text = timer.ToString();
    }

    public void UpdateSheild(int block)
    {
        currentBlock += block;
        blockText.text = "Block: " + currentBlock.ToString() + "/1";
    }

    public void UpdateHealth(int health)
    {
        currentHealth += health;
        lives = 5 - currentHealth;
        healthText.text = "Health: " + lives.ToString() + "/5";
    }
}
