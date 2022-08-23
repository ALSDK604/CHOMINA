using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] Zombie zombiePrefab;
    [SerializeField] Transform[] zombieSpawnPoints;
    [SerializeField] ZombieData zombieData;

    public bool zombieIsDead = false;

    void Start()
    {
        SpawnZombie();
    }

    void Update()
    {
        if (zombieIsDead)
        {
            ZombieReSpawn();
            zombieIsDead = false;
        }
    }

    void SpawnZombie()
    {
        for (int i = 0; i < zombieSpawnPoints.Length; i++)
        {
            Transform spawnPoint = zombieSpawnPoints[Random.Range(0, zombieSpawnPoints.Length)];

            Zombie zombie = Instantiate(zombiePrefab, spawnPoint);

            zombie.SetUp(zombieData);
        }
    }

    void ZombieReSpawn()
    {
        Transform spawnPoint = zombieSpawnPoints[Random.Range(0, zombieSpawnPoints.Length)];

        Zombie zombie = Instantiate(zombiePrefab, spawnPoint);

        zombie.SetUp(zombieData);
    }
}
