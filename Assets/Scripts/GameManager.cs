using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject player;
    public Weapon equippedWeapon;

    public GameObject[] enemies;
    public Transform[] spawnPoints;

    public int currentEnemyCount;
    public int maxActiveEnemies;

    public int numberOfEnemies;
    public bool pausedGame;
    //Lives
    public GameObject playerPrefab;
    public List<GameObject> enemyPrefab;
    public int player1Lives = 3;
    public GameObject pauseMenu;

    public GameObject[] itemDrops;
    public List<GameObject> weightedDrops;
    public int healthDropWeight;
    public int machineGunDropsWeight;
    public int pistolDropsWeight;
    public int noDropWeight;
    private int healthDropsIndex = 0;
    private int machineGunDropsIndex = 1;
    private int pistolDropsIndex = 2;
    private int noDropIndex = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Awake()
    {
        // Setup the singleton
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausedGame == false)
            {
                Pause();
            }
            else
            {
                Unpause();
            }
        }
    }
    GameObject respawnPlayer()
    {
        player1Lives--;
        Vector3 position = new Vector3(Random.Range(-60.0f, 60.0f), -5, Random.Range(-60.0f, 60.0f));
        GameObject playerRespawn = Instantiate(playerPrefab, position, Quaternion.identity) as GameObject;
        playerRespawn.name = "Tank";
        return playerRespawn;
    }
    public GameObject RandomEnemyPrefab()
    {
        return enemyPrefab[Random.Range(0, enemyPrefab.Count)];
    }
    public void spawnEnemy()
    {
        for(int enemies = 0; enemies < numberOfEnemies; enemies++)
        {
            //Vector3 Position for the tank ranging withint -60 to 60 in X and Z
            Vector3 position = new Vector3(Random.Range(-60.0f, 60.0f), -5, Random.Range(-60.0f, 60.0f));
            //Spawn the object based on the enemies listed
            GameObject enemySpawnedObject =
                Instantiate(RandomEnemyPrefab(), position, Quaternion.identity) as GameObject;
            enemySpawnedObject.transform.parent = this.transform;
            //Name of the Enemy Tank
            enemySpawnedObject.name = "Enemy Tank (" + enemies + ")";
        }
    }
    public void Pause()
    {
        pausedGame = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;

    }
    //Unpause
    public void Unpause()
    {
        pausedGame = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;

    }
}
