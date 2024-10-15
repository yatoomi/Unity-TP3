using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystemController : MonoBehaviour
{
    public Dictionary<int,GameObject> ListPlanetes = new Dictionary<int, GameObject>();
    // Start is called before the first frame update

      void UpdatePosition (UDateTime t) {
        foreach (KeyValuePair<int, GameObject> element in ListPlanetes)
    {
     element.Value.transform.SetPositionAndRotation(PlanetData.GetPlanetPosition((PlanetData.Planet)element.Key,t) , new Quaternion());
    }
        }
    void Start()
    {
              for (int i = 0; i < transform.childCount-1; i++)
    {
        GameObject planete = transform.GetChild(i).gameObject;
        ListPlanetes.Add(i,planete);
        Debug.Log("Planète trouvé : " + planete.name);
    }
    PlanetManager.current.OnTimeChange += UpdatePosition;
    }

    // Update is called once per frame
    void Update()
    {
    }

  
    }

