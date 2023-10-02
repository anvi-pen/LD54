using System.Collections;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{


    public Collectibles[] collectibles; // Assign your collectibles and their chances here in the Unity editor.
    public Vector3 spawnRange = new Vector3(5, 0, 5); // Adjust the range as necessary.

    private void Start()
    {
        int specificCollectibleIndex = 0; // For this example, I'm assuming the first collectible is the one that needs to spawn exactly 3 times.
        for (int i = 0; i < 3; i++) 
        {
            SpawnCollectible(specificCollectibleIndex);
        }

        for (int i = 0; i < 4; i++) // since we've already spawned 3 of a specific collectible, we only need to spawn 4 more.
        {
            SpawnCollectibleWithChance();
        }
    }

    void SpawnCollectible(int index)
    {
        Vector3 spawnPos = transform.position + new Vector3(Random.Range(-spawnRange.x, spawnRange.x), 0, Random.Range(-spawnRange.z, spawnRange.z));
        Instantiate(collectibles[index], spawnPos, Quaternion.identity);
    }

    void SpawnCollectibleWithChance()
    {
        float totalChance = 0;
        foreach (var c in collectibles)
        {
            totalChance += c.spawnChance;
        }

        float randomValue = Random.Range(0, totalChance);
        float currentSum = 0;

        for (int i = 0; i < collectibles.Length; i++)
        {
            currentSum += collectibles[i].spawnChance;
            if (randomValue <= currentSum)
            {
                SpawnCollectible(i);
                return;
            }
        }
    }
}