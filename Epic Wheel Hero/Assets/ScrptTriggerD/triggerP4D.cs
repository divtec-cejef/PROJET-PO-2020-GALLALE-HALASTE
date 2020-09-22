using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerP4D : MonoBehaviour
{
    public static bool verifTrigger4D = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        verifTrigger4D = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        verifTrigger4D = false;
    }
}
