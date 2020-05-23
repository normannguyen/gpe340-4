using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject[] enemies;
    public Transform[] spawnPoints;
    public Pawn pawn;
    public int currentEnemyCount;
    public int maxActiveEnemies;

    public GameObject weaponIMG;

    public GameObject spawnedItem;
    public WeightedItems weights;
    public int numberOfEnemies;
    public static bool pausedGame;
    //Lives
    public GameObject playerPrefab;
    //public List<GameObject> enemyPrefab;
    public int Lives = 3;
    public Text lives;

    public GameObject pauseMenu;

    public float sfxVolume;
    public float musicVolume;
    //public GameObject optionMenu;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
        lives = GameObject.Find("LivesText").GetComponent<Text>();
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
        LivesUI();
        float playerHealth = GameObject.Find("Player").GetComponent<Pawn>().currentHealth;
        if (playerHealth <= 0)
        {
            respawnPlayer();
        }
        if (Lives == 0)
        {
            GameOver();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausedGame)
            {
                Unpause();
            }
            else
            {
                Pause();
            }
        }
        if(spawnedItem == null)
        {
            weights.RNG();
        }
    }
    public void SpawnPlayer()
    {
        Vector3 position = new Vector3(Random.Range(3.0f, 3.0f), 0, Random.Range(3.0f, 3.0f));
        GameObject playerSpawnObject = Instantiate(playerPrefab, position, Quaternion.identity) as GameObject;
        playerSpawnObject.transform.parent = this.transform;
        playerSpawnObject.name = "Player";
        playerPrefab.gameObject.SetActive(true);
    }
    public void respawnPlayer()
    {
        LivesUI();
        GameObject player = GameObject.Find("Player");
        player.GetComponent<Pawn>().currentHealth = 100;
        Lives--;
        Vector3 position = new Vector3(Random.Range(3.0f, 3.0f), 0, Random.Range(3.0f, 3.0f));
        player.transform.position = position;
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
    void LivesUI()
    {
        lives.text = "Lives: " + Lives.ToString();
    }
    public void PauseMenu()
    {

    }
    public void OptionMenu()
    {

    }
    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
    public void EnemyItem(GameObject itemDrop)
    {
        weights.RNG();
    }
    public void setSFXVolume(float volume)
    {
        sfxVolume = volume;
    }
    public void setMusicVolume(float volume)
    {
        musicVolume = volume;
    }
}
