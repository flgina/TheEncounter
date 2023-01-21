using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IntroUI : MonoBehaviour
{    
    // start
    public TMP_Text startText;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DisableText", 2f);
    }

    void DisableText()
    {
        startText.enabled = false;
    }
}
