using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClick : MonoBehaviour
{
    // Camera
    public Camera mainCamera;

    // Game manager
    public GameManager gameManager;

    // Current house controller
    public HouseController currentHouseController;

    // Edge Camera Movement
    public EdgeCameraMove edgeCameraMovement;

    // Awake
    private void Awake()
    {
        // Set the main camera
        mainCamera = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // On mouse click
        if (Input.GetMouseButtonDown(0))
        {
            // Call the click house method
            ClickHouse();
        }
    }

    // Method to click on the house game object
    public void ClickHouse()
    {
        // Send a raycast from the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        // If the raycast hits something check if its a house
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.collider.gameObject.tag);
            if (hit.collider.gameObject.tag == "House")
            {
                // Get the house controller component
                currentHouseController = hit.collider.gameObject.GetComponent<HouseController>();

                // Show the UI object
                gameManager.ShowUIObject(gameManager.UIObjects[1]);

                // Set the movement to false
                edgeCameraMovement.DisableMovement();
            }
        }
    }
}
