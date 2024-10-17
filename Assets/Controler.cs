using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Assertions.Must;
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
    public void ChangeScale2(){
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

 public void ChangeYear(string s){
    Debug.Log(s);
    int e = Int32.Parse(s);
    PlanetManager.current.Date = PlanetManager.current.Date.dateTime.AddYears(e);
}
 public void ChangeMonth(string m){
    PlanetManager.current.Date = PlanetManager.current.Date.dateTime.AddMonths(int.Parse(m));
}
 public void Play(){
    PlanetManager.current.Play = ! PlanetManager.current.Play;
}
public void VueHelioCentree(){
    Debug.Log(a);
    a=!a;
    if (a == true){
        Camera.main.transform.SetLocalPositionAndRotation(new Vector3(0,0,-17.5f), Quaternion.Euler(0,0,0) );
    }
   if (a == false){
        Camera.main.transform.SetLocalPositionAndRotation(new Vector3(0,3f,0), Quaternion.Euler(90,0,0) );
   }
}


public void RotAxe1(Single a){
    float b = (a)*360;
    float c = b*Mathf.Deg2Rad;
    Camera.main.transform.SetLocalPositionAndRotation(new Vector3(17.5f*math.cos(c),Camera.main.transform.position.y,17.5f*math.sin(c)), Quaternion.Euler(0,0,0) );
    PlanetManager.current.Cam += 1;
}

public void RotAxe2(Single a){
    float b = (a)*360;
    float c = b*Mathf.Deg2Rad;
    Camera.main.transform.SetLocalPositionAndRotation(new Vector3(Camera.main.transform.position.x,17.5f*math.sin(c),17.5f*math.cos(c)), Quaternion.Euler(0,0,0) );
    PlanetManager.current.Cam += 1;
}

public void Zoom(Single zoom){
Camera.main.transform.SetLocalPositionAndRotation(Camera.main.transform.forward*(zoom)*17, Camera.main.transform.rotation);
PlanetManager.current.Cam += 1;
}
public void Trajectory(){
}
}


