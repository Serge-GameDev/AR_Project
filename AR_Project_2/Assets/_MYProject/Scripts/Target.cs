using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] int targetValue = 100;
    [SerializeField] Animator m_Animator;
    [SerializeField] float animLength = 0.1f;


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            GameManager.Instance.TargetHit(targetValue);
            StartCoroutine(HitEffectAndDestroy());
        }
    }


    public bool animFinished = true;


    private IEnumerator HitEffectAndDestroy()
    {
        // animFinished = false;
        // m_Animator.SetTrigger("Hit");
        yield return new WaitForSeconds(animLength);
        // animFinished = true;
        Destroy(gameObject);
    }

}
