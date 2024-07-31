using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> coinPositions; // List of possible coin spawn positions
    [SerializeField] private GameObject coinPrefab; // Prefab of the coin
    [SerializeField] private float timer = 10f; // Timer for collecting the coin

    private GameObject currentCoin; // Reference to the current coin
    private float countdownTimer; // Timer for the current coin
    private int score = 0; // Player's score

    private void Start()
    {
        // Start the first coin spawn
        SpawnCoin();
    }

    private void Update()
    {
        // Countdown logic
        if (currentCoin != null)
        {
            countdownTimer -= Time.deltaTime;
            if (countdownTimer <= 0f)
            {
                // Time's up, spawn a new coin
                Destroy(currentCoin);
                SpawnCoin();
            }
        }
    }
    
        public void SpawnCoin()
        {
            if (coinPositions.Count == 0)
            {
                Debug.LogWarning("No coin positions assigned!");
                return;
            }

            // Randomly select a spawn position
            int randomIndex = Random.Range(0, coinPositions.Count);
            Transform spawnPosition = coinPositions[randomIndex];

            // Spawn the coin at the selected position
            currentCoin = Instantiate(coinPrefab, spawnPosition.position, coinPrefab.transform.rotation);
            currentCoin.GetComponent<Coin>().Initialize(this);

            // Reset the timer
            countdownTimer = timer;
        }
    

   
    public void CollectCoin(GameObject coin)
    {
        if (coin == currentCoin)
        {
            // Increment the score
            score++;
            Debug.Log("Score: " + score);

            // Destroy the collected coin and spawn a new one
            Destroy(currentCoin);
            SpawnCoin();
        }
    }
}
