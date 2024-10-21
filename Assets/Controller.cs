using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UIElements;

public class Controler : MonoBehaviour
{
Boolean axesoleil = true;
    public Transform soleil;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ChangeScale(){ // Bouton bascule passage de l'echelle pédagogique à l'échelle des planetes reelles
    if (PlanetManager.current.Scale == 0 || PlanetManager.current.Scale == 2 ){
        PlanetManager.current.Scale = 1;
        return;
        }
    if (PlanetManager.current.Scale == 1){
       PlanetManager.current.Scale =0;
       return;
        }
      Debug.Log(PlanetManager.current.Scale);
    }
    public void ChangeScale2(){  // Bouton bascule passage de l'echelle pédagogique à l'échelle des planetes et des distances reelles
    if (PlanetManager.current.Scale == 0){
      PlanetManager.current.Scale = 2;
      return;
    }
    if (PlanetManager.current.Scale == 1 ){
      PlanetManager.current.Scale = 2;
      return;
    }
    if (PlanetManager.current.Scale == 2 ){
      PlanetManager.current.Scale = 1;
      return;
    }
    Debug.Log(PlanetManager.current.Scale);
    }

 public void ChangeYear(string s){  // Ajout d'année
    Debug.Log(s);
    int e = Int32.Parse(s);
    PlanetManager.current.Date = PlanetManager.current.Date.dateTime.AddYears(e);
}
 public void ChangeMonth(string m){ // Ajout de mois
    PlanetManager.current.Date = PlanetManager.current.Date.dateTime.AddMonths(int.Parse(m));
}
 public void Play(){ // Bascule de la variable play
    PlanetManager.current.Play = ! PlanetManager.current.Play;
}
public void VueHelioCentree(){// Bascule de la vue soleil et recentrage en fonction de l'état de la bascule 
    axesoleil=!axesoleil;
    PlanetManager.current.Target = soleil;
    if (axesoleil == true){
        Camera.main.transform.SetLocalPositionAndRotation(new Vector3(0,0,-17.5f), Quaternion.Euler(0,0,0) );
    }
   if (axesoleil == false){
        Camera.main.transform.SetLocalPositionAndRotation(new Vector3(0,3f,0), Quaternion.Euler(90,0,0) );
   }
}

public void Playspeed(Single s){ 
  PlanetManager.current.playspeed = (int) s;
}

public void Trajectory(){ //bascule des trajectoires des planètes
  PlanetManager.current.Traj=!PlanetManager.current.Traj;
}
}


