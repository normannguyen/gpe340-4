//Norman Nguyen
//Options: Change the text mostly when you click a button
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    //Text
    public Text currentMapTXT;
    public Text playerText;
    //Buttons
    public Button randomMap;
    public Button MOTD;
    public Button P1;
    public Button P2;

    // Use this for initialization
    void Start()
    {
        Button MOTDBtn = MOTD.GetComponent<Button>();
        Button RandomBtn = randomMap.GetComponent<Button>();
        Button P1Btn = P1.GetComponent<Button>();
        Button P2Btn = P2.GetComponent<Button>();
        RandomBtn.onClick.AddListener(RandomMap_Click);
        MOTDBtn.onClick.AddListener(MapOfTheDay_Click);
        P1Btn.onClick.AddListener(P1_Click);
        P2Btn.onClick.AddListener(P2_Click);
    }

    // Update is called once per frame
    void Update()
    {

    }
    //Random Map Click
    public void RandomMap_Click()
    {
        Button button = randomMap.GetComponent<Button>();
        currentMapTXT.text = "Random Map";
    }
    //Map of the Day Click
    public void MapOfTheDay_Click()
    {
        Button button = MOTD.GetComponent<Button>();
        currentMapTXT.text = "Map of the Day";
    }
    //Player 1 Click
    public void P1_Click()
    {
        Button button = P1.GetComponent<Button>();
        playerText.text = "1";
    }
    //Player 2 Click
    public void P2_Click()
    {
        Button button = P2.GetComponent<Button>();
        playerText.text = "2";
    }
}
