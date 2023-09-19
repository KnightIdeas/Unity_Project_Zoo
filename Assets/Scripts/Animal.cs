using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Animal : MonoBehaviour
{
    public NavMeshAgent agent;
    public string Name { get; set; }

    // Current animal names list
    public AnimalNames animalNames;
    public virtual string AnimalType => "Animal";
    public bool IsHungry { get; set; }
    
    [SerializeField]
    private int health;
    public int Health
    {
        get { return health; }
        set
        {
            health = Mathf.Clamp(value, 0, MaxHealth);
        }
    }

    private int MaxHealth { get; set; }
    [SerializeField]
    private int food;
    public int Food
    {
        get { return food; }
        set
        {
            food = Mathf.Clamp(value, 0, MaxFood);
        }
    }
    public int MaxFood { get; set; }
    [SerializeField]
    private int happiness;
    public int Happiness
    {
        get { return happiness; }
        set
        {
            happiness = Mathf.Clamp(value, 0, MaxHappiness);
        }
    }
    public int MaxHappiness { get; set; }

    public int MaxClean { get; set; }
    [SerializeField]
    private int clean;
    public int Clean
    {
        get { return clean; }
        set
        {
            clean = Mathf.Clamp(value, 0, MaxClean);
        }
    }

    // Start is called before the first frame update
    public virtual void Start()
    {
        IsHungry = false;
        MaxHealth = 100;
        Health = MaxHealth;
        MaxFood = 100;
        Food = MaxFood;
        MaxHappiness = 100;
        Happiness = MaxHappiness;
        MaxClean = 100;
        Clean = MaxClean;
        // Get the agent component from the child object
        agent = GetComponentInChildren<NavMeshAgent>();
        // Set the animal name at random
        Name = animalNames.names[Random.Range(0, animalNames.names.Count)];
    }

    public virtual void MakeSound()
    {
        // To be implemented by child classes
    }

    // Death method
    public void die()
    {
        // Play death animation

        // Play death sound

        // Destroy animal
        Destroy(gameObject, 5);
    }

    // Method to randomly move the animal withing the navmesh
    public void moveAnimal()
    {
        
    }

    // Co routine for interacting with the animal
    public IEnumerator interact()
    {
        // Play animation

        // Play sound

        // Wait for animation to finish
        yield return new WaitForSeconds(1);

        // Increase happiness
        Happiness += 10;
    }

    // Co routine for feeding the animal
    public IEnumerator feed()
    {
        // Play animation

        // Play sound

        // Wait for animation to finish
        yield return new WaitForSeconds(1);

        // Increase happiness
        Food += 10;
    }

    // Co routine for petting the animal
    public IEnumerator Heal()
    {
        // Play animation

        // Play sound

        // Wait for animation to finish
        yield return new WaitForSeconds(1);

        // Increase happiness
        Health += 10;
    }

}
