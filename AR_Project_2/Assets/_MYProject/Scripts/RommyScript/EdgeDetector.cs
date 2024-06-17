using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;

public class EdgeDetector : MonoBehaviour
{
    [SerializeField] private MovementController movementController;

    private void OnTriggerExit(Collider other)
    {
        movementController.ChangeDirection();
    }
}
