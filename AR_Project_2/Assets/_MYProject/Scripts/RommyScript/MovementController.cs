using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MovementController : MonoBehaviour
{

    [SerializeField] private GameObject Character;

    [SerializeField] private Animator _animator;

    [SerializeField] private float rotationTimeForDegree, walkSpeed, runSpeed, rotationTime;

    //[SerializeField] private List<BoxCollider> edgeDetectors;

    private Vector3 targetRotation;
    private int side;

    private void FixedUpdate()
    {
        transform.position += transform.forward * walkSpeed;
    }

    public void ChangeDirection()
    {
        ChooseRotationSide();
        ChooseRandomTarget();
        StartCoroutine(LerpToTarget(Quaternion.Euler(targetRotation), rotationTime));
    }

    void ChooseRotationSide()
    {
        side = Random.Range(0, 1) * 2 - 1;
        if (side == 1)
        {
            _animator.SetTrigger("TurnRight");
        }
        else
        {
            _animator.SetTrigger("TurnLeft");
        }
    }

    private void ChooseRandomTarget()
    {
        float currentDir = transform.forward.y;
        float newDir = Random.Range(90, 180) * side;
        rotationTime = newDir * rotationTimeForDegree;
        targetRotation = new Vector3(0, currentDir + newDir,0);
    }
    
    
    IEnumerator LerpToTarget(Quaternion endValue, float duration)
    {
        float time = 0;
        Quaternion startValue = transform.rotation;

        while (time < duration)
        {
            transform.rotation = Quaternion.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.rotation = endValue;
        _animator.SetTrigger("StopTurning");
    }
}
