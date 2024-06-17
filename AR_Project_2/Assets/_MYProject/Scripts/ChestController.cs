using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    [SerializeField] Animator chestAnimator;
    

    private bool isPlayerInRange = false;

    //Check the option doing this with raycast
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player in the Chest attack area");
            isPlayerInRange = true;
            chestAnimator.SetBool("isPlayerInRanged", true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player left the Chest attack area");
            isPlayerInRange = false;
            chestAnimator.SetBool("isPlayerInRanged", false);
        }
    }

    void Update()
    {
        if (isPlayerInRange)
        {
            // Логика атаки (например, наносить урон игроку)
        }
    }
}
