using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;
using UnityEngine.SceneManagement;

public class mouvementRoueG : MonoBehaviour
{
	private static float arriere = 50f;
	// Far West
	public GameObject FW_fond;
	public GameObject FW_cactus1;
	public GameObject FW_cactus2;
	public GameObject FW_cactus3;
	public GameObject FW_cactus4;
	public GameObject FW_flaque;
	public GameObject FW_village;
	public GameObject FW_panneau;
	public GameObject FW_roueG;
	public GameObject FW_roueD;
	public GameObject FW_teepees;


	// Future
	public GameObject FT_fond;
	public GameObject FT_vaisseau1;
	public GameObject FT_vaisseau2;
	public GameObject FT_avion;
	public GameObject FT_trouNoire;
	public GameObject FT_roueG;
	public GameObject FT_roueD;
	
	//PREHISTOIRE
	public GameObject PR_roueG;
	public GameObject PR_roueD;

	public Sprite noteFuture;
	public Sprite notePrehistoire;
	//******NOTE INITIALE******//
	public Sprite noteInitiale;
	//*******NOTE ERREUR*******//
	public Sprite noteErreur;
	//*******NOTE NORMALE******//
	public Sprite blueNote;
	public Sprite greenNote;
	public Sprite redNote;
	public Sprite orangeNote;
	public Sprite yellowNote;
	//**********SCORE*********//
	public Sprite score10;
	public Sprite score20;
	public Sprite score30;
	public Sprite score40;
	public Sprite score50;
	//****NOTE ACCELERATION***//
	public Sprite noteAccelerationBleu;
	public Sprite noteAccelerationJaune;
	public Sprite noteAccelerationOrange;
	public Sprite noteAccelerationRouge;
	public Sprite noteAccelerationVert;
	public Sprite noteAccelerationTouche;
	//*****NOTE PERTE VIE*****//
	public Sprite notePerteVieBleu;
	public Sprite notePerteVieJaune;
	public Sprite notePerteVieOrange;
	public Sprite notePerteVieRouge;
	public Sprite notePerteVieVert;
	public Sprite notePerteVieTouche;
	//*******NOTE RALENTI*****//
	public Sprite noteRalentiBleu;
	public Sprite noteRalentiJaune;
	public Sprite noteRalentiOrange;
	public Sprite noteRalentiRouge;
	public Sprite noteRalentiVert;
	public Sprite noteRalentiTouche;
	
	// Ajuste la vitesse du déplacement de la note
    public float speed = menuDemarrage.attribuSpeed;
    public static int count = 4;
    //timer
    public static int timeRemainingVieG = 2500;
    
    public static int timeRemainingAccelerationG = 0;
    public static int timeRemainingRalentiG = 0;
	
    public static int timeACG = 0;
    public static int timeRLG = 0;
	//combo
	public static int combo = 1;
    // Gère la vitesse des notes, change avec les notes acceleration et decceleration
    public static float boostVitesse = 0;
    // Objet de la position finale de l'élément
    private Transform positionCible;
    private Transform positionCible2;
    private Transform positionCible3;
    private Transform positionCible4;
    private Transform positionCible5;
    private Transform positionCible6;
    private Transform positionCible7;
    private Transform positionCible8;
	
	private bool isTargetOneReached = false;
	private bool isTargetTwoReached = false;
	private bool isTargetThreeReached = false;
	private bool isTargetFourReached = false;
	private bool isTargetFiveReached = false;
	private bool isTargetSixReached = false;
	private bool isTargetSevenReached = false;
	private bool isTargetEightReached = false;
	
	private GameObject cible;
	private GameObject cible2;
	private GameObject cible3;
	private GameObject cible4;
	private GameObject cible5;
	private GameObject cible6;
	private GameObject cible7;
	private GameObject cible8;
	
	private bool isClonedThisRow = false;
	
