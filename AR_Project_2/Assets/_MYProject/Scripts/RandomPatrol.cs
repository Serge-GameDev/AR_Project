using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPatrol : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // Speed of the object
    [SerializeField] private List<Transform> patrolPoints; // List of patrol points

    private Transform targetPoint;
    private int lastIndex = -1;

    private void Start()
    {
        if (patrolPoints.Count > 0)
        {
            SetRandomTargetPoint();
            StartCoroutine(MoveToTarget());
        }
        else
        {
            Debug.LogWarning("Patrol points list is empty!");
        }
    }

    private IEnumerator MoveToTarget()
    {
        while (true)
        {
            if (targetPoint != null)
            {
                // Move towards the target point
                transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);

                // Check if the object has reached the target point
                if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
                {
                    SetRandomTargetPoint();
                }
            }
            yield return null;
        }
    }

    private void SetRandomTargetPoint()
    {
        if (patrolPoints.Count == 1)
        {
            targetPoint = patrolPoints[0];
            return;
        }

        int randomIndex;

        do
        {
            randomIndex = Random.Range(0, patrolPoints.Count);
        } while (randomIndex == lastIndex); // Ensure the new point is different from the last one

        targetPoint = patrolPoints[randomIndex];
        lastIndex = randomIndex;
    }

    private void OnDrawGizmos()
    {
        if (patrolPoints != null)
        {
            Gizmos.color = Color.red;
            foreach (Transform point in patrolPoints)
            {
                Gizmos.DrawWireSphere(point.position, 0.5f);
            }
        }
    }
}
