using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : Animal
{
    public bool hasFeathers;

    // Start is called before the first frame update
    void Start()
    {
        hasFeathers = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LayEgg()
    {
        Debug.Log("Laying an egg");
    }

    public override void MakeSound()
    {
        Debug.Log("Bird sound");
    }
}
