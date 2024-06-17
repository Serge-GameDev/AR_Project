using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBomb : MonoBehaviour
{
    [SerializeField] GameObject particalEffects;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ShadowObstical"))
        {
            Instantiate(particalEffects, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
