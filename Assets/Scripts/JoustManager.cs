using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JoustManager : MonoBehaviour
{

    private GameObject DataObj;

    private Data data;
    private GUIController guiController;

    // player stats
    private int curPlayer;

    // castle stats
    private Dictionary<string, string> curCastle;
    private Text enemyChampNameText;
    private Text enemyChampStrengthText;
    private Text enemyChampIntelligenceText;
    private Text playerChampNameText;
    private Text playerChampStrengthText;
    private Text playerChampIntelligenceText;

    // castle
    private string enemyChampName;
    private string enemyChampStrength;
    private string enemyChampIntelligence;
    private string playerChampName;
    private string playerChampStrength;
    private string playerChampIntelligence;

    private Dropdown generals;


    private List<string> options = new List<string>()
    {
        "Ned Stark",
        "Jon Snow",
        "Robb Stark"
    };

    void Awake()
    {
        DataObj = GameObject.Find("GUI Controller");
        data = DataObj.GetComponent<Data>();
        guiController = DataObj.GetComponent<GUIController>();

        curPlayer = guiController.getPlayerNum();

        enemyChampName = data.getEvent(guiController.getCurUnit().PathLocation)["general"];
        enemyChampStrength = data.getGeneralAttribute(enemyChampName, "strength");
        enemyChampIntelligence = data.getGeneralAttribute(enemyChampName, "strength");

        playerChampName = data.getEvent(guiController.getCurUnit().PathLocation)["general"];
        playerChampStrength = data.getGeneralAttribute(playerChampName, "strength");
        playerChampIntelligence = data.getGeneralAttribute(playerChampName, "strength");

        // start enemy champ text
        enemyChampNameText = GameObject.Find("enemyChampName Text").GetComponent<Text>();
        enemyChampNameText.text = "Enemy Champion: " + enemyChampName;
        enemyChampStrengthText = GameObject.Find("enemyChampStrength Text").GetComponent<Text>();
        enemyChampStrengthText.text = "Strength: " + enemyChampStrength;
        enemyChampIntelligenceText = GameObject.Find("enemyChampIntelligence Text").GetComponent<Text>();
        enemyChampIntelligenceText.text = "Intelligence: " + enemyChampIntelligence;

        // start enemy champ text
        playerChampNameText = GameObject.Find("playerChampName Text").GetComponent<Text>();
        playerChampNameText.text = "Your Champion: " + playerChampName;
        playerChampStrengthText = GameObject.Find("playerChampStrength Text").GetComponent<Text>();
        playerChampStrengthText.text = "Strength: " + playerChampStrength;
        playerChampIntelligenceText = GameObject.Find("playerChampIntelligence Text").GetComponent<Text>();
        playerChampIntelligenceText.text = "Intelligence: " + playerChampIntelligence;

        // start general options
        generals = GameObject.Find("Champion Dropdown").GetComponent<Dropdown>();
        generals.ClearOptions();
        generals.AddOptions(options);
    }


    void Update()
    {

    }
    

    public void onFight()
    {

    }

}