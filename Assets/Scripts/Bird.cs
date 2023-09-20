using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : Animal
{
    // Update is called once per frame
    void Update()
    {
        
    }

    public override void MakeSound()
    {
        Debug.Log("Bird sound");
    }
}
