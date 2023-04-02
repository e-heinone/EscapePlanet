using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public ChooseRandomRayFromSpace rayFromSpace;

    private int numberOfEnemiesSpawned;
    private float timeUntilSpawning = 100000f;

    public GameObject[] enemyTypes;

    private void Update()
    {
        SpawnTimer();
    }

    private void SpawnTimer()
    {
        timeUntilSpawning -= Time.deltaTime;

        if (timeUntilSpawning <= 0f)
        {
            int rnd = Random.Range(0, enemyTypes.Length);

            timeUntilSpawning = 10f;
            rayFromSpace.ShootRay();

            SpawnEnemiesOfType(enemyTypes[rnd]);
        }
    }

    private void SpawnEnemiesOfType(GameObject enemyType)
    {
        int rnd = Random.Range(1, 11);

        for (int i = 0; i < rnd; i++)
        {
            Instantiate(enemyType, rayFromSpace.targetLocation + new Vector3(0, 0 + 5f, 0), Quaternion.identity);
            Debug.Log("Spawned: " + enemyType + " at " + rayFromSpace.targetLocation);
        }
    }
}
