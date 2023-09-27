using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseController : MonoBehaviour
{
    // Animal Array
    public GameObject[] animalPrefabs;

    // Animal spawn position
    public GameObject spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Method to spawn an animal
    public void SpawnAnimal(string animalName)
    {
        // Switch statement to spawn a selected animal
        switch (animalName)
        {
            case "Monkey":
                Instantiate(animalPrefabs[0], transform.position, Quaternion.identity);
                break;
            case "Deer":
                Instantiate(animalPrefabs[1], transform.position, Quaternion.identity);
                break;
            case "GuiniPig":
                Instantiate(animalPrefabs[2], transform.position, Quaternion.identity);
                break;
            case "Lizard":
                Instantiate(animalPrefabs[3], transform.position, Quaternion.identity);
                break;
            case "Snake":
                Instantiate(animalPrefabs[4], transform.position, Quaternion.identity);
                break;
            default:
                break;
        }
    }
}
