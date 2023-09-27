using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ReptileType
{
    Lizard,
    Snake
}

public class Reptile : Animal
{
    public ReptileType type;

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

    public void Sunbathe()
    {
        Debug.Log("Sunbathing");
    }

    public override void MakeSound()
    {
        Debug.Log("Reptile sound");
    }
 
}
