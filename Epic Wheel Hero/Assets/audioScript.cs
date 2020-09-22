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
        Debug.Log("Awake");
    }
    // Update is called once per frame
    void Update()
    {
        switch (compteurTheme)
        {
            case 1:
                    Debug.Log("je fais jouer FarWest");
                    compteurTheme = -1;
                    Debug.Log(compteurTheme);
                    MusiqueJeu.clip = audioFarWest;
                    MusiqueJeu.Play();
                    compteurTheme = -1;
                break;

            case 2:
                Debug.Log("je fais jouer future");
                compteurTheme = -1;
                MusiqueJeu.clip = audioFuture;
                MusiqueJeu.Play();
                compteurTheme = -1;
                break;
            case 3:
                Debug.Log("je fais jouer prehistoire");
                compteurTheme = -1;
                MusiqueJeu.clip = audioPrehistoire;
                MusiqueJeu.Play();
                compteurTheme = -1;
                break;
        }
    }
}
