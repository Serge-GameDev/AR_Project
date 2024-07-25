using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    [SerializeField] private float bounceForce = 10f;
    [SerializeField] private GameObject bounceEffectPrefab;
    [SerializeField] private GameObject gamePadCanvas; // Reference to the GamePad_Canvas
    [SerializeField] private float disableMovementTime = 1f;

    private PlayerMovement playerMovement;

    private void Start()
    {
        // Find the PlayerMovement script on the JoyStick object
        playerMovement = gamePadCanvas.transform.Find("GamePad/JoyStick").GetComponent<PlayerMovement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if collided object has a bounce material
        if (collision.collider.sharedMaterial != null && collision.collider.sharedMaterial.bounciness > 0)
        {
            // Direction of Bounce
            Vector3 bounceDirection = collision.contacts[0].normal;

            // Add bounce force to the player's Rigidbody
            GetComponent<Rigidbody>().AddForce(-bounceDirection * bounceForce, ForceMode.Impulse);

            // Create particle effect
            Instantiate(bounceEffectPrefab, collision.contacts[0].point, Quaternion.identity);

            // Disable player movement for 2 seconds
            StartCoroutine(DisablePlayerMovement());
        }
    }

    private IEnumerator DisablePlayerMovement()
    {
        if (playerMovement != null)
        {
            playerMovement.DisableMovement(disableMovementTime); // Disable movement for 2 seconds
        }
        yield return null;
    }
}
