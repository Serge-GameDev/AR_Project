using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObstacle : MonoBehaviour
{
    [SerializeField] GameObject fallingObjectPrefab;
    [SerializeField] GameObject shadowFalingObject;
    //[SerializeField] Transform spawnPoint;  

    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            Vector3 spawnPoint = transform.position + new Vector3(0, 25, 0);
            Vector3 shadowLocation = transform.position + new Vector3(0, 0.2f, 0);
            Instantiate(fallingObjectPrefab, spawnPoint, Quaternion.identity);
            Instantiate(shadowFalingObject, shadowLocation, Quaternion.identity);
            Debug.Log("Falling Obstecal");
        }
    }
}
