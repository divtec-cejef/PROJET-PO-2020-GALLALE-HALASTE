using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

public class menuDemarrage : MonoBehaviour
{
    public TextMeshProUGUI facile;
    public TextMeshProUGUI moyen;
    public TextMeshProUGUI difficile;
    public TextMeshProUGUI classement;
    public static int compteur = 1;
    public static float attribuSpeed = 0;
    public GameObject roueRouge;
    public GameObject roueOrange;
    public GameObject roueVerte;
    public Vector3 POS_roueRouge = new Vector3(4.00f, -3.58f, -4f);
    public Vector3 POS_roueOrange = new Vector3(4.00f, 3.53f, -4f);
    public Vector3 POS_roueVerte = new Vector3(-10.34f, 0.05f, -4f);

    public AudioSource MusiqueJeu = new AudioSource();

    public AudioClip audioFarWest;
    public AudioClip audioFuture;
    public AudioClip audioPrehistoire;
    public void Start()
    {
        POS_roueVerte.z = 70;
        roueVerte.transform.position = POS_roueVerte;
        POS_roueRouge.z = 70;
        roueRouge.transform.position = POS_roueRouge;
        POS_roueOrange.z = 70;
        roueOrange.transform.position = POS_roueOrange;
    }
    public void Update()
    {
        if (Input.GetKeyDown("3"))
        {
            Application.Quit();
            Debug.Log("Programme Quitter");
        }
        if (Input.GetKeyDown("t"))
        {
            switch (compteur)
            {
                case 1:
                    facile.fontStyle = FontStyles.Underline;
                    if (moyen.fontStyle == FontStyles.Underline)
                    {
                        moyen.fontStyle ^= FontStyles.Underline;
                    }

                    if (difficile.fontStyle == FontStyles.Underline)
                    {
                        difficile.fontStyle ^= FontStyles.Underline;
                    }

                    if (classement.fontStyle == FontStyles.Underline)
                    {
                        classement.fontStyle ^= FontStyles.Underline;
                    }

                    POS_roueVerte.z = -4;
                    roueVerte.transform.position = POS_roueVerte;
                    POS_roueRouge.z = 70;
                    roueRouge.transform.position = POS_roueRouge;
                    POS_roueOrange.z = 70;
                    roueOrange.transform.position = POS_roueOrange;
                    MusiqueJeu.clip = audioFarWest;
                    MusiqueJeu.Play();
                    compteur = 2;
                    return;
                case 2:
                    moyen.fontStyle = FontStyles.Underline;
                    if (difficile.fontStyle == FontStyles.Underline)
                    {
                        difficile.fontStyle ^= FontStyles.Underline;
                    }

                    if (facile.fontStyle == FontStyles.Underline)
                    {
                        facile.fontStyle ^= FontStyles.Underline;
                    }

                    if (classement.fontStyle == FontStyles.Underline)
                    {
                        classement.fontStyle ^= FontStyles.Underline;
                    }
                    POS_roueOrange.z = -4;
                    roueOrange.transform.position = POS_roueOrange;
                    POS_roueRouge.z = 70;
                    roueRouge.transform.position = POS_roueRouge;
                    POS_roueVerte.z = 70;
                    roueVerte.transform.position = POS_roueVerte;
                    compteur = 3;
                    MusiqueJeu.clip = audioFuture;
                    MusiqueJeu.Play();
                    return;
                case 3:
                    difficile.fontStyle = FontStyles.Underline;
                    if (moyen.fontStyle == FontStyles.Underline)
                    {
                        moyen.fontStyle ^= FontStyles.Underline;
                    }

                    if (facile.fontStyle == FontStyles.Underline)
                    {
                        facile.fontStyle ^= FontStyles.Underline;
                    }

                    if (classement.fontStyle == FontStyles.Underline)
                    {
                        classement.fontStyle ^= FontStyles.Underline;
                    }
                    POS_roueOrange.z = 70;
                    roueOrange.transform.position = POS_roueOrange;
                    POS_roueRouge.z = -4;
                    roueRouge.transform.position = POS_roueRouge;
                    POS_roueVerte.z = 70;
                    roueVerte.transform.position = POS_roueVerte;
                    compteur = 4;
                    MusiqueJeu.clip = audioPrehistoire;
                    MusiqueJeu.Play();
                    return;
                case 4:
                    classement.fontStyle = FontStyles.Underline;
                    if (moyen.fontStyle == FontStyles.Underline)
                    {
                        moyen.fontStyle ^= FontStyles.Underline;
                    }

                    if (facile.fontStyle == FontStyles.Underline)
                    {
                        facile.fontStyle ^= FontStyles.Underline; 
                    }

                    if (difficile.fontStyle == FontStyles.Underline)
                    {
                        difficile.fontStyle ^= FontStyles.Underline;
                    
                    }
                    POS_roueOrange.z = 70;
                    roueOrange.transform.position = POS_roueOrange;
                    POS_roueRouge.z = 70;
                    roueRouge.transform.position = POS_roueRouge;
                    POS_roueVerte.z = 70;
                    roueVerte.transform.position = POS_roueVerte;
                    compteur = 1;
                    MusiqueJeu.Pause();
                    return;
            }
        }

        if (Input.GetKeyDown("r"))
        {
            switch(compteur)
            {
                //Classement
                case 1 :
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    SceneManager.LoadScene("GameScene_HighscoreTable", LoadSceneMode.Single);
                    Debug.Log("CLASSEMENT" + compteur);
                    return;

                //Facile
                case 2 :
                    attribuSpeed = 1f;
                    SceneManager.LoadScene("DeuxJoueurs", LoadSceneMode.Single);
                    Debug.Log("FACILE" + compteur);
                    return;

                //Moyen
                case 3 :
                    attribuSpeed = 0.8f;
                    SceneManager.LoadScene("DeuxJoueurs", LoadSceneMode.Single);
                    Debug.Log("MOYEN" + compteur);
                    return;

                //Difficile
                case 4 :
                    attribuSpeed = 0.5f;
                    SceneManager.LoadScene("DeuxJoueurs", LoadSceneMode.Single);
                    Debug.Log("DIFFICILE" + compteur);
                    return;

            }
        }
       
    }
}

