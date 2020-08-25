using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerP3 : MonoBehaviour
{
    public static bool trigger3 = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        trigger3 = true;
        Debug.Log("triggerP3");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        trigger3 = false;
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
