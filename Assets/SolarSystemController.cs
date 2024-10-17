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

    private static List<int> periode = new List<int> {88, 225, 365, 686, 4182, 9664, 30681, 60181} ;
    private static List<LineRenderer> trajectoires;
      void UpdatePosition (UDateTime t) {
        for (int i = 0; i < ListPlanetes.Count; i++)
    {
     ListPlanetes[i].transform.SetPositionAndRotation(PlanetData.GetPlanetPosition((PlanetData.Planet)i,t) , new Quaternion());
    }
        }

       public void UpdateScale (int a) {
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
     ListPlanetes[i].transform.localScale = new Vector3(0.1f,0.1f,0.1f);
    }
     transform.GetChild(8).localScale = new Vector3(0.2f,0.2f,0.2f);
    }
    if (a==2){
      for (int i = 0; i < ListPlanetes.Count; i++)
    {
    ListPlanetes[i].transform.localScale = new Vector3(echelletaille_distance[i],echelletaille_distance[i],echelletaille_distance[i]);
    }
     transform.GetChild(8).localScale = new Vector3(0.00464913034f,0.00464913034f,0.00464913034f);
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
     PlanetManager.current.CameraMoved += ReAxerCamera;
    UpdateScale(1);
    // CreationTrajectoire(); 
    PlanetManager.current.Date = DateTime.Now;
    PlanetManager.current.Play = true;
    PlanetManager.current.Scale = 1;
    target = transform.GetChild(8);
    
    }

      void CreationTrajectoire(){
            for (int i = 0; i < ListPlanetes.Count; i++){
            LineRenderer line = null;
            if (ListPlanetes[i].GetComponent<LineRenderer>()==null){
            line = ListPlanetes[i].AddComponent<LineRenderer>();
            }
            else {
            line =ListPlanetes[i].GetComponent<LineRenderer>();
            }
            trajectoires.Add(line);

            Gradient gradient = new Gradient();
            gradient.SetKeys(
              new GradientColorKey[] { new GradientColorKey(Color.red, 0.0f), new GradientColorKey(Color.green, 1.0f) },
              new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) }
              );
            line.colorGradient = gradient;
            line.startWidth = 0.1f;
            line.loop = true;

            trajectoires[i].positionCount = periode[i];
            DateTime t0 = DateTime.Now;
            Vector3 Pos = PlanetData.GetPlanetPosition((PlanetData.Planet)i,t0);
                for (int j = 0; j < periode[i]; j++){
                    trajectoires[i].SetPosition(j, Pos);
                    t0.AddDays(1);
                    Pos=PlanetData.GetPlanetPosition((PlanetData.Planet)i,t0);
                }
         }

    }

  void ReAxerCamera(int c){
     Camera.main.transform.LookAt(target);
     Debug.Log(target);
  }
    // Update is called once per frame
    void Update()
    {
      if (PlanetManager.current.Play==true){
        PlanetManager.current.Date = PlanetManager.current.Date.dateTime.AddHours(6);
      }
    }

  
  
    }


