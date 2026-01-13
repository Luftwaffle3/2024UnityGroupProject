using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootManager : MonoBehaviour
{
    public GameObject coinPrefab;
    public GameObject[] potionPrefabs;

    public void SpawnLoot(Vector3 position)
    {
        // Spawn coins
        SpawnCoins(position);

        // Spawn potions
        SpawnPotion(position);
    }

    private void SpawnCoins(Vector3 position)
    {
        int numberOfCoins = Random.Range(3, 6); // Change the range as per your requirement

        for (int i = 0; i < numberOfCoins; i++)
        {
            Instantiate(coinPrefab, position, Quaternion.identity);
        }
    }

    private void SpawnPotion(Vector3 position)
    {
        int numberOfPotions = Random.Range(1, 2); // Change the range to spawn 0 to 1 potions

        for (int i = 0; i < numberOfPotions; i++)
        {
            int randomIndex = Random.Range(0, potionPrefabs.Length);
            Instantiate(potionPrefabs[randomIndex], position, Quaternion.identity);
        }
    }
}
