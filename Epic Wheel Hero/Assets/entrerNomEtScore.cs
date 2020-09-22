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

public class entrerNomEtScore : MonoBehaviour
{
    public static string valueAlphabet = "";
    public static string valueNom = "";
    public int value2ScoreG = 0;
    public int value2ScoreD = 0;
    public TextMeshProUGUI nom;
    public TextMeshProUGUI alphabet;
    public TextMeshProUGUI score1;
    public TextMeshProUGUI score2;
    public TextMeshProUGUI joueurGagnent;

    public int compteur = 1;



    // Update is called once per frame
    void Update()
    {
        Debug.Log("valueNom" + valueNom);
        Debug.Log("alphabet" + valueAlphabet);
        if (valueNom.Length < 3)
        {
            //////////////JOUEUR 2////////////////
            if (scoreScriptD.scoreValue > scoreScriptG.scoreValue)
            {
                value2ScoreD = scoreScriptD.scoreValue;
                value2ScoreG = scoreScriptG.scoreValue;
                if (Input.GetKeyDown("f"))
                {
                    valueNom += valueAlphabet;
                }
                nom.text = valueNom;
                alphabet.text = valueAlphabet;
                score1.text = "SCOREJ1 : " + value2ScoreG;
                score2.text = "SCOREJ2 : " + value2ScoreD;
                joueurGagnent.text = "JOUEUR 2 GAGNE !";
                if (Input.GetKeyDown("g"))
                {
                    switch (compteur)
                    {
                        case 1:
                            valueAlphabet = "A";
                            compteur++;
                            return;
                        case 2:
                            valueAlphabet = "B";
                            compteur++;
                            return;
                        case 3:
                            valueAlphabet = "C";
                            compteur++;
                            return;
                        case 4:
                            valueAlphabet = "D";
                            compteur++;
                            return;
                        case 5:
                            valueAlphabet = "E";
                            compteur++;
                            return;
                        case 6:
                            valueAlphabet = "F";
                            compteur++;
                            return;
                        case 7:
                            valueAlphabet = "G";
                            compteur++;
                            return;
                        case 8:
                            valueAlphabet = "H";
                            compteur++;
                            return;
                        case 9:
                            valueAlphabet = "I";
                            compteur++;
                            return;
                        case 10:
                            valueAlphabet = "J";
                            compteur++;
                            return;
                        case 11:
                            valueAlphabet = "K";
                            compteur++;
                            return;
                        case 12:
                            valueAlphabet = "L";
                            compteur++;
                            return;
                        case 13:
                            valueAlphabet = "M";
                            compteur++;
                            return;
                        case 14:
                            valueAlphabet = "N";
                            compteur++;
                            return;
                        case 15:
                            valueAlphabet = "O";
                            compteur++;
                            return;
                        case 16:
                            valueAlphabet = "P";
                            compteur++;
                            return;
                        case 17:
                            valueAlphabet = "Q";
                            compteur++;
                            return;
                        case 18:
                            valueAlphabet = "R";
                            compteur++;
                            return;
                        case 19:
                            valueAlphabet = "S";
                            compteur++;
                            return;
                        case 20:
                            valueAlphabet = "T";
                            compteur++;
                            return;
                        case 21:
                            valueAlphabet = "U";
                            compteur++;
                            return;
                        case 22:
                            valueAlphabet = "V";
                            compteur++;
                            return;
                        case 23:
                            valueAlphabet = "W";
                            compteur++;
                            return;
                        case 24:
                            valueAlphabet = "X";
                            compteur++;
                            return;
                        case 25:
                            valueAlphabet = "Y";
                            compteur++;
                            return;
                        case 26:
                            valueAlphabet = "Z";
                            compteur++;
                            return;
                        case 27:
                            compteur = 1;
                            return;
                    }
                }
            }

            //////////////JOUEUR 1////////////////
            if (scoreScriptG.scoreValue > scoreScriptD.scoreValue)
            {
                value2ScoreD = scoreScriptD.scoreValue;
                value2ScoreG = scoreScriptG.scoreValue;
                if (Input.GetKeyDown("r"))
                {
                    valueNom += valueAlphabet;
                }
                score1.text = "SCOREJ1 : " + value2ScoreG;
                score2.text = "SCOREJ2 : " + value2ScoreD;
                nom.text = valueNom;
                alphabet.text = valueAlphabet;
                joueurGagnent.text = "JOUEUR 1 GAGNE !";
                if (Input.GetKeyDown("t"))
                {
                    switch (compteur)
                    {
                        case 1:
                            valueAlphabet = "A";
                            compteur++;
                            return;
                        case 2:
                            valueAlphabet = "B";
                            compteur++;
                            return;
                        case 3:
                            valueAlphabet = "C";
                            compteur++;
                            return;
                        case 4:
                            valueAlphabet = "D";
                            compteur++;
                            return;
                        case 5:
                            valueAlphabet = "E";
                            compteur++;
                            return;
                        case 6:
                            valueAlphabet = "F";
                            compteur++;
                            return;
                        case 7:
                            valueAlphabet = "G";
                            compteur++;
                            return;
                        case 8:
                            valueAlphabet = "H";
                            compteur++;
                            return;
                        case 9:
                            valueAlphabet = "I";
                            compteur++;
                            return;
                        case 10:
                            valueAlphabet = "J";
                            compteur++;
                            return;
                        case 11:
                            valueAlphabet = "K";
                            compteur++;
                            return;
                        case 12:
                            valueAlphabet = "L";
                            compteur++;
                            return;
                        case 13:
                            valueAlphabet = "M";
                            compteur++;
                            return;
                        case 14:
                            valueAlphabet = "N";
                            compteur++;
                            return;
                        case 15:
                            valueAlphabet = "O";
                            compteur++;
                            return;
                        case 16:
                            valueAlphabet = "P";
                            compteur++;
                            return;
                        case 17:
                            valueAlphabet = "Q";
                            compteur++;
                            return;
                        case 18:
                            valueAlphabet = "R";
                            compteur++;
                            return;
                        case 19:
                            valueAlphabet = "S";
                            compteur++;
                            return;
                        case 20:
                            valueAlphabet = "T";
                            compteur++;
                            return;
                        case 21:
                            valueAlphabet = "U";
                            compteur++;
                            return;
                        case 22:
                            valueAlphabet = "V";
                            compteur++;
                            return;
                        case 23:
                            valueAlphabet = "W";
                            compteur++;
                            return;
                        case 24:
                            valueAlphabet = "X";
                            compteur++;
                            return;
                        case 25:
                            valueAlphabet = "Y";
                            compteur++;
                            return;
                        case 26:
                            valueAlphabet = "Z";
                            compteur++;
                            return;
                        case 27:
                            compteur = 1;
                            return;
                    }
                }
            }
        }
        else if (Input.GetKeyDown("k"))
        {
            compteur = 2;
            valueAlphabet = "A";
            valueNom = "";
        }
        else if (Input.GetKeyDown("1") && valueNom.Length == 3)
        {
            HighscoreTable.AddHighscoreEntry(scoreScriptD.scoreValue, valueNom);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown("3"))
        {
            Application.Quit();
            Debug.Log("Programme Quitter");
        }

        if (Input.GetKeyDown("2"))
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }

    }
    }

