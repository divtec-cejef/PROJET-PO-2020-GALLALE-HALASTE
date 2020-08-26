using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class mouvementRoueD : MonoBehaviour
{
	public Sprite blueNote;
	public Sprite greenNote;
	public Sprite redNote;
	public Sprite orangeNote;
	public Sprite yellowNote;
	public Sprite verifNote;

	// Ajuste la vitesse du déplacement de la note
	public float speed = 1.5f;

	//timer
	public static int timeRemainingD = 5000;
	
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
		transform.position = new Vector3(6.198f, 3.198f, 4.0f);

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
		positionCible.transform.position = new Vector3(6.198f, 3.198f, 4.0f);

		// Position cible -> 6
		positionCible2.transform.position = new Vector3(3.98f, -2.4f, 4.0f);

		// Position cible -> 7
		positionCible3.transform.position = new Vector3(3.013f, -0.037f, 4.0f);

		// Position cible -> 8
		positionCible4.transform.position = new Vector3(3.885f, 2.36f, 4.0f);
		
		// Position cible -> 1
		positionCible5.transform.position = new Vector3(6.272f, 3.295f, 4.0f);
		
		// Position cible -> 2
		positionCible6.transform.position = new Vector3(8.585f, 2.394f, 4.0f);

		// Position cible -> 3
		positionCible7.transform.position = new Vector3(9.547f, 0.022f, 4.0f);

		// Position cible -> 4
		positionCible8.transform.position = new Vector3(8.609f, -2.39f, 4.0f);
		
		System.Random randomNote = new System.Random();
		int directionChoice = randomNote.Next(1, 6); 
		
		switch (directionChoice)
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
	}
	void Update()
	{
		if (timeRemainingD > 0)
		{
			timeRemainingD -= 1;
		}
		else if (timeRemainingD < 0)
		{
			timeRemainingD = 0;
		}
		// Augmente la vitesse de rotation de la roue
		// au fur et à meusure que le temps passe
		speed += Time.deltaTime / 150;
		float step = speed * Time.deltaTime; // calculate distance to move
		
		// Champ du viseur dans lequel le joueur peut interagire avec la note
		if (Input.GetButtonDown("Fire2"))
		{
			if (!(triggerP1D.verifTrigger1D &&
			      triggerP4D.verifTrigger4D &&
			      triggerP3D.verifTrigger3D &&
			      triggerP2D.verifTrigger2D))
			{
				if (timeRemainingD == 0)
				{
					timeRemainingD += 5000;
					vieScriptD.vieValue -= 1;
				}
			} else if (this.transform.position.x >= 2.5f && //2
			           this.transform.position.x <= 3.4f && //4
			           this.transform.position.y >= -0.5f && //3
			           this.transform.position.y <= 0.5f)
			{
				if (this.gameObject.GetComponent<SpriteRenderer>().sprite != verifNote)
				{
					Debug.Log("je rajoute les points");
					scoreScriptD.scoreValue += 10;
					ChangeSprite(verifNote);
				}
			}
		} 

		
		// Bouge de la position 5 vers la position 4
		if (this.transform.position.x != 8.609f &&
			this.transform.position.y != -2.39f &&
			isTargetOneReached == false){
			transform.position = Vector3.MoveTowards(transform.position, positionCible8.position, step);}
		
		// De la 4 vers la 3
		else if (this.transform.position.x != 9.547f &&
				this.transform.position.y != 0.022f &&
				isTargetTwoReached == false){ 
			// Quand la note arrive sur le point 3
			if (!isClonedThisRow){
				// Génère une nouvelle note sur le point 5
				Instantiate(this, new Vector3(6.272f, -3.18f, 4.0f), Quaternion.identity);}
				isClonedThisRow = true;
				transform.position = Vector3.MoveTowards(transform.position, positionCible7.position, step);
				isTargetOneReached = true;}
		
		// De la 3 vers la 2
		else if (this.transform.position.x != 8.585f &&
				this.transform.position.y != 2.394f &&
				isTargetThreeReached == false){
				transform.position = Vector3.MoveTowards(transform.position, positionCible6.position, step);
				isTargetTwoReached = true;}
		
		// De la 2 vers la 1
		else if (this.transform.position.x != 6.272f &&
				this.transform.position.y != 3.295f &&
				isTargetFourReached == false){
				transform.position = Vector3.MoveTowards(transform.position, positionCible5.position, step);
				isTargetThreeReached = true;}

		// De la 1 vers la 8
		else if (this.transform.position.x != 3.885f &&
				this.transform.position.y != 2.36f &&
				isTargetFiveReached == false){
				transform.position = Vector3.MoveTowards(transform.position, positionCible4.position, step);
				isTargetFourReached = true;}

		// De la 8 vers la 7
		else if (this.transform.position.x != 3.013f &&
				this.transform.position.y != -0.037f &&
				isTargetSixReached == false){
				transform.position = Vector3.MoveTowards(transform.position, positionCible3.position, step);
				isTargetFiveReached = true;}

		// De la 7 vers la 6
		else if (this.transform.position.x != 3.98f &&
				this.transform.position.y != -2.4f &&
				isTargetSevenReached == false){
				transform.position = Vector3.MoveTowards(transform.position, positionCible2.position, step);
				isTargetSixReached = true;}

		// De la 6 vers la 5
		else if (this.transform.position.x != 6.198f &&
				this.transform.position.y != -3.198f &&
				isTargetEightReached == false){
				if (this.gameObject.GetComponent<SpriteRenderer>().sprite != verifNote)
				{
					if (timeRemainingD == 0)
					{
						timeRemainingD += 5000;
						vieScriptD.vieValue -= 1;
					}
				}
				transform.position = Vector3.MoveTowards(transform.position, positionCible.position, step);
				isTargetSevenReached = true;}
				else{
				DestroyAll();
				}
	}
}
