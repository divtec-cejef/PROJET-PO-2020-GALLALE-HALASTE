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
    public void Update()
    {
        if (Input.GetKeyDown("3"))
        {
            Application.Quit();
            Debug.Log("Programme Quitter");
        }
        if (Input.GetKeyDown("t"))
        {
            switch(compteur)
            {
                case 1 :
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
                    compteur++;
                    return;
                case 2 :
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
                    compteur++;
                    return;
                case 3 :
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
                    compteur++;
                    return;
                case 4 :
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
                    compteur = 1;
                    return;
                    
            }
        }

        if (Input.GetKeyDown("r"))
        {
            switch(compteur)
            {
                case 1 :
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    SceneManager.LoadScene("GameScene_HighscoreTable", LoadSceneMode.Single);
                    Debug.Log("CLASSEMENT" + compteur);
                    return;
                    
                case 2 :
                    attribuSpeed = 1.5f;
                    attribuSpeed = 1.5f;
                    SceneManager.LoadScene("DeuxJoueurs", LoadSceneMode.Single);
                    Debug.Log("FACILE" + compteur);
                    return;
                    
                case 3 :
                    attribuSpeed = 2.5f;
                    attribuSpeed = 2.5f;
                    SceneManager.LoadScene("DeuxJoueurs", LoadSceneMode.Single);
                    Debug.Log("MOYEN" + compteur);
                    return;
                    
                case 4 :
                    attribuSpeed = 3.5f;
                    attribuSpeed = 3.5f;
                    SceneManager.LoadScene("DeuxJoueurs", LoadSceneMode.Single);
                    Debug.Log("DIFFICILE" + compteur);
                    return;

            }
        }
       
    }
}

