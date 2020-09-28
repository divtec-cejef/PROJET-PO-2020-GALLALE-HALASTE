using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouvementVaisseau : MonoBehaviour
{
    private float floatSpan = 2.0f;
    private float speed = 1.0f;
 
    private float startY;
    private Vector3 levitation = new Vector3(0, 0, 0);


    // Start is called before the first frame update
    void Start()
    {
        startY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
 
        // Put the floating movement in the Update function:
        levitation.y = startY + Mathf.Sin(Time.time * speed) * floatSpan / 10f;
        levitation.x = transform.position.x;
        levitation.z = transform.position.z;

        transform.position = levitation;

    }
}
