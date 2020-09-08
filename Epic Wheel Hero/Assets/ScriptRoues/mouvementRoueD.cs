using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class mouvementRoueD : MonoBehaviour
{
	
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
	//*****NOTE PERTE VIE*****//
	public Sprite notePerteVieBleu;
	public Sprite notePerteVieJaune;
	public Sprite notePerteVieOrange;
	public Sprite notePerteVieRouge;
	public Sprite notePerteVieVert;
	//*******NOTE RALENTI*****//
	public Sprite noteRalentiBleu;
	public Sprite noteRalentiJaune;
	public Sprite noteRalentiOrange;
	public Sprite noteRalentiRouge;
	public Sprite noteRalentiVert;
	
	// Ajuste la vitesse du déplacement de la note
	public float speed = 1.5f;

	public int count = 4;
	//timer
	public static int timeRemainingVieD = 5000;

	public static int timeRemainingAccelerationD = 0;
	//combo
	public static int combo = 0;
	// Gère la vitesse des notes, change avec les notes acceleration et decceleration
	public int boostVitesse = 1;
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
	void Awake()
	{
		// Position ou la note apparait au lancement de l'application
		transform.position = new Vector3(6.198f, -3.198f, 4.0f);

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
		positionCible.transform.position = new Vector3(6.198f, -3.198f, 4.0f);

		// Position cible -> 6
		positionCible2.transform.position = new Vector3(3.912f, -2.417f, 4.0f);

		// Position cible -> 7
		positionCible3.transform.position = new Vector3(2.948f, -0.052f, 4.0f);

		// Position cible -> 8
		positionCible4.transform.position = new Vector3(3.825f, 2.339f, 4.0f);
		
		// Position cible -> 1
		positionCible5.transform.position = new Vector3(6.201f, 3.276f, 4.0f);
		
		// Position cible -> 2
		positionCible6.transform.position = new Vector3(8.518f, 2.369f, 4.0f);

		// Position cible -> 3
		positionCible7.transform.position = new Vector3(9.485f, 0.007f, 4.0f);

		// Position cible -> 4
		positionCible8.transform.position = new Vector3(8.609f, -2.39f, 4.0f);


		
		
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

		if (count == 1)
		{
			ChangeSprite(noteInitiale);
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
		if (timeRemainingVieD > 0)
		{
			timeRemainingVieD -= 1;
		}
		else if (timeRemainingVieD < 0)
		{
			timeRemainingVieD = 0;
		}
		if (timeRemainingAccelerationD > 0)
		{
			timeRemainingAccelerationD -= 1;
		}
		else if (timeRemainingAccelerationD < 0)
		{
			timeRemainingAccelerationD = 0;
		}
		
		Debug.Log(mouvementRoueG.boostVitesse);
		// Augmente la vitesse de rotation de la roue
		// au fur et à meusure que le temps passe
		speed += Time.deltaTime / 150;
		float step = speed * Time.deltaTime; // calculate distance to move
		
		// Champ du viseur dans lequel le joueur peut interagire avec la note
		
		
		
		if (Input.GetKeyDown("a") && this.gameObject.GetComponent<SpriteRenderer>().sprite == noteAccelerationJaune ||
		    Input.GetKeyDown("s") && this.gameObject.GetComponent<SpriteRenderer>().sprite == noteAccelerationRouge ||
		    Input.GetKeyDown("d") && this.gameObject.GetComponent<SpriteRenderer>().sprite == noteAccelerationBleu ||
		    Input.GetKeyDown("f") && this.gameObject.GetComponent<SpriteRenderer>().sprite == noteAccelerationVert ||
		    Input.GetKeyDown("g") && this.gameObject.GetComponent<SpriteRenderer>().sprite == noteAccelerationOrange)
		{
			if (!(triggerP1D.verifTrigger1D &&
			      triggerP4D.verifTrigger4D &&
			      triggerP3D.verifTrigger3D &&
			      triggerP2D.verifTrigger2D))
			{
				if (timeRemainingVieD == 0)
				{
					timeRemainingVieD += 5000;
					vieScriptD.vieValue -= 1;
					combo = 1;
				}
			} else if (this.transform.position.x >= 2.5f && //2
			           this.transform.position.x <= 3.4f && //4
			           this.transform.position.y >= -0.5f && //3
			           this.transform.position.y <= 0.5f)
			{
				timeRemainingAccelerationD = 5000;
				if (timeRemainingAccelerationD > 0)
					Debug.Log("entre dans le if");
				{
					while (timeRemainingAccelerationD != 0)
					{
						Debug.Log("boost");
						mouvementRoueG.boostVitesse = 2f;
					}
					Debug.Log("remise normale");
					mouvementRoueG.boostVitesse = 0.0f;
				}
			}
		}
		else if (Input.GetKeyDown("a") && this.gameObject.GetComponent<SpriteRenderer>().sprite == yellowNote ||
		          Input.GetKeyDown("s") && this.gameObject.GetComponent<SpriteRenderer>().sprite == redNote ||
		          Input.GetKeyDown("d") && this.gameObject.GetComponent<SpriteRenderer>().sprite == blueNote ||
		          Input.GetKeyDown("f") && this.gameObject.GetComponent<SpriteRenderer>().sprite == greenNote ||
		          Input.GetKeyDown("g") && this.gameObject.GetComponent<SpriteRenderer>().sprite == orangeNote)
		{
			if (!(triggerP1D.verifTrigger1D &&
			      triggerP4D.verifTrigger4D &&
			      triggerP3D.verifTrigger3D &&
			      triggerP2D.verifTrigger2D))
			{
				//ChangeSprite(noteErreur);
				//Debug.Log("affiche X");
				
				if (timeRemainingVieD == 0)
				{
					timeRemainingVieD += 5000;
					vieScriptD.vieValue -= 1;
					combo = 1;
				}
			} else if (this.transform.position.x >= 2.5f && //2
			           this.transform.position.x <= 3.4f && //4
			           this.transform.position.y >= -0.5f && //3
			           this.transform.position.y <= 0.5f)
			{
				switch (combo)
				{
					case 1:
						if (this.gameObject.GetComponent<SpriteRenderer>().sprite != score10)
						{
							scoreScriptD.scoreValue += 10;
							ChangeSprite(score10);
							combo += 1;
						}break;
					case 2:
						if (this.gameObject.GetComponent<SpriteRenderer>().sprite != score20)
						{
							scoreScriptD.scoreValue += 20;
							ChangeSprite(score20);
							combo += 1;
						}break;
					case 3:
						if (this.gameObject.GetComponent<SpriteRenderer>().sprite != score30)
						{
							scoreScriptD.scoreValue += 30;
							ChangeSprite(score30);
							combo += 1;
						}break;
					case 4:
						if (this.gameObject.GetComponent<SpriteRenderer>().sprite != score40)
						{
							scoreScriptD.scoreValue += 40;
							ChangeSprite(score40);
							combo += 1;
						}break;
					case 5:
						if (this.gameObject.GetComponent<SpriteRenderer>().sprite != score50)
						{
							scoreScriptD.scoreValue += 50;
							ChangeSprite(score50);
						}break;
				}
			}
		}  

		
		// Bouge de la position 5 vers la position 4
		if (this.transform.position.x != 8.609f &&
			this.transform.position.y != -2.39f &&
			isTargetOneReached == false){
			transform.position = Vector3.MoveTowards(transform.position, positionCible8.position, step);}
		
		// De la 4 vers la 3
		else if (this.transform.position.x != 9.485f &&
				this.transform.position.y != 0.007f &&
				isTargetTwoReached == false){ 
			// Quand la note arrive sur le point 3
			if (!isClonedThisRow){
				// Génère une nouvelle note sur le point 5
				Instantiate(this, new Vector3(6.198f, -3.198f, 4.0f), Quaternion.identity);}
				isClonedThisRow = true;
				transform.position = Vector3.MoveTowards(transform.position, positionCible7.position, step);
				isTargetOneReached = true;}
		
		// De la 3 vers la 2
		else if (this.transform.position.x != 8.518f &&
				this.transform.position.y != 2.369f &&
				isTargetThreeReached == false){
				transform.position = Vector3.MoveTowards(transform.position, positionCible6.position, step);
				isTargetTwoReached = true;}
		
		// De la 2 vers la 1
		else if (this.transform.position.x != 6.201f &&
				this.transform.position.y != 3.276f &&
				isTargetFourReached == false){
				transform.position = Vector3.MoveTowards(transform.position, positionCible5.position, step);
				isTargetThreeReached = true;}

		// De la 1 vers la 8
		else if (this.transform.position.x != 3.825f &&
				this.transform.position.y != 2.339f &&
				isTargetFiveReached == false){
				transform.position = Vector3.MoveTowards(transform.position, positionCible4.position, step);
				isTargetFourReached = true;}

		// De la 8 vers la 7
		else if (this.transform.position.x != 2.948f &&
				this.transform.position.y != -0.052f &&
				isTargetSixReached == false){
				transform.position = Vector3.MoveTowards(transform.position, positionCible3.position, step);
				isTargetFiveReached = true;}

		// De la 7 vers la 6
		else if (this.transform.position.x != 3.912f &&
				this.transform.position.y != -2.417f &&
				isTargetSevenReached == false){
				transform.position = Vector3.MoveTowards(transform.position, positionCible2.position, step);
				isTargetSixReached = true;}

		// De la 6 vers la 5
		else if (this.transform.position.x != 6.198f &&
				this.transform.position.y != -3.198f &&
				isTargetEightReached == false){
			if (this.gameObject.GetComponent<SpriteRenderer>().sprite != score10 &&
			    this.gameObject.GetComponent<SpriteRenderer>().sprite != score20 &&
			    this.gameObject.GetComponent<SpriteRenderer>().sprite != score30 &&
			    this.gameObject.GetComponent<SpriteRenderer>().sprite != score40 &&
			    this.gameObject.GetComponent<SpriteRenderer>().sprite != score50 )
			{
				if (timeRemainingVieD == 0)
				{
					timeRemainingVieD += 5000;
					vieScriptD.vieValue -= 1;
					combo = 1;
				}
			}
				transform.position = Vector3.MoveTowards(transform.position, positionCible.position, step);
				isTargetSevenReached = true;}
				else{
				DestroyAll();
				}
	}
}
