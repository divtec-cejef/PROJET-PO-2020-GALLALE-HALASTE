using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;
using TMPro;
using Quaternion = UnityEngine.Quaternion;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;
using Vector3 = UnityEngine.Vector3;

public class transition : MonoBehaviour
{


    public TextMeshProUGUI nom;
    public string affichage = "";
    public static int timeAffichage = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (scoreScriptD.scoreValue > scoreScriptG.scoreValue)
        {
            affichage = "Joueur 2 gagne !";
            nom.text = affichage;
        }
        if (scoreScriptG.scoreValue > scoreScriptD.scoreValue)
        {
            affichage = "Joueur 1 gagne !";
            nom.text = affichage;
        }
        if (scoreScriptG.scoreValue == scoreScriptD.scoreValue)
        {
            affichage = "Egalité !";
            nom.text = affichage;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(timeAffichage);
        if (timeAffichage > 0)
        {
            timeAffichage -= 1;
        }
        else if (timeAffichage < 0)
        {
            timeAffichage = 0;
        }
        if (timeAffichage == 0)
        {
            SceneManager.LoadScene("GameScene_HighscoreTable", LoadSceneMode.Single);
        }
       

    }
}
