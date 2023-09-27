using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // UI game objects
    public GameObject[] UIObjects;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(HideUIObjects());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Coroutine to show disabled UI objects
    public IEnumerator HideUIObjects()
    {
        // Loop through each UI object
        foreach (GameObject UIObject in UIObjects)
        {
            yield return new WaitForSeconds(0.1f);
            // Enable the UI object
            UIObject.SetActive(false);
            // Wait for 0.5 seconds
        }
    }

    // Method to show a UI object
    public void ShowUIObject(GameObject UIObject)
    {
        // Enable the UI object
        UIObject.SetActive(true);
    }
}
