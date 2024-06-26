using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBomb : MonoBehaviour
{
    [SerializeField] GameObject particalEffects;
    [SerializeField] float destroyDelay = 0.5f;
    
    private void OnCollisionEnter(Collision collision)
    {
        
        
            Instantiate(particalEffects, transform.position, Quaternion.identity);

             StartCoroutine(DestroyAfterDelay(collision.gameObject));
    }

      private IEnumerator DestroyAfterDelay(GameObject other)
        {
            
            yield return new WaitForSeconds(destroyDelay);

            
            Destroy(gameObject);

            
           // Destroy(other);
       }

    
}
