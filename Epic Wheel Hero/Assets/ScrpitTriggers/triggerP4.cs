using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerP4 : MonoBehaviour
{
    public static bool trigger4 = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        trigger4 = true;
        Debug.Log("triggerP4");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        trigger4 = false;
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
