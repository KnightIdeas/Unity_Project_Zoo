using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum AnimalType
{
    Monkey,
    Deer,
    GuiniPig,
    Lizard,
    Snake
}

public class AnimalSelectorButton : MonoBehaviour
{

    // Animal type
    public AnimalType animalType;

    // Button component
    private Button button;

    // On click Manager
    public OnClick onClick;

    // House controller
    public HouseController houseController;

    // bool to check if the button is pressed
    public bool buttonPressed;

    // Method for the button
    public void ButtonPressed()
    {
        houseController = onClick.currentHouseController;

        // Call the spawn animal method
        houseController.SpawnAnimal(animalType.ToString());

        // Set the button pressed to true
        buttonPressed = true;
    }
}
