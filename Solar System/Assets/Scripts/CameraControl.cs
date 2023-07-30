using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float zoomSpeed = 10f; // Adjust the zoom speed as needed
    public float minFOV = 20f; // The minimum field of view (zoomed out)
    public float maxFOV = 60f; // The maximum field of view (zoomed in)

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        // Handle zoom in and out using mouse scroll wheel or touchpad pinch
        float zoomInput = Input.GetAxis("Mouse ScrollWheel");
        mainCamera.fieldOfView = Mathf.Clamp(mainCamera.fieldOfView - zoomInput * zoomSpeed, minFOV, maxFOV);
    }
}