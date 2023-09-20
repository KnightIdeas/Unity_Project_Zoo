using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeCameraMove : MonoBehaviour
{
    public float edgeBorder = 20f;
    public float maxMoveSpeed = 6;
    public float deadZoneSize = 0.25f;

    public Vector2 xBoundary = new Vector2(-15, 15);
    public Vector2 zBoundary = new Vector2(-15, 15);

    void Update()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;

        float moveX = 0;
        float moveZ = 0;

        // Ensure that the mouse is within the screen bounds
        if (mouseX < 0 || mouseX > Screen.width || mouseY < 0 || mouseY > Screen.height)
        {
            return; // Exit the update loop if mouse is outside the window
        }

        // Check X-axis movement
        if (mouseX < edgeBorder)
        {
            moveX = Mathf.Lerp(-maxMoveSpeed, 0, mouseX / edgeBorder);
        }
        else if (mouseX > Screen.width - edgeBorder)
        {
            moveX = Mathf.Lerp(0, maxMoveSpeed, (mouseX - (Screen.width - edgeBorder)) / edgeBorder);
        }
        else if (mouseX >= edgeBorder && mouseX <= Screen.width * deadZoneSize)
        {
            moveX = -maxMoveSpeed;
        }
        else if (mouseX <= Screen.width - edgeBorder && mouseX >= Screen.width * (1 - deadZoneSize))
        {
            moveX = maxMoveSpeed;
        }

        // Check Z-axis movement
        if (mouseY < edgeBorder)
        {
            moveZ = Mathf.Lerp(-maxMoveSpeed, 0, mouseY / edgeBorder);
        }
        else if (mouseY > Screen.height - edgeBorder)
        {
            moveZ = Mathf.Lerp(0, maxMoveSpeed, (mouseY - (Screen.height - edgeBorder)) / edgeBorder);
        }
        else if (mouseY >= edgeBorder && mouseY <= Screen.height * deadZoneSize)
        {
            moveZ = -maxMoveSpeed;
        }
        else if (mouseY <= Screen.height - edgeBorder && mouseY >= Screen.height * (1 - deadZoneSize))
        {
            moveZ = maxMoveSpeed;
        }

        Vector3 movement = new Vector3(moveX, 0, moveZ);

        Vector3 newPosition = transform.position + movement * Time.deltaTime;

        newPosition.x = Mathf.Clamp(newPosition.x, xBoundary.x, xBoundary.y);
        newPosition.z = Mathf.Clamp(newPosition.z, zBoundary.x, zBoundary.y);

        transform.position = newPosition;

    }
}
