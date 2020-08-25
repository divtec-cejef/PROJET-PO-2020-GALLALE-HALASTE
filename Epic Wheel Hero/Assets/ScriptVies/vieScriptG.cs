using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vieScriptG : MonoBehaviour
{

    public static int vieValue = 24;
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
			vie.text = "0";
			break;
			case 8:
			vie.text = "1";
			break;
			case 16:
			vie.text = "2";
			break;
			case 24:
			vie.text = "3";
			break;
    }
	}
}