using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectClick : MonoBehaviour
{
    public GameObject infosplanètes;

    public GameObject soleil;

    public int numéroplanète;
    void Start()
    {
        
    foreach (Transform infos in infosplanètes.transform){// désactiver toute les infos
    infos.gameObject.SetActive(false);
    }  
    }

    // Update is called once per frame
    void Update()
    {
    if (PlanetManager.current.Target == soleil.transform){ // checker si on est repassé en mode soleil et mettre les infos du soleil en fonction
    foreach (Transform infos in infosplanètes.transform){
        infos.gameObject.SetActive(false);
    }
    infosplanètes.transform.GetChild(8).gameObject.SetActive(true);    
    }
    }

     private void OnMouseDown()
    {
    PlanetManager.current.Target = transform; //changer de cible pour la caméra 
    
    foreach (Transform infos in infosplanètes.transform){
        infos.gameObject.SetActive(false);
    }
    infosplanètes.transform.GetChild(numéroplanète).gameObject.SetActive(true); // afficher les bonnes infos 

    }
}
