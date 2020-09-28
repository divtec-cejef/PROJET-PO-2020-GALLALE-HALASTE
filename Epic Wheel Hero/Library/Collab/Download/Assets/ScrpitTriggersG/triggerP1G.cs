using UnityEngine;

public class triggerP1G : MonoBehaviour
{
    public static bool verifTrigger1G = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        verifTrigger1G = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        verifTrigger1G = false;
    }
}
