using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnimalUIController : MonoBehaviour
{
    // UI container game object
    public GameObject uiContainer;
    // Animal type text
    public TextMeshProUGUI animalTypeText;
    
    // Animal name text
    public TextMeshProUGUI animalNameText;

    // Animal health text
    public TextMeshProUGUI animalHealthText;

    // Animal food text
    public TextMeshProUGUI animalFoodText;

    // Animal happiness text
    public TextMeshProUGUI animalHappinessText;

    // Animal clean text
    public TextMeshProUGUI animalCleanText;

    // First aid button
    public Button firstAidButton;

    // Feed button
    public Button feedButton;

    // Play button
    public Button playButton;

    // Clean button
    public Button cleanButton;
    
    // Current animal
    public Animal currentAnimal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if the current animal is not null
        if (currentAnimal != null)
        {
            UpdateUI();
        }
    }

    // Method for passing the current animal to the UI controller
    public void SetCurrentAnimal(Animal animal)
    {
        
        UpdateUI();
    }

    // Method for updating the UI
    public void UpdateUI()
    {
        // Set the animal type text
        animalTypeText.text = currentAnimal.AnimalType;
        // Set the animal name text
        animalNameText.text = currentAnimal.Name;
        // Set the animal health text
        animalHealthText.text = currentAnimal.Health.ToString();
        // Set the animal food text
        animalFoodText.text = currentAnimal.Food.ToString();
        // Set the animal happiness text
        animalHappinessText.text = currentAnimal.Happiness.ToString();
        // Set the animal clean text
        animalCleanText.text = currentAnimal.Clean.ToString();
    }
}
