using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // light
    LightController lightController;

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

    // win/lose
    public TextMeshProUGUI gameText;
    public bool gameOver = false;

    // audio
    AudioSource audioSource;
    public AudioClip shieldSound;
    public AudioClip loseSound;
    public AudioClip winSound;
    public AudioClip backgroundSound;

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

        // win/lose
        gameText.text = "";

        // sound
        //audioSource = GetComponent<AudioSource>();
        audioSource.clip = backgroundSound;
        audioSource.Play();
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

        // win
        if (/*(timer != 0)) && (lightController.target >= 6) && (lives != 0) && */(currentBlock >= 1))
        {
            gameText.text = "You Win!";
            gameOver = true;

            // sound
            audioSource.clip = backgroundSound;
            audioSource.Stop();
            audioSource.clip = winSound;
            audioSource.Play();
        }

        // lose
        if (/*(timer == 0)) && (lightController.target < 6) && (lives == 0) && */(currentBlock != 0))
        {
            gameText.text = "You Lose!";
            gameOver = true;

            // sound
            audioSource.clip = backgroundSound;
            audioSource.Stop();
            audioSource.clip = loseSound;
            audioSource.Play();
        }
    }

    // sheild
    public void UpdateSheild(int block)
    {
        currentBlock += block;
        blockText.text = "Block: " + currentBlock.ToString() + "/1";

        // sound
        audioSource.clip = shieldSound;
        audioSource.Play();
    }

    // health
    public void UpdateHealth(int health)
    {
        currentHealth += health;
        lives = 5 - currentHealth;
        healthText.text = "Health: " + lives.ToString() + "/5";
    }

    // sound
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
