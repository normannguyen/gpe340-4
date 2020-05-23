using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Variables
    public GameObject enemyPrefab;
    public int currentEnemies;
    public int maxEnemies = 2;
    public GameObject particleSpawn;
    public float spawnDelay = 3f;
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
            SpawnEffect();
            Invoke("SpawnEnemy", 5);
            currentEnemies++;
        }
    }
    public void EnemyDeath()
    {
        currentEnemies--;
    }

    void SpawnEffect()
    {
        GameObject collision = Instantiate(particleSpawn, transform.position, Quaternion.identity);
        collision.GetComponent<ParticleSystem>().Play();
    }

}
