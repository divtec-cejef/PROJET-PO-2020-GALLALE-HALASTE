using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerP3D : MonoBehaviour
{
    public static bool verifTrigger3D = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        verifTrigger3D = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        verifTrigger3D = false;
    }
}