	// Change la couleur de la note
	void ChangeSprite(Sprite newColor)
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = newColor; 
    }
	
	// Détruit la note et les cibles créées
	void DestroyAll()
	{
		Destroy(cible);
		Destroy(cible2);
		Destroy(cible3);
		Destroy(cible4);
		Destroy(cible5);
		Destroy(cible6);
		Destroy(cible7);
		Destroy(cible8);
		Destroy(gameObject);
	}
		
	// Vecteurs 3
	// Far West
	public Vector3 POS_FW_fond = new Vector3(0f,0f,0f);
	public Vector3 POS_FW_cactus1 = new Vector3(0f,0f,0f);
	public Vector3 POS_FW_cactus2 = new Vector3(0f,0f,0f);
	public Vector3 POS_FW_cactus3 = new Vector3(0f,0f,0f);
	public Vector3 POS_FW_cactus4 = new Vector3(0f,0f,0f);
	public Vector3 POS_FW_flaque = new Vector3(0f,0f,0f);
	public Vector3 POS_FW_village = new Vector3(0f,0f,0f);
	public Vector3 POS_FW_panneau = new Vector3(0f,0f,0f);
	public Vector3 POS_FW_roueG = new Vector3(0f,0f,0f);
	public Vector3 POS_FW_roueD = new Vector3(0f,0f,0f);
	public Vector3 POS_FW_teepees = new Vector3(0f,0f,0f);
    
	// Future
	public Vector3 POS_FT_fond = new Vector3(0f,0f,0f);
	public Vector3 POS_FT_vaisseau1 = new Vector3(0f,0f,0f);
	public Vector3 POS_FT_vaisseau2 = new Vector3(0f,0f,0f);
	public Vector3 POS_FT_avion = new Vector3(0f,0f,0f);
	public Vector3 POS_FT_trouNoire = new Vector3(0f,0f,0f);
	public Vector3 POS_FT_roueG = new Vector3(0f,0f,0f);
	public Vector3 POS_FT_roueD = new Vector3 (0f,0f,0f);
	
	//PREHISTOIRE
	public Vector3 POS_PR_roueG = new Vector3(0f,0f,0f);
	public Vector3 POS_PR_roueD = new Vector3(0f, 0f, 0f);
	
	public void apparitionFuture()
	{
		POS_FW_fond.z = arriere;
		FW_fond.transform.position = POS_FW_fond;
            
		POS_FW_cactus1.z = arriere;
		FW_cactus1.transform.position = POS_FW_cactus1;
            
		POS_FW_cactus2.z = arriere;
		FW_cactus2.transform.position = POS_FW_cactus2;
            
		POS_FW_cactus3.z = arriere;
		FW_cactus3.transform.position = POS_FW_cactus3;
            
		POS_FW_cactus4.z = arriere;
		FW_cactus4.transform.position = POS_FW_cactus4;
            
		POS_FW_panneau.z = arriere;
		FW_panneau.transform.position = POS_FW_panneau;
            
		POS_FW_flaque.z = arriere;
		FW_flaque.transform.position = POS_FW_flaque;
            
		POS_FW_village.z = arriere;
		FW_village.transform.position = POS_FW_village;
            
		POS_FW_roueD.z = arriere;
		FW_roueD.transform.position = POS_FW_roueD;
            
		POS_FW_roueG.z = arriere;
		FW_roueG.transform.position = POS_FW_roueG;
            
		POS_FW_teepees.z = arriere;
		FW_teepees.transform.position = POS_FW_teepees;
		
		POS_FT_roueD.x = FT_roueD.transform.position.x;
		POS_FT_roueD.y = FT_roueD.transform.position.y;
		POS_FT_roueD.z = 3f;
		FT_roueD.transform.position = POS_FT_roueD;
		
		POS_FT_roueG.x = FT_roueG.transform.position.x;
		POS_FT_roueG.y = FT_roueG.transform.position.y;
		POS_FT_roueG.z = 3f;
		FT_roueG.transform.position = POS_FT_roueG;
		vieScriptG.vie.color = Color.white;
		vieScriptD.vie.color = Color.white;
		audioScript.compteurTheme = 2;
	}
        
	public void apparitionPrehistoire()
	{
		POS_FW_fond.z = arriere;
		FW_fond.transform.position = POS_FW_fond;

		POS_FW_cactus1.z = arriere;
		FW_cactus1.transform.position = POS_FW_cactus1;

		POS_FW_cactus2.z = arriere;
		FW_cactus2.transform.position = POS_FW_cactus2;

		POS_FW_cactus3.z = arriere;
		FW_cactus3.transform.position = POS_FW_cactus3;

		POS_FW_cactus4.z = arriere;
		FW_cactus4.transform.position = POS_FW_cactus4;

		POS_FW_panneau.z = arriere;
		FW_panneau.transform.position = POS_FW_panneau;

		POS_FW_flaque.z = arriere;
		FW_flaque.transform.position = POS_FW_flaque;

		POS_FW_village.z = arriere;
		FW_village.transform.position = POS_FW_village;

		POS_FW_roueD.z = arriere;
		FW_roueD.transform.position = POS_FW_roueD;

		POS_FW_roueG.z = arriere;
		FW_roueG.transform.position = POS_FW_roueG;

		POS_FW_teepees.z = arriere;
		FW_teepees.transform.position = POS_FW_teepees;
		POS_FT_fond.z = arriere;
		FT_fond.transform.position = POS_FT_fond;
            
		POS_FT_roueD.z = arriere;
		FT_roueD.transform.position = POS_FT_roueD;
            
		POS_FT_roueG.z = arriere;
		FT_roueG.transform.position = POS_FT_roueG;
            
		POS_FT_vaisseau1.z = arriere;
		FT_vaisseau1.transform.position = POS_FT_vaisseau1;
            
		POS_FT_vaisseau2.z = arriere;
		FT_vaisseau2.transform.position = POS_FT_vaisseau2;
            
		POS_FT_avion.z = arriere;
		FT_avion.transform.position = POS_FT_avion;
            
		POS_FT_trouNoire.z = arriere;
		FT_trouNoire.transform.position = POS_FT_trouNoire;
		
		POS_PR_roueD.x = PR_roueD.transform.position.x;
		POS_PR_roueD.y = PR_roueD.transform.position.y;
		POS_PR_roueD.z = 2f;
		PR_roueD.transform.position = POS_PR_roueD;
		
		POS_PR_roueG.x = PR_roueG.transform.position.x;
		POS_PR_roueG.y = PR_roueG.transform.position.y;
		POS_PR_roueG.z = 2f;
		PR_roueG.transform.position = POS_PR_roueG;
		vieScriptG.vie.color = Color.white;
		vieScriptD.vie.color = Color.white;
		audioScript.compteurTheme = 3;
	}

	void Awake()
    {
		// Position ou la note apparait au lancement de l'application
		transform.position = new Vector3(-6.198f, -3.198f, 4.0f);
        // Cree et positionne un objet qui sera la position cible de la note
        cible = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cible2 = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cible3 = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cible4 = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cible5 = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cible6 = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cible7 = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cible8 = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
		
        // Place l'objet de la position cible
        positionCible = cible.transform;
        positionCible2 = cible2.transform;
        positionCible3 = cible3.transform;
        positionCible4 = cible4.transform;
        positionCible5 = cible5.transform;
        positionCible6 = cible6.transform;
        positionCible7 = cible7.transform;
        positionCible8 = cible8.transform;
		
        positionCible.transform.localScale = new Vector3(0.0f, 1.0f, 0.15f);
        positionCible2.transform.localScale = new Vector3(0.0f, 1.0f, 0.15f);
        positionCible3.transform.localScale = new Vector3(0.0f, 1.0f, 0.15f);
        positionCible4.transform.localScale = new Vector3(0.0f, 1.0f, 0.15f);
        positionCible5.transform.localScale = new Vector3(0.0f, 1.0f, 0.15f);
        positionCible6.transform.localScale = new Vector3(0.0f, 1.0f, 0.15f);
        positionCible7.transform.localScale = new Vector3(0.0f, 1.0f, 0.15f);
        positionCible8.transform.localScale = new Vector3(0.0f, 1.0f, 0.15f);
		
		// Position cible -> 5.
        positionCible.transform.position = new Vector3(-6.198f, -3.198f, 4.0f);
        
		// Position cible -> 6
        positionCible2.transform.position = new Vector3(-8.609f, -2.39f, 4.0f);
		
		// Position cible -> 7
        positionCible3.transform.position = new Vector3(-9.485f, 0.007f, 4.0f);
		
		// Position cible -> 8
        positionCible4.transform.position = new Vector3(-8.518f, 2.369f, 4.0f);
		
		// Position cible -> 1
        positionCible5.transform.position = new Vector3(-6.201f, 3.276f, 4.0f);
		
		// Position cible -> 2
        positionCible6.transform.position = new Vector3(-3.825f, 2.339f, 4.0f);
		
		// Position cible -> 3
        positionCible7.transform.position = new Vector3(-2.948f, -0.052f, 4.0f);
		
		// Position cible -> 4
        positionCible8.transform.position = new Vector3(-3.912f, -2.417f, 4.0f);
		
        System.Random randomNote = new System.Random();
        int generationNote = randomNote.Next(1, 5);
        int generationNoteAcceleration = randomNote.Next(1, 6);
        int generationNotePerteVie = randomNote.Next(1, 6);
        int generationNoteRalentie = randomNote.Next(1, 6);
        int generationNoteNormale = randomNote.Next(1, 6);
        
        void SwitchAcceleration()
        {
	        switch (generationNoteAcceleration)
	        {
		        case 1:
			        ChangeSprite(noteAccelerationRouge); //red
			        break;
		        case 2:
			        ChangeSprite(noteAccelerationJaune); //yellow
			        break;
		        case 3:
			        ChangeSprite(noteAccelerationOrange); //orange
			        break;
		        case 4:
			        ChangeSprite(noteAccelerationBleu); //blue
			        break;
		        case 5:
			        ChangeSprite(noteAccelerationVert); //green
			        break;
	        }
	        count ++;
        }
        
        void SwitchPerteVie()
        {
	        switch (generationNotePerteVie)
	        {
		        case 1:
			        ChangeSprite(notePerteVieRouge); //red
			        break;
		        case 2:
			        ChangeSprite(notePerteVieJaune); //yellow
			        break;
		        case 3:
			        ChangeSprite(notePerteVieOrange); //orange
			        break;
		        case 4:
			        ChangeSprite(notePerteVieBleu); //blue
			        break;
		        case 5:
			        ChangeSprite(notePerteVieVert); //green
			        break;
	        }
	        count ++;
        }
        
        void SwitchRalenti()
        {
			
	        switch (generationNoteRalentie)
	        {
		        case 1:
			        ChangeSprite(noteRalentiRouge); //red
			        break;
		        case 2:
			        ChangeSprite(noteRalentiJaune); //yellow
			        break;
		        case 3:
			        ChangeSprite(noteRalentiOrange); //orange
			        break;
		        case 4:
			        ChangeSprite(noteRalentiBleu); //blue
			        break;
		        case 5:
			        ChangeSprite(noteRalentiVert); //green
			        break;
	        }
	        count ++;
        }
	
        void SwitchNoteNormale()
        {
	        switch (generationNoteNormale)
	        {
		        case 1:
			        ChangeSprite(redNote); //red
			        break;
		        case 2:
			        ChangeSprite(yellowNote); //yellow
			        break;
		        case 3:
			        ChangeSprite(orangeNote); //orange
			        break;
		        case 4:
			        ChangeSprite(blueNote); //blue
			        break;
		        case 5:
			        ChangeSprite(greenNote); //green
			        break;
	        }
	        count ++;
        }
	
        if (count == 4)
        {
	        ChangeSprite(noteInitiale);
	        count++;
        }
        else if (count == 38)
        {
	        ChangeSprite(noteFuture);
	        count++;
        }
        else if (count == 68)
        {
	        ChangeSprite(notePrehistoire);
	        count++;
        }
        else
        {
	        switch (generationNote)
	        {
		        case 1:
			        if (count % 5 == 1)
			        {
				        SwitchAcceleration();
			        }
			        else 
			        {
				        SwitchNoteNormale();
			        }
			        break;
		        case 2:
			        if (count % 5 == 1)
			        {
				        SwitchRalenti();
			        }
			        else
			        {
				        SwitchNoteNormale();
			        }
			        break;
		        case 3:
			        if (count % 5 == 1)
			        {
				        SwitchPerteVie();
			        }
			        else
			        {
				        SwitchNoteNormale();
			        }
			        break;
		        case 4:
			        if (count % 5 == 1)
			        {
				        SwitchNoteNormale();
			        }
			        else
			        {
				        SwitchNoteNormale();
			        }
			        break;
	        }

        }


		//	Debug.Log(count);
	}
    void Update()
    {
	    if (vieScriptG.vieValue == 0)
	    {
			transition.timeAffichage = 250;
			SceneManager.LoadScene("joueurGagnant", LoadSceneMode.Single);
		}
	    if (timeRemainingVieG > 0)
	    {
		    timeRemainingVieG -= 1;
	    }
	    else if (timeRemainingVieG < 0)
	    {
		    timeRemainingVieG = 0;
	    }
	    ///////////////////////////////////
	    if (timeRemainingAccelerationG > 0)
	    {
		    timeRemainingAccelerationG -= 1;
	    }
	    else
	    {
		    if (timeACG > 0)
		    {
			    mouvementRoueD.boostVitesse = -0.01f;
			    timeACG -= 1;
		    }
		    else if(timeACG == 0 && timeRLG == 0)
		    {

			    mouvementRoueD.boostVitesse = 0.0f;
		    }
	    }
	    /////////////////////////////////////
		
	    if (timeRemainingRalentiG > 0)
	    {
		    timeRemainingRalentiG -= 1;
	    }
	    else
	    {
		    if (timeRLG > 0)

		    {
			    mouvementRoueD.boostVitesse = 0.01f;
			    timeRLG -= 1;
		    }
		    else if(timeACG == 0 && timeRLG == 0)
		    {
			    mouvementRoueD.boostVitesse = 0.0f;
		    }
		
	    }

		// Augmente la vitesse de rotation de la roue
		// au fur et à meusure que le temps passefd
		
		float step = speed * Time.deltaTime / menuDemarrage.attribuSpeed + boostVitesse; // calculate distance to move

		// Champ du viseur dans lequel le joueur peut interagire avec la note
		if (Input.GetKeyDown("k") && this.gameObject.GetComponent<SpriteRenderer>().sprite == notePrehistoire)
		{
			if (!(triggerP1G.verifTrigger1G &&
			      triggerP4G.verifTrigger4G &&
			      triggerP3G.verifTrigger3G &&
			      triggerP2G.verifTrigger2G))
			{
				if (timeRemainingVieG == 0)
				{
					timeRemainingVieG += 2500;
					vieScriptG.vieValue -= 1;
					combo = 1;
				}
			} else if (this.transform.position.x >= 2.5f && //2
			           this.transform.position.x <= 3.4f && //4
			           this.transform.position.y >= -0.5f && //3
			           this.transform.position.y <= 0.5f)
			{
				apparitionPrehistoire();
			}
		}
		if (Input.GetKeyDown("k") && this.gameObject.GetComponent<SpriteRenderer>().sprite == noteFuture)
		{
			if (!(triggerP1G.verifTrigger1G &&
			      triggerP4G.verifTrigger4G &&
			      triggerP3G.verifTrigger3G &&
			      triggerP2G.verifTrigger2G))
			{
				if (timeRemainingVieG == 0)
				{
					timeRemainingVieG += 2500;
					vieScriptG.vieValue -= 1;
					combo = 1;
				}
			} else if (this.transform.position.x >= 2.5f && //2
			           this.transform.position.x <= 3.4f && //4
			           this.transform.position.y >= -0.5f && //3
			           this.transform.position.y <= 0.5f)
			{
				apparitionFuture();
			}
		}
		if (Input.GetKeyDown("q") && this.gameObject.GetComponent<SpriteRenderer>().sprite == notePerteVieJaune ||
		    Input.GetKeyDown("w") && this.gameObject.GetComponent<SpriteRenderer>().sprite == notePerteVieRouge ||
		    Input.GetKeyDown("e") && this.gameObject.GetComponent<SpriteRenderer>().sprite == notePerteVieBleu ||
		    Input.GetKeyDown("r") && this.gameObject.GetComponent<SpriteRenderer>().sprite == notePerteVieVert ||
		    Input.GetKeyDown("t") && this.gameObject.GetComponent<SpriteRenderer>().sprite == notePerteVieOrange)
		{
			if (!(triggerP1G.verifTrigger1G &&
			      triggerP4G.verifTrigger4G &&
			      triggerP3G.verifTrigger3G &&
			      triggerP2G.verifTrigger2G))
			{
				if (timeRemainingVieG == 0)
				{
					timeRemainingVieG += 2500;
					vieScriptG.vieValue -= 1;
					combo = 1;
				}
			} else if (this.transform.position.x <= -2.5f && //2
			           this.transform.position.x >= -3.4f && //4
			           this.transform.position.y >= -0.5f && //3
			           this.transform.position.y <= 0.5f)
			{
				ChangeSprite(notePerteVieTouche);
				if (timeRemainingVieG == 0)
				{
					timeRemainingVieG += 2500;
					vieScriptG.vieValue -= 1;
					combo = 1;
				}
			}
		}
		else if (Input.GetKeyDown("q") && this.gameObject.GetComponent<SpriteRenderer>().sprite == noteRalentiJaune ||
		    Input.GetKeyDown("w") && this.gameObject.GetComponent<SpriteRenderer>().sprite == noteRalentiRouge ||
		    Input.GetKeyDown("e") && this.gameObject.GetComponent<SpriteRenderer>().sprite == noteRalentiBleu ||
		    Input.GetKeyDown("r") && this.gameObject.GetComponent<SpriteRenderer>().sprite == noteRalentiVert ||
		    Input.GetKeyDown("t") && this.gameObject.GetComponent<SpriteRenderer>().sprite == noteRalentiOrange)
		{
			if (!(triggerP1G.verifTrigger1G &&
			      triggerP4G.verifTrigger4G &&
			      triggerP3G.verifTrigger3G &&
			      triggerP2G.verifTrigger2G))
			{
				if (timeRemainingVieG == 0)
				{
					timeRemainingVieG += 2500;
					vieScriptG.vieValue -= 1;
					combo = 1;
				}
			} else if (this.transform.position.x <= -2.5f && //2
			           this.transform.position.x >= -3.4f && //4
			           this.transform.position.y >= -0.5f && //3
			           this.transform.position.y <= 0.5f)
			{
				ChangeSprite(noteRalentiTouche);
				timeRLG += 1000;
				timeRemainingRalentiG += 1000;
				mouvementRoueD.boostVitesse = -0.01f;
			}
		}
		else if (Input.GetKeyDown("q") && this.gameObject.GetComponent<SpriteRenderer>().sprite == noteAccelerationJaune ||
		         Input.GetKeyDown("w") && this.gameObject.GetComponent<SpriteRenderer>().sprite == noteAccelerationRouge ||
		         Input.GetKeyDown("e") && this.gameObject.GetComponent<SpriteRenderer>().sprite == noteAccelerationBleu ||
		         Input.GetKeyDown("r") && this.gameObject.GetComponent<SpriteRenderer>().sprite == noteAccelerationVert ||
		         Input.GetKeyDown("t") && this.gameObject.GetComponent<SpriteRenderer>().sprite == noteAccelerationOrange)
		{
			if (!(triggerP1G.verifTrigger1G &&
			      triggerP4G.verifTrigger4G &&
			      triggerP3G.verifTrigger3G &&
			      triggerP2G.verifTrigger2G))
			{
				if (timeRemainingVieG == 0)
				{
					timeRemainingVieG += 2500;
					vieScriptG.vieValue -= 1;
					combo = 1;
				}
			} else if (this.transform.position.x <= -2.5f && //2
			           this.transform.position.x >= -3.4f && //4
			           this.transform.position.y >= -0.5f && //3
			           this.transform.position.y <= 0.5f)
			{
				ChangeSprite(noteAccelerationTouche);
				timeACG += 1000;
				timeRemainingAccelerationG += 1000;
				mouvementRoueD.boostVitesse = 0.01f;
			}
		}
		else if (Input.GetKeyDown("q") && this.gameObject.GetComponent<SpriteRenderer>().sprite == yellowNote ||
		          Input.GetKeyDown("w") && this.gameObject.GetComponent<SpriteRenderer>().sprite == redNote ||
		          Input.GetKeyDown("e") && this.gameObject.GetComponent<SpriteRenderer>().sprite == blueNote ||
		          Input.GetKeyDown("r") && this.gameObject.GetComponent<SpriteRenderer>().sprite == greenNote ||
		          Input.GetKeyDown("t") && this.gameObject.GetComponent<SpriteRenderer>().sprite == orangeNote)
		{
			if (!(triggerP1G.verifTrigger1G &&
			      triggerP4G.verifTrigger4G &&
			      triggerP3G.verifTrigger3G &&
			      triggerP2G.verifTrigger2G))
			{
				//ChangeSprite(noteErreur);
				//Debug.Log("affiche X");
				
				if (timeRemainingVieG == 0)
				{
					timeRemainingVieG += 2500;
					vieScriptG.vieValue -= 1;
					combo = 1;
				}
			} else if (this.transform.position.x <= -2.5f && //2
			           this.transform.position.x >= -3.4f && //4
			           this.transform.position.y >= -0.5f && //3
			           this.transform.position.y <= 0.5f)
			{
				switch (combo)
				{
					case 1:
						if (this.gameObject.GetComponent<SpriteRenderer>().sprite != score10)
						{
							scoreScriptG.scoreValue += 10;
							ChangeSprite(score10);
							combo += 1;
						}break;
					case 2:
						if (this.gameObject.GetComponent<SpriteRenderer>().sprite != score20)
						{
							scoreScriptG.scoreValue += 20;
							ChangeSprite(score20);
							combo += 1;
						}break;
					case 3:
						if (this.gameObject.GetComponent<SpriteRenderer>().sprite != score30)
						{
							scoreScriptG.scoreValue += 30;
							ChangeSprite(score30);
							combo += 1;
						}break;
					case 4:
						if (this.gameObject.GetComponent<SpriteRenderer>().sprite != score40)
						{
							scoreScriptG.scoreValue += 40;
							ChangeSprite(score40);
							combo += 1;
						}break;
					case 5:
						if (this.gameObject.GetComponent<SpriteRenderer>().sprite != score50)
						{
							scoreScriptG.scoreValue += 50;
							ChangeSprite(score50);
						}break;
				}
			}
		}  

		// De la 5 vers la 6
	    if (this.transform.position.x != -8.609f &&
		    this.transform.position.y != -2.39f &&
		    isTargetTwoReached == false){
		    transform.position = Vector3.MoveTowards(transform.position, positionCible2.position, step);}
		 
		 // De la 6 vers la 7
		else if(this.transform.position.x != -9.485f &&
				this.transform.position.y != 0.007f &&
				isTargetThreeReached == false) {
			 // Quand la note arrive sur le point 7	
			 if (!isClonedThisRow){
				 // Génère une nouvelle note sur le point 5
				 Instantiate(this, new Vector3(-6.198f, -3.198f, 4.0f), Quaternion.identity);} 
				isClonedThisRow = true;
				transform.position = Vector3.MoveTowards(transform.position, positionCible3.position, step); 
				isTargetTwoReached = true;}
		 
		 // De la 7 vers la 8
		else if(this.transform.position.x != -8.518f &&
				this.transform.position.y != 2.369f &&
				isTargetFourReached == false){
				transform.position = Vector3.MoveTowards(transform.position, positionCible4.position, step);
				isTargetThreeReached = true;}
		
		// De la 8 vers la 1
		else if(this.transform.position.x != -6.201f &&
				this.transform.position.y != 3.276f &&
				isTargetFiveReached == false){
				transform.position = Vector3.MoveTowards(transform.position, positionCible5.position, step);
				isTargetFourReached = true;}
		
		// De la 1 vers la 2
		else if(this.transform.position.x != -3.825f &&
				this.transform.position.y != 2.339f &&
				isTargetSixReached == false){
				transform.position = Vector3.MoveTowards(transform.position, positionCible6.position, step);
				isTargetFiveReached = true;}
		
		// De la 2 vers la 3
		else if(this.transform.position.x != -2.948f &&
				this.transform.position.y != -0.052f &&
				isTargetSevenReached == false){
				transform.position = Vector3.MoveTowards(transform.position, positionCible7.position, step);
				isTargetSixReached = true;}
		
		// De la 3 vers la 4
		else if(this.transform.position.x != -3.912f &&
				this.transform.position.y != -2.417f &&
				isTargetEightReached == false){
				transform.position = Vector3.MoveTowards(transform.position, positionCible8.position, step);
				isTargetSevenReached = true;}
	
	// Bouge de la position 4 vers la position 5
	else if (this.transform.position.x != -6.198f &&
			 this.transform.position.y != -3.198f &&
	         isTargetOneReached == false){
			 if (this.gameObject.GetComponent<SpriteRenderer>().sprite != score10 &&
			     this.gameObject.GetComponent<SpriteRenderer>().sprite != score20 &&
			     this.gameObject.GetComponent<SpriteRenderer>().sprite != score30 &&
			     this.gameObject.GetComponent<SpriteRenderer>().sprite != score40 &&
			     this.gameObject.GetComponent<SpriteRenderer>().sprite != score50 &&
			     this.gameObject.GetComponent<SpriteRenderer>().sprite != noteAccelerationTouche &&
			     this.gameObject.GetComponent<SpriteRenderer>().sprite != noteRalentiTouche &&
			     this.gameObject.GetComponent<SpriteRenderer>().sprite != notePerteVieBleu &&
			     this.gameObject.GetComponent<SpriteRenderer>().sprite != notePerteVieJaune &&
			     this.gameObject.GetComponent<SpriteRenderer>().sprite != notePerteVieOrange &&
			     this.gameObject.GetComponent<SpriteRenderer>().sprite != notePerteVieRouge &&
			     this.gameObject.GetComponent<SpriteRenderer>().sprite != notePerteVieVert &&
			     this.gameObject.GetComponent<SpriteRenderer>().sprite != notePerteVieTouche &&
			     this.gameObject.GetComponent<SpriteRenderer>().sprite != noteInitiale &&
				 this.gameObject.GetComponent<SpriteRenderer>().sprite != notePrehistoire &&
				 this.gameObject.GetComponent<SpriteRenderer>().sprite != noteFuture)
			 {
				 if (timeRemainingVieG == 0)
				 {
					 timeRemainingVieG += 5000;
					 vieScriptG.vieValue -= 1;
					 combo = 1;
				 }
			 }
		transform.position = Vector3.MoveTowards(transform.position, positionCible.position, step);
		isTargetEightReached = true;}
		 else{
		DestroyAll();
		 }
    }
}
