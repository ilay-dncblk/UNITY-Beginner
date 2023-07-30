using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class SolarSystem : MonoBehaviour
{
    public float sunSpeed = 2f;
    [System.Serializable]
    public class CelestialBodyData
    {
        public string name;
        public Transform bodyTransform;
        public float orbitSpeed;
        public Transform orbitCenter;
        public float orbitRadius;
        public bool isClockwise = true;
        [HideInInspector]
        public Vector3 orbitAxis;
        [HideInInspector]
        public TrailRenderer trailRenderer;
        [HideInInspector]
        public float timeSinceTrailReset = 0f;
        public float trailDuration = 2f;
        public Color trailStartColor = Color.white;
        public Color trailEndColor = new Color(1f, 1f, 1f, 0f);
    }

    public CelestialBodyData[] celestialBodies;

    private void Start()
    {
        foreach (var bodyData in celestialBodies)
        {
            bodyData.orbitAxis = (bodyData.bodyTransform.position - bodyData.orbitCenter.position).normalized;
            bodyData.trailRenderer = bodyData.bodyTransform.GetComponent<TrailRenderer>();
            if (bodyData.trailRenderer != null)
            {
                bodyData.trailRenderer.Clear();
                bodyData.trailRenderer.startColor = bodyData.trailStartColor;
                bodyData.trailRenderer.endColor = bodyData.trailEndColor;
            }
        }
    }

    private void Update()
    {
         transform.Translate(Vector3.up*Time.deltaTime*sunSpeed, Space.World);
         foreach (var bodyData in celestialBodies)
        {
            float rotationAngle = bodyData.orbitSpeed * Time.deltaTime * (bodyData.isClockwise ? 1 : -1);
            bodyData.orbitAxis = Quaternion.Euler(0f, rotationAngle, 0f) * bodyData.orbitAxis;
            Vector3 newPosition = bodyData.orbitCenter.position + bodyData.orbitAxis * bodyData.orbitRadius;
            bodyData.bodyTransform.position = newPosition;
            bodyData.bodyTransform.LookAt(bodyData.orbitCenter);

            // Update the trail renderer if available
            if (bodyData.trailRenderer != null)
            {
                bodyData.trailRenderer.AddPosition(bodyData.bodyTransform.position);
                
            }
            
        }
    }
}