using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioScript : MonoBehaviour
{
    public AudioSource MusiqueJeu = new AudioSource();

    public AudioClip audioFarWest;
    public AudioClip audioFuture;
    public AudioClip audioPrehistoire;

    public static int compteurTheme = 0;

    private void Awake()
    {
        compteurTheme = 1;
    }
    // Update is called once per frame
    void Update()
    {
        switch (compteurTheme)
        {
            case 1:
                    compteurTheme = -1;
                    MusiqueJeu.clip = audioFarWest;
                    MusiqueJeu.Play();
                    compteurTheme = -1;
                break;

            case 2:
                compteurTheme = -1;
                MusiqueJeu.clip = audioFuture;
                MusiqueJeu.Play();
                compteurTheme = -1;
                break;
            case 3:
                compteurTheme = -1;
                MusiqueJeu.clip = audioPrehistoire;
                MusiqueJeu.Play();
                compteurTheme = -1;
                break;
        }
    }
}
