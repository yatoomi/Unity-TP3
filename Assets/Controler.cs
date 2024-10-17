using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class Controler : MonoBehaviour
{
Boolean a = true;
    public GameObject controleur;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScale(){
    PlanetManager.current.Scale=!PlanetManager.current.Scale;
}

 public void ChangeYear(string s){
    Debug.Log(s);
    int e = Int32.Parse(s);
    PlanetManager.current.Date = PlanetManager.current.Date.dateTime.AddYears(e);
}
 public void ChangeMonth(string m){
    PlanetManager.current.Date = PlanetManager.current.Date.dateTime.AddMonths(int.Parse(m));
}

public void VueHelioCentree(){
    if (a == true){
        a=!a;
        Camera.main.transform.SetLocalPositionAndRotation(new Vector3(0,0,-10), Quaternion.Euler(0,0,0) );
    }
   if (a == false){
        a=!a;
        Camera.main.transform.SetLocalPositionAndRotation(new Vector3(0,3,0), Quaternion.Euler(90,0,0) );
   }


}

public void Trajectory(){

}
}


