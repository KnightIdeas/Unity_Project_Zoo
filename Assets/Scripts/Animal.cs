using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public string name;
    public string species;
    public int age;
    public bool isHungry;
    public string environment;

    public virtual void MakeSound()
    {
        // To be implemented by child classes
    }

    public void Eat()
    {
        // The be implemented by child classes
    }
}
