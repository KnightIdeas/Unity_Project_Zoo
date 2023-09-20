using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reptile : Animal
{
    public bool hasScales;

    // Start is called before the first frame update
    void Start()
    {
        hasScales = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Sunbathe()
    {
        Debug.Log("Sunbathing");
    }

    public override void MakeSound()
    {
        Debug.Log("Reptile sound");
    }
 
}
