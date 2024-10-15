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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
