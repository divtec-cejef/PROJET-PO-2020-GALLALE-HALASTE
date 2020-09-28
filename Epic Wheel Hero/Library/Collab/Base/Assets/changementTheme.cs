using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    /*
     * Retourne sur quel theme l'on est actuellement
     * 1 = Far West, 2 = future, 3 = préhistoire
     */
    public static int theme = 1;
    private static float arriere = 50f;

    // Far West
    private static GameObject FW_fond;
    private static GameObject FW_cactus1;
    private static GameObject FW_cactus2;
    private static GameObject FW_cactus3;
    private static GameObject FW_cactus4;
    private static GameObject FW_flaque;
    private static GameObject FW_village;
    private static GameObject FW_panneau;
    private static GameObject FW_roueG;
    private static GameObject FW_roueD;
    private static GameObject FW_teepees;

    // Future
    private static GameObject FT_fond;
    private static GameObject FT_vaisseau1;
    private static GameObject FT_vaisseau2;
    private static GameObject FT_avion;
    private static GameObject FT_trouNoire;
    private static GameObject FT_roueG;
    private static GameObject FT_roueD;

    // Vecteurs 3
    // Far West
    private static Vector3 POS_FW_fond = new Vector3(0f,0f,0f);
    private static Vector3 POS_FW_cactus1 = new Vector3(0f,0f,0f);
    private static Vector3 POS_FW_cactus2 = new Vector3(0f,0f,0f);
    private static Vector3 POS_FW_cactus3 = new Vector3(0f,0f,0f);
    private static Vector3 POS_FW_cactus4 = new Vector3(0f,0f,0f);
    private static Vector3 POS_FW_flaque = new Vector3(0f,0f,0f);
    private static Vector3 POS_FW_village = new Vector3(0f,0f,0f);
    private static Vector3 POS_FW_panneau = new Vector3(0f,0f,0f);
    private static Vector3 POS_FW_roueG = new Vector3(0f,0f,0f);
    private static Vector3 POS_FW_roueD = new Vector3(0f,0f,0f);
    private static Vector3 POS_FW_teepees = new Vector3(0f,0f,0f);
    
    // Future
    private static Vector3 POS_FT_fond = new Vector3(0f,0f,0f);
    private static Vector3 POS_FT_vaisseau1 = new Vector3(0f,0f,0f);
    private static Vector3 POS_FT_vaisseau2 = new Vector3(0f,0f,0f);
    private static Vector3 POS_FT_avion = new Vector3(0f,0f,0f);
    private static Vector3 POS_FT_trouNoire = new Vector3(0f,0f,0f);
    private static Vector3 POS_FT_roueG = new Vector3(0f,0f,0f);
    private static Vector3 POS_FT_roueD = new Vector3(0f,0f,0f);

    public static void apparitionFuture()
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
            
            
        }
        
    public static void apparitionPrehistoire()
        {
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
        }
}
