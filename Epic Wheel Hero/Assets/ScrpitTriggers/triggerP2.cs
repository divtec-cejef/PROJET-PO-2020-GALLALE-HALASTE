﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerP2 : MonoBehaviour
{
    public static bool trigger2 = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        trigger2 = true;
        Debug.Log("triggerP2");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        trigger2 = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
