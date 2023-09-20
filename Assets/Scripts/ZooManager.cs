using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZooManager : MonoBehaviour
{
    // Names scriptable object
    public AnimalNames animalNames;
    public Animal[] animals;

    // Start is called before the first frame update
    void Start()
    {
        // Initiallize animals
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DailyRoutine()
    {
        foreach (Animal animal in animals)
        {
            animal.MakeSound();
            // Impliment feeding
        }
    }
}
