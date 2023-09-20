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

    // Floats for pen dimensions
    public float x;
    public float z;
    // Movement target
    public Vector3 target;
    // Pen game object
    public GameObject pen;
    // Layer mask for raycast
    public LayerMask LayerMask;
    // bool atTarget
    public bool atTarget;
    private float lastTargetChangeTime;
    private float targetChangeDelay = 1f;
    private Vector3 lastTarget;
    private float checkInterval = 4f;
    private float minimumMovement = 1f;
    public float timer = 10f;

    // Start is called before the first frame update
    public virtual void Start()
    {
        IsHungry = false;
        MaxHealth = 50;
        Health = MaxHealth;
        MaxFood = 50;
        Food = MaxFood;
        MaxHappiness = 50;
        Happiness = MaxHappiness;
        MaxClean = 50;
        Clean = MaxClean;
        // Get the agent component from the child object
        agent = GetComponentInChildren<NavMeshAgent>();
        // Set the animal name at random
        Name = animalNames.names[Random.Range(0, animalNames.names.Count)];
        // Capture the pen dimensions
        capturePen();
        target = new Vector3(pen.transform.position.x + Random.Range(-x / 2, x / 2), 0, pen.transform.position.z + Random.Range(-z / 2, z / 2));
        atTarget = false;
        InvokeRepeating("CheckIfStuck", checkInterval, checkInterval);
    }

    // Update is called once per frame
    public virtual void Update()
    {
        MoveAnimal();
        if (pen == null)
        {
            capturePen();
        }
        if (atTarget && Time.time - lastTargetChangeTime > targetChangeDelay)
        {
            StartCoroutine(WaitAndSetNewTarget());
            atTarget = false;
            lastTargetChangeTime = Time.time;
        }
        if (health <= 0)
        {
            die();
        }

        LowerFoodAndClean();
        KeepStatsAtZero();
    }

    private IEnumerator WaitAndSetNewTarget()
    {
        yield return new WaitForSeconds(1);
        SetNewRandomTarget();
    }

    public virtual void MakeSound()
    {
        // To be implemented by child classes
    }

    // Death method
    public void die()
    {
        // Halt all movement
        agent.isStopped = true;
        // Play death animation

        // Play death sound

        // Destroy animal
        Destroy(gameObject, 5);
    }

    // Method to randomly move the animal withing the navmesh
    public void MoveAnimal()
    {
        if (!atTarget)
        {
            // Check if the target is on the NavMesh
            NavMeshHit hitNav;
            if (NavMesh.SamplePosition(target, out hitNav, 1.0f, NavMesh.AllAreas))
            {
                agent.SetDestination(hitNav.position);
            }
            else
            {
                Debug.Log("Invalid target position on the NavMesh");
                SetNewRandomTarget();
            }
        }
        if (!agent.pathPending && agent.remainingDistance != Mathf.Infinity && agent.remainingDistance - agent.stoppingDistance <= 2)
        {
            atTarget = true;
        }
    }

    public void SetNewRandomTarget()
    {
        float buffer = 1f;
        float x = Random.Range(-this.x / 2 + buffer, this.x / 2 - buffer);
        float z = Random.Range(-this.z / 2 + buffer, this.z / 2 - buffer);
        target = new Vector3(pen.transform.position.x + x, 0, pen.transform.position.z + z);
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

    // Method to capture the current pen area
    public void capturePen()
    {
        // Send a raycast from this object to the ground
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 100, LayerMask))
        {
            Debug.Log(hit.collider.gameObject.tag);
            // If the game object tag is PenGround
            if (hit.collider.gameObject.tag == "PenGround")
            {
                // Get the pen object
                pen = hit.collider.gameObject;

                // Get the length and width of the pen using the collider's size
                BoxCollider penCollider = pen.GetComponent<BoxCollider>();
                if (penCollider != null)
                {
                    x = penCollider.size.x;
                    z = penCollider.size.z;
                }
            }
        }
    }

    private void CheckIfStuck()
    {
        if (Vector3.Distance(transform.position, lastTarget) < minimumMovement)
        {
            SetNewRandomTarget();
        }

        lastTarget = transform.position;
    }

    // Method to lower food and clean levels over time
    public void LowerFoodAndClean()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            food -= 5;
            clean -= 3;
            if (food < MaxFood / 2)
            {
                health -= 5;
            }
            if (food <= 0)
            {
                health -= 10;
            }
            if (clean < MaxClean * 0.25)
            {
                health -= 5;
            }
            timer = 10f;
        }
    }

    // Method for keeping stats at 0 if they go below 0
    public void KeepStatsAtZero()
    {
        if (food < 0)
        {
            food = 0;
        }
        if (clean < 0)
        {
            clean = 0;
        }
        if (health < 0)
        {
            health = 0;
        }
        if (happiness < 0)
        {
            happiness = 0;
        }
    }

    // Gizmo for showing the target
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(target, 1);
    }

}
