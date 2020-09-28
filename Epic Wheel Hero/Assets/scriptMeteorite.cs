using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptMeteorite : MonoBehaviour
{
    private float floatSpan = 2.0f;
    private float speed = 4.0f;
 
    private float startX;
    private float startY;
    private Vector3 levitation = new Vector3(0, 0, 1);


    // Start is called before the first frame update
    void Start()
    {
        startX = transform.position.x;
        startY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
 
        // Put the floating movement in the Update function:
        levitation.x = startX + Time.time * speed;
        levitation.y = startY + Time.time * speed;

        transform.position = levitation;

    }
}
