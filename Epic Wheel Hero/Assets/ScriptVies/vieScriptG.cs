using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vieScriptG : MonoBehaviour
{

    public static int vieValue = 4;
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
			case 1:
			vie.text = "0";
			break;
			case 2:
			vie.text = "1";
			break;
			case 3:
			vie.text = "2";
			break;
			case 4:
			vie.text = "3";
			break;
    }
	}
}