using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deplacementAvionChasse : MonoBehaviour
{
    private float floatSpan = 2.0f;
    private float speed = 3.0f;
 
    private float startX;
    private Vector3 levitation = new Vector3(0, 0, 0);


    // Start is called before the first frame update
    void Start()
    {
        startX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
 
        // Put the floating movement in the Update function:
        levitation.x = startX + Time.time * speed;
        levitation.y = transform.position.y;
        levitation.z = transform.position.z;

        transform.position = levitation;

    }
}
