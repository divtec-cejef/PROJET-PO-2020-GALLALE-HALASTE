using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerP1D : MonoBehaviour
{
    public static bool verifTrigger1D = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        verifTrigger1D = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        verifTrigger1D = false;
    }
}
