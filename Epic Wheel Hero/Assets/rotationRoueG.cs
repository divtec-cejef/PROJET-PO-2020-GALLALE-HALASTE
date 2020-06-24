using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationRoueG : MonoBehaviour
{
	float rotationSpeed = -32;
	Vector3 rotationAngle;
	
    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
        rotationAngle += new Vector3(0, 0, 1) * Time.deltaTime * rotationSpeed;
		transform.eulerAngles = rotationAngle;
    }
	
}
