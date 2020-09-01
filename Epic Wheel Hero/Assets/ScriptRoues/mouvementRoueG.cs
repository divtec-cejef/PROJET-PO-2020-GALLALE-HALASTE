using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class mouvementRoueG : MonoBehaviour
{
	public Sprite blueNote;
	public Sprite greenNote;
	public Sprite redNote;
	public Sprite orangeNote;
	public Sprite yellowNote;
	public Sprite score10;
	public Sprite score20;
	public Sprite score30;
	public Sprite score40;
	public Sprite score50;
	
	// Ajuste la vitesse du déplacement de la note
    public float speed = 1.5f;

    //timer
    public static int timeRemainingG = 5000;
	//combo
	public static int combo = 1;
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
	void DestroyAll(){
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
		int directionChoice = randomNote.Next(1, 6); 
		
		switch (directionChoice)
		{
			case 1:
				ChangeSprite(orangeNote);
				break;
			case 2:
				ChangeSprite(blueNote);
				break;
			case 3:
				ChangeSprite(greenNote);
				break;
			case 4:
				ChangeSprite(redNote);
				break;
			case 5:
				ChangeSprite(yellowNote);
				break;
		}
	}
	
	
    void Update()
    {
	    if (timeRemainingG > 0)
	    {
		    timeRemainingG -= 1;
	    }
	    else if (timeRemainingG < 0)
	    {
		    timeRemainingG = 0;
	    }

	    // Augmente la vitesse de rotation de la roue
		// au fur et à meusure que le temps passe
		speed += Time.deltaTime / 150 * boostVitesse;
		float step =  speed * Time.deltaTime; // calculate distance to move

		// Champ du viseur dans lequel le joueur peut interagire avec la note
		if (Input.GetKeyDown("q") && this.gameObject.GetComponent<SpriteRenderer>().sprite == yellowNote ||
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
				if (timeRemainingG == 0)
				{
					timeRemainingG += 5000;
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
		 if(this.transform.position.x != -8.609f &&
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
			     this.gameObject.GetComponent<SpriteRenderer>().sprite != score50 )
			 {
				 if (timeRemainingG == 0)
				 {
					 timeRemainingG += 5000;
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
