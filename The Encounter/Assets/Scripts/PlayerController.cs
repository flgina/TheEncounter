using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // light
    LightController lightController;

    // sheild
    public GameObject sheild;

    // block
    public TextMeshProUGUI blockText;
    public int block;
    private int currentBlock;
    public int defend;

    // target
    public TextMeshProUGUI targetText;
    public int target;
    public int currentTarget;

    // timer
    public TextMeshProUGUI timeText;
    public float timer = 10;

    // win/lose
    public bool gameOver = false;

    // audio
    AudioSource audioSource;
    public AudioClip shieldSound;
    public AudioClip loseSound;
    public AudioClip winSound;

    // start
    void Start()
    {
        // sheild
        sheild.SetActive(false);

        // block
        block = 5;
        blockText.text = "Block: " + block.ToString() + "/5";

        // target
        target = 0;
        targetText.text = "Enemies: " + target.ToString() + "/6";

        // sound
        audioSource = GetComponent<AudioSource>();
    }

    // sheild
    public void UpdateSheild(int block)
    {
        currentBlock += block;
        defend = 5 - currentBlock;
        blockText.text = "Block: " + defend.ToString() + "/5";

        // sound
        audioSource.clip = shieldSound;
        audioSource.Play();
    }

    // target
    public void UpdateTarget(int target)
    {
        currentTarget += target;
        targetText.text = "Enemies: " + currentTarget.ToString() + "/6";
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
        if ((timer != 0) && (currentTarget >= 6) && (defend >= 4))
        {
            gameOver = true;
            SceneManager.LoadScene("Win");
        }

        // lose
        if ((timer == 0) && (currentTarget <= 5) || (defend == 5))
        {
            gameOver = true;
            SceneManager.LoadScene("Lose");
        }
    }

    // sound
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
