using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerP4G : MonoBehaviour
{
    public static bool verifTrigger4G = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        verifTrigger4G = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        verifTrigger4G = false;
    }
}
