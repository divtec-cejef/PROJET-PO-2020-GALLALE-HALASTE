using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerP2G : MonoBehaviour
{
    public static bool verifTrigger2G = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        verifTrigger2G = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        verifTrigger2G = false;
    }
}
