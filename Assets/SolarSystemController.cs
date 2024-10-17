using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;
using UnityEngine.UIElements;

public class SolarSystemController : MonoBehaviour
{
    public List<GameObject> ListPlanetes = new List<GameObject>();
    private static List<float> echelle = new List<float> {0.002f, 0.008f, 0.008f, 0.004f, 0.102f, 0.086f, 0.036f, 0.034f} ;

    private static List<int> periode = new List<int> {88, 225, 365, 686, 4182, 9664, 30681, 60181} ;
    private static List<LineRenderer> trajectoires;
      void UpdatePosition (UDateTime t) {
        for (int i = 0; i < ListPlanetes.Count; i++)
    {
     ListPlanetes[i].transform.SetPositionAndRotation(PlanetData.GetPlanetPosition((PlanetData.Planet)i,t) , new Quaternion());
    }
        }

       public void UpdateScale (Boolean a) {
    if (a==true){
             for (int i = 0; i < ListPlanetes.Count; i++)
    {
    ListPlanetes[i].transform.localScale = new Vector3(echelle[i],echelle[i],echelle[i]);
    }
     transform.GetChild(8).localScale = new Vector3(0.2f,0.2f,0.2f);
    }
    if (a==false){
      for (int i = 0; i < ListPlanetes.Count; i++)
    {
     ListPlanetes[i].transform.localScale = new Vector3(0.1f,0.1f,0.1f);
    }
     transform.GetChild(8).localScale = new Vector3(0.2f,0.2f,0.2f);
    }
       }
       
    void Start()
    {
              for (int i = 0; i < transform.childCount-1; i++)
    {
        GameObject planete = transform.GetChild(i).gameObject;
        ListPlanetes.Add(planete);
        Debug.Log("Planète trouvé : " + planete.name);
    }
    PlanetManager.current.OnTimeChange += UpdatePosition;
    PlanetManager.current.ScaleChange += UpdateScale;
    UpdateScale(true);
    CreationTrajectoire();
    }

      void CreationTrajectoire(){
            for (int i = 0; i < ListPlanetes.Count; i++){
            LineRenderer line = ListPlanetes[i].AddComponent<LineRenderer>();
            trajectoires.Add(line);
            trajectoires[i].positionCount = periode[i];
            DateTime t0 = DateTime.Now;
            Vector3 Pos = PlanetData.GetPlanetPosition((PlanetData.Planet)i,t0);
                for (int j = 0; j < periode[i]; i++){
                    trajectoires[i].SetPosition(j, Pos);
                    t0.AddDays(1);
                    Pos=PlanetData.GetPlanetPosition((PlanetData.Planet)i,t0);
                }
         }

    }

    // Update is called once per frame
    void Update()
    {
    }

  
  
    }


