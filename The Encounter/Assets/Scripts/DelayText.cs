using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DelayText : MonoBehaviour
{
    // change scene
    public float delay = 2;
    public string NewLevel = "Level";

    // audio
    AudioSource audioSource;
    public AudioClip startSound;

    void Start()
    {
        // audio
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = startSound;
        audioSource.Play();

        // change scene
        StartCoroutine(LoadLevelAfterDelay(delay));
    }
 
    // change scene
    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(NewLevel);
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
