﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Variables
    public GameObject enemyPrefab;
    public int currentEnemies;
    public int maxEnemies = 2;

    public float spawnDelay = 1f;
    //This will Spawn our enemies
    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnDelay);
    }

    //This will invoke our adding of enemies and where
    public void SpawnEnemy()
    {
        if (currentEnemies <= maxEnemies)
        {
            GameObject enemy = (GameObject)Instantiate(enemyPrefab, this.transform.position, Quaternion.identity);
            Invoke("SpawnEnemy", 5);
            currentEnemies++;
        }
    }
    public void EnemyDeath()
    {
        currentEnemies--;
    }
}
