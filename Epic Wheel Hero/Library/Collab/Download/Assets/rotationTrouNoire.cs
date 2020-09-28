using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationTrouNoire : MonoBehaviour
{
    Vector3 rotationEuler;

    // Start is called before the first frame update
    void Start()
    {
    }
    void Update(){
        rotationEuler+= Vector3.forward*30*Time.deltaTime; //increment 30 degrees every second
        transform.rotation = Quaternion.Euler(rotationEuler);
    }
}
