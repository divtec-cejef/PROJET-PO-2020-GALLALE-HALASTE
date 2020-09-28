using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class musiqueVictoire : MonoBehaviour
{

    private AudioSource sourceMusique = new AudioSource();
    private AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        sourceMusique.clip = clip;
        sourceMusique.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
