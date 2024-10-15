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
