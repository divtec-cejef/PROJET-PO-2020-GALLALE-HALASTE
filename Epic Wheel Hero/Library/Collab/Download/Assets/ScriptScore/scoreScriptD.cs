﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class scoreScriptD : MonoBehaviour
{

    public static int scoreValue = 0;
    public static TextMeshProUGUI score;
    
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<TMPro.TextMeshProUGUI> ();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + scoreValue;
    }
}
