using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;
using UnityEngine.UIElements;

public class SolarSystemController : MonoBehaviour
{
    public Transform target = null;
    public List<GameObject> ListPlanetes = new List<GameObject>();
    private static List<float> echelletaille= new List<float> {0.002f, 0.008f, 0.008f, 0.004f, 0.102f, 0.086f, 0.036f, 0.034f} ;
    private static List<float> echelletaille_distance= new List<float> {1.6678e-5f,4.14444e-5f, 8.274182e-5f, 2.27276e-5f, 0.00047694529f, 0.00040374906f, 0.00015742203f, 0.00014873206f} ;
    private GameObject[]  trajectoires;
    public Material trajectoryMaterial;

///////////////////////////////////////////////////////////////////////////////////////


      void UpdatePosition (UDateTime t) { 
        for (int i = 0; i < ListPlanetes.Count; i++) //Mise à jour de toute les positions des planètes en fonction du temps t
    {
     ListPlanetes[i].transform.SetPositionAndRotation(PlanetData.GetPlanetPosition((PlanetData.Planet)i,t) , new Quaternion()); //faire le lien entre le transform de la planète i est les données de la planètes i
    }
        }

///////////////////////////////////////////////////////////////////////////////////////

       public void UpdateScale (int a) { //Mise à jour des échelles suivants les listes crées au dessus et en fonction de l'état de la variable a qui indique l'une des 3 échelles
    if (a==0){
             for (int i = 0; i < ListPlanetes.Count; i++)
    {
    ListPlanetes[i].transform.localScale = new Vector3(echelletaille[i],echelletaille[i],echelletaille[i]);
    }
     transform.GetChild(8).localScale = new Vector3(0.2f,0.2f,0.2f);
    }

    if (a==1){
      for (int i = 0; i < ListPlanetes.Count; i++)
    {
     ListPlanetes[i].transform.localScale = new Vector3(0.2f,0.2f,0.2f);
    }
     transform.GetChild(8).localScale = new Vector3(0.2f,0.2f,0.2f);
     transform.GetChild(0).localScale = new Vector3(0.1f,0.1f,0.1f);    
     transform.GetChild(1).localScale = new Vector3(0.15f,0.15f,0.15f);    
     }

    if (a==2){
      for (int i = 0; i < ListPlanetes.Count; i++)
    {
    ListPlanetes[i].transform.localScale = new Vector3(echelletaille_distance[i],echelletaille_distance[i],echelletaille_distance[i]);
    }
     transform.GetChild(8).localScale = new Vector3(0.00464913034f,0.00464913034f,0.00464913034f);
    }
       }

///////////////////////////////////////////////////////////////////////////////////////


    void Start()
    {
              for (int i = 0; i < transform.childCount-1; i++)
    {
        GameObject planete = transform.GetChild(i).gameObject; // Création de la liste de transform de chaque planète (côté unity)
        ListPlanetes.Add(planete);
        Debug.Log("Planète trouvé : " + planete.name);
    }
    PlanetManager.current.OnTimeChange += UpdatePosition; //Ajout des abonnements aux différents événements
    PlanetManager.current.ScaleChange += UpdateScale;
    PlanetManager.current.TrajChange += ActiverTrajectoire;
    
    UpdateScale(1); // Echelle pédagogique

    PlanetManager.current.Date = DateTime.Now; //initialisation des différentes variables
    PlanetManager.current.Play = true;
    PlanetManager.current.Scale = 1;
    PlanetManager.current.Target = transform.GetChild(8);
    

    trajectoires = new GameObject[Enum.GetValues(typeof(PlanetData.Planet)).Length];  // Création et stockage des trajetoires (pour ne le faire qu'une fois)
        int index = 0;
        foreach (PlanetData.Planet p in Enum.GetValues(typeof(PlanetData.Planet)))
        {
            GameObject planetObject = GameObject.Find(p.ToString());
            if (planetObject != null)
            {
                GameObject trajectory = CreateTrajectory(p);
                trajectoires[index] = trajectory;
                index++;
            }
        }

    }
        
///////////////////////////////////////////////////////////////////////////////////////

        public GameObject CreateTrajectory(PlanetData.Planet planetType) // Fonction qui crée la trajectoire d'une planète
    {
        DateTime startDate = DateTime.Now;
        GameObject trajectory = new GameObject(planetType.ToString() + "Trajectory");
        trajectory.transform.SetParent(transform);

        LineRenderer lineRenderer = trajectory.AddComponent<LineRenderer>();
        lineRenderer.positionCount = 100000; // Nombre de points arbitraire
        lineRenderer.material = trajectoryMaterial;
        lineRenderer.startWidth = 0.05f; // Ajuster l'épaisseur de début de la trajectoire
        lineRenderer.endWidth = 0.05f; // Ajuster l'épaisseur de fin de la trajectoire

        for (int i = 0; i < 100000; i++) // On recupère la position de la planète tout au long de sa révolution 
        {
            Vector3 planetPosition = PlanetData.GetPlanetPosition(planetType, startDate.AddDays(1f*i)); 
            lineRenderer.SetPosition(i, planetPosition); //ajout à la trajectoire
        }

        return trajectory;
    }
        
///////////////////////////////////////////////////////////////////////////////////////

    // Update is called once per frame
    void Update()
    {
      if (PlanetManager.current.Play==true){ // uniquement en mode play
        PlanetManager.current.Date = PlanetManager.current.Date.dateTime.AddHours(PlanetManager.current.playspeed); // on fait s'écouler le temps 
      }
    }


///////////////////////////////////////////////////////////////////////////////////////
  
  void ActiverTrajectoire(Boolean b){
     if (trajectoires != null)
        {
            foreach (GameObject trajectoire in trajectoires)
            {
                if (trajectoire != null)
                {
                    // Activer ou désactiver les trajectoires en fonction de l'état du bouton bascule
                    trajectoire.SetActive(b);
                    Debug.Log(b);
                }
             }
    }
  }

}


 


