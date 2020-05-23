using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WeightedItems : MonoBehaviour
{
    [Header("Weight Attributes")]
    public List<GameObject> weightedItems;
    public int healthWeight = 30;
    public int rifleWeight = 10;
    public int pistolWeight = 2;

    [Header("Items")]
    public GameObject health;
    public GameObject pistol;
    public GameObject rifle;

    public int randomNumber;
    private void Start()
    {
        Setup();
    }
    //Random Generator
    public void RNG()
    {
        randomNumber = Random.Range(0, weightedItems.Count);
        SpawnItem(randomNumber, GameManager.instance.spawnPoints[0]);
    }
    //Spawn Item
    public void SpawnItem(int random, Transform location)
    {
        GameObject item = Instantiate(weightedItems[random], location);
        GameManager.instance.spawnedItem = item;
    }
    //Spawn Location
    public void GetEnemyLocation(Transform location)
    {
        SpawnItem(randomNumber, location);
    }
    //Setup the weight
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