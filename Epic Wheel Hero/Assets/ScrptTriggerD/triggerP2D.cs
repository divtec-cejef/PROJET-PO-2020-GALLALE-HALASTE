using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerP2D : MonoBehaviour
{
    public static bool verifTrigger2D = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        verifTrigger2D = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        verifTrigger2D = false;
    }
}
