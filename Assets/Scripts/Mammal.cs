using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mammal : Animal
{
    public bool hasFur;

    // Start is called before the first frame update
    void Start()
    {
        hasFur = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hibernate()
    {
        // Code to hibernate
        Debug.Log("Hibernating");
    }

    public override void MakeSound()
    {
        Debug.Log("Mammal sound");
    }
    
}
