using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerP3G : MonoBehaviour
{
    public static bool verifTrigger3G = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        verifTrigger3G = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        verifTrigger3G = false;
    }
}
