using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MammalType
{
    Monkey,
    GuiniPig,
    Dear
}

public class Mammal : Animal
{
    public MammalType type;

    // Start is called before the first frame update
    void Start()
    {
        
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
