using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : Animal
{

    public bool hasFins;

    // Start is called before the first frame update
    void Start()
    {
       hasFins = true; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Swim()
    {
        Debug.Log("Swimming");
    }

    public override void MakeSound()
    {
        Debug.Log("Fish sound");
    }
}
