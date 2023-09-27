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

    public bool isMovementEnabled = true;

    void Update()
    {

        if (!isMovementEnabled)
        {
            return;
        }

        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        if (!IsMouseWithinScreenBounds(mousePosition))
        {
            return;
        }

        Vector3 movement = new Vector3(
            CalculateMovement(mousePosition.x, Screen.width, edgeBorder, deadZoneSize),
            0,
            CalculateMovement(mousePosition.y, Screen.height, edgeBorder, deadZoneSize)
        );

        ApplyMovement(movement);
    }

    private bool IsMouseWithinScreenBounds(Vector2 mousePosition)
    {
        return mousePosition.x >= 0 && mousePosition.x <= Screen.width && mousePosition.y >= 0 && mousePosition.y <= Screen.height;
    }

    private float CalculateMovement(float mouseCoord, float screenSize, float edgeBorder, float deadZoneSize)
    {
        float move = 0;

        if (mouseCoord < edgeBorder)
        {
            move = Mathf.Lerp(-maxMoveSpeed, 0, mouseCoord / edgeBorder);
        }
        else if (mouseCoord > screenSize - edgeBorder)
        {
            move = Mathf.Lerp(0, maxMoveSpeed, (mouseCoord - (screenSize - edgeBorder)) / edgeBorder);
        }
        else if (mouseCoord >= edgeBorder && mouseCoord <= screenSize * deadZoneSize)
        {
            move = -maxMoveSpeed;
        }
        else if (mouseCoord <= screenSize - edgeBorder && mouseCoord >= screenSize * (1 - deadZoneSize))
        {
            move = maxMoveSpeed;
        }

        return move;
    }

    private void ApplyMovement(Vector3 movement)
    {
        Vector3 newPosition = transform.position + movement * Time.deltaTime;

        newPosition.x = Mathf.Clamp(newPosition.x, xBoundary.x, xBoundary.y);
        newPosition.z = Mathf.Clamp(newPosition.z, zBoundary.x, zBoundary.y);

        transform.position = newPosition;
    }

    public void EnableMovement()
    {
        isMovementEnabled = true;
    }

    public void DisableMovement()
    {
        isMovementEnabled = false;
    }
}
