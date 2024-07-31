using UnityEngine;

public class Coin : MonoBehaviour
{
    private CoinSpawner spawner;

    public void Initialize(CoinSpawner spawner)
    {
        this.spawner = spawner;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player collided with the coin
        if (other.CompareTag("Player"))
        {
            // Notify the spawner that the coin was collected
            spawner.CollectCoin(gameObject);
        }
    }
}
