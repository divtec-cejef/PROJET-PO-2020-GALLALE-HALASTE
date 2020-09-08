using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class vieScriptD : MonoBehaviour
{
    public static int vieValue = 3;
    TextMeshProUGUI vie;

	
    // Start is called before the first frame update
    void Start()
    {
        vie = GetComponent<TMPro.TextMeshProUGUI> ();
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
                vie.text = "\uE06E";
                break;
            case 2:
                vie.text = "\uE06E \uE06E";
                break;
            case 3:
                vie.text = "\uE06E \uE06E \uE06E";
                break;
        }
    }
}
