using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move4to5 : MonoBehaviour
{
	
	public Sprite blueNote;
	public Sprite greenNote;
	public Sprite redNote;
	
	// Ajuste la vitesse du déplacement de la note
    public float speed = -0.05f;

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
        transform.position = new Vector3(2.53f, -2.65f, 0.0f);

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
        positionCible.transform.position = new Vector3(-0.02f, -3.82f, 0.0f);
		
		// Position cible -> 6
        positionCible2.transform.position = new Vector3(-2.62f, -2.62f, 0.0f);
		
		// Position cible -> 7
        positionCible3.transform.position = new Vector3(-3.7f, -0.01f, 0.0f);
		
		// Position cible -> 8
        positionCible4.transform.position = new Vector3(-2.57f, 2.5f, 0.0f);
		
		// Position cible -> 1
        positionCible5.transform.position = new Vector3(-0.1f, 3.31f, 0.0f);
		
		// Position cible -> 2
        positionCible6.transform.position = new Vector3(2.283f, 2.433f, 0.0f);
		
		// Position cible -> 3
        positionCible7.transform.position = new Vector3(3.27f, -0.06f, 0.0f);
		
		// Position cible -> 4
        positionCible8.transform.position = new Vector3(2.53f, -2.65f, 0.0f);
		
		ChangeSprite(redNote);

    }

    void Update()
    {
		
		float step =  speed * Time.deltaTime; // calculate distance to move

	if( this.transform.position.x >= -1.3f &&
		this.transform.position.x <= 2f &&
		this.transform.position.y >= 3f)
	{
		if (Input.GetButtonDown("Fire1"))
        {
            ChangeSprite(greenNote);
        }
	}

        // Bouge de la position 4 vers la position 5
		if (this.transform.position.x != -0.2f &&
			this.transform.position.y != -3.82f &&
			isTargetOneReached == false){
			transform.position = Vector3.MoveTowards(transform.position, positionCible.position, step);
			
			if(this.transform.position.x <= 1f &&
				this.transform.position.y <= 0f){
				ChangeSprite(blueNote);
			}
		}
		
		// De la 5 vers la 6
		else if(this.transform.position.x != -2.62f &&
				this.transform.position.y != -2.62f &&
				isTargetTwoReached == false){
					
				// Quand la note arrive sur le point 5	
				if (!isClonedThisRow){
					// Génère une nouvelle note
					Instantiate(this, new Vector3(2.53f, -2.65f, 0.0f), Quaternion.identity);
				}
				isClonedThisRow = true;
				
        transform.position = Vector3.MoveTowards(transform.position, positionCible2.position, step);
		isTargetOneReached = true;
		}
		
		// De la 6 vers la 7
		else if(this.transform.position.x != -3.7f &&
				this.transform.position.y != -0.01f &&
				isTargetThreeReached == false){
        transform.position = Vector3.MoveTowards(transform.position, positionCible3.position, step);
		isTargetTwoReached = true;
		}
		
		// De la 7 vers la 8
		else if(this.transform.position.x != -2.57f &&
				this.transform.position.y != 2.5f &&
				isTargetFourReached == false){
        transform.position = Vector3.MoveTowards(transform.position, positionCible4.position, step);
		isTargetThreeReached = true;
		}
		
		// De la 8 vers la 1
		else if(this.transform.position.x != -0.1f &&
				this.transform.position.y != 3.31f &&
				isTargetFiveReached == false){
        transform.position = Vector3.MoveTowards(transform.position, positionCible5.position, step);
		isTargetFourReached = true;
		}
		
		// De la 1 vers la 2
		else if(this.transform.position.x != 2.283f &&
				this.transform.position.y != 2.433f &&
				isTargetSixReached == false){
        transform.position = Vector3.MoveTowards(transform.position, positionCible6.position, step);
		isTargetFiveReached = true;
		}
		
		// De la 2 vers la 3
		else if(this.transform.position.x != 3.27f &&
				this.transform.position.y != -0.06f &&
				isTargetSevenReached == false){
        transform.position = Vector3.MoveTowards(transform.position, positionCible7.position, step);
		isTargetSixReached = true;
		}
		
		// De la 3 vers la 4
		else if(this.transform.position.x != 2.52f &&
				this.transform.position.y != -2.65f &&
				isTargetEightReached == false){
        transform.position = Vector3.MoveTowards(transform.position, positionCible8.position, step);
		isTargetSevenReached = true;
		}else {
			DestroyAll();
		}
    }
}
