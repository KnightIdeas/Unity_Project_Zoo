using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Animal : MonoBehaviour
{
    public NavMeshAgent agent;
    public string Name { get; set; }
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
    private int hunger;
    public int Hunger
    {
        get { return hunger; }
        set
        {
            hunger = Mathf.Clamp(value, 0, MaxHunger);
        }
    }
    public int MaxHunger { get; set; }
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

    // Start is called before the first frame update
    void Start()
    {
        IsHungry = false;
        MaxHealth = 100;
        Health = MaxHealth;
        Hunger = 0;
        MaxHunger = 100;
        MaxHappiness = 100;
        Happiness = MaxHappiness;
        // Get the agent component from the child object
        agent = GetComponentInChildren<NavMeshAgent>();
    }

    public virtual void MakeSound()
    {
        // To be implemented by child classes
    }

    public void healAnimal()
    {
        Health = MaxHealth;
    }

    public void eat()
    {
        Hunger = 0;
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



}
