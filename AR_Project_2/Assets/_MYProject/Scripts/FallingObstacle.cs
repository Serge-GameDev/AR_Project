using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class FallingObstacle : MonoBehaviour
{
    [SerializeField] GameObject fallingObjectPrefab;
    [SerializeField] GameObject shadowFalingObject;
    [SerializeField] ARPlaneManager arPlaneManager;

    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            Vector3 spawnPoint = transform.position + new Vector3(0, 15, 0);
            Vector3 shadowLocation = transform.position + new Vector3(0, 0.2f, 0);
            Instantiate(fallingObjectPrefab, spawnPoint, Quaternion.identity);
            Instantiate(shadowFalingObject, shadowLocation, Quaternion.identity);
            Debug.Log("Falling Obstecal");
        }
    }
}
