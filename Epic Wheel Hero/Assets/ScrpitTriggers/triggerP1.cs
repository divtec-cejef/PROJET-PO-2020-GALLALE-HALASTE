using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerP1 : MonoBehaviour
{
    public static bool trigger1 = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        trigger1 = true;
        Debug.Log("triggerP1");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        trigger1 = false;
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
