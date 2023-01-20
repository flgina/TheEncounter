using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject sheild;

    // Start is called before the first frame update
    void Start()
    {
        // sheild
        sheild.SetActive(false);
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
    }
}
