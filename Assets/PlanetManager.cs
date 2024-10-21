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

  [SerializeField] private Transform target = null;

    public Transform Target //Astre sélectionner 
     {
    get => target;
    set
     {
     target = value;
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
 private Boolean play; // bascule play
 public Boolean Play
 {
 get => play;
 set
 {
 play = value;
}
 }

[SerializeField]
 public int playspeed;

 public event Action<int> ScaleChange;
 public void ScaleChanged(int s)
 {
 ScaleChange?.Invoke(s);
 }
 

 [SerializeField]
 private Boolean traj = true; // bascule trajectoires
 public Boolean Traj
 {
 get => traj;
 set
 {
 traj = value;
 TrajChanged(value);
}
 }
  public event Action<Boolean> TrajChange;
 public void TrajChanged(Boolean b)
 {
 TrajChange?.Invoke(b);
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

    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
