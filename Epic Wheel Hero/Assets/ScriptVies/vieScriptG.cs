using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vieScriptG : MonoBehaviour
{

    public static int vieValue = 3;
	Text vie;
    
	
    // Start is called before the first frame update
    void Start()
    {
        vie = GetComponent<Text> ();
    }
    
    // Update is called once per frame
    void Update()
    {
		switch (vieValue)
		{
			case 0:
				vie.text = "";
				break;
			case 1:
				vie.text = "❤";
				break;
			case 2:
				vie.text = "❤❤";
				break;
			case 3:
				vie.text = "❤❤❤";
				break;
    }
	}
}