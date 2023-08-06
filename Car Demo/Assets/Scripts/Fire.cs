using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Fire : MonoBehaviour
{
    RaycastHit hit;
    
    void Update()
    {
        
        if(Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject.tag == "dusman") 
                {
                    Destroy(hit.collider.gameObject);
                }
            }
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 dir = Camera.main.transform.forward * 15;
        Gizmos.DrawRay(Camera.main.transform.position, dir);
    }
}
