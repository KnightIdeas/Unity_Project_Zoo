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

    public override string AnimalType => type.ToString();

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
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
