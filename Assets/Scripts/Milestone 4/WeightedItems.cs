using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WeightedItems : MonoBehaviour
{

    public List<GameObject> weightedItems;
    public int healthWeight = 30;
    public int rifleWeight = 10;
    public int pistolWeight = 2;

    public GameObject health;
    public GameObject pistol;
    public GameObject rifle;
    private void Start()
    {
        Setup();
    }
    public void RNG()
    {
        int randomNumber = Random.Range(0, weightedItems.Count);
        SpawnItem(randomNumber);
    }
    public void SpawnItem(int random)
    {
        GameObject item = Instantiate(weightedItems[random], GameManager.instance.spawnPoints[0]);
        GameManager.instance.spawnedItem = item;
    }
    void Setup()
    {
        for(int i = 0; i < healthWeight; i++)
        {
            weightedItems.Add(health);
        }
        for (int i = 0; i < pistolWeight; i++)
        {
            weightedItems.Add(pistol);
        }
        for (int i = 0; i < rifleWeight; i++)
        {
            weightedItems.Add(rifle);
        }
    }
}