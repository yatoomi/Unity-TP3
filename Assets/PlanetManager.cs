using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{
 public static PlanetManager current;
 private void Awake()
 {
 if (current == null)
 {
 current = this;
 }
 else
 {
 Destroy(obj: this);
 }
 }


[SerializeField]
 private int scale;
 public int Scale
 {
 get => scale;
 set
 {
 scale = value;
 ScaleChanged(value); //Fire the event
 }
 }

 [SerializeField]
 private Boolean play;
 public Boolean Play
 {
 get => play;
 set
 {
 play = value;
 }
 }
  public event Action<int> ScaleChange;
 public void ScaleChanged(int s)
 {
 ScaleChange?.Invoke(s);
 }
 
 [SerializeField]
 private UDateTime date;
 public UDateTime Date
 {
 get => date;
 set
 {
 date = value;
 TimeChanged(value.dateTime); //Fire the event
 }
 }
  public event Action<UDateTime> OnTimeChange;
 public void TimeChanged(UDateTime newTime)
 {
 OnTimeChange?.Invoke(newTime);
 }


 private int cam;
 public int Cam
 {
 get => cam;
 set
 {
 cam = value;
 CameraMove(value); //Fire the event
 }
 }

 public event Action<int> CameraMoved;
 public void CameraMove(int c)
 {
 CameraMoved?.Invoke(c);
 }
    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
