using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class JoustManager : MonoBehaviour
{

    private GameObject DataObj;

    private Data data;
    private GUIController guiController;

    // outcome text
    private GameObject outcomeTextObj;

    // player stats
    private int curPlayer;
    private List<string> generalsPlayer;

    // castle stats
    private Dictionary<string, string> curCastle;
    private Text enemyChampNameText;
    private Text enemyChampStrengthText;
    private Text enemyChampIntelligenceText;
    private Text playerChampNameText;
    private Text playerChampStrengthText;
    private Text playerChampIntelligenceText;

    // castle
    private Dictionary<string, string> enemyCastle;
    private string enemyChampName;
    private string enemyChampStrength;
    private string enemyChampIntelligence;
    private string playerChampName;
    private string playerChampStrength;
    private string playerChampIntelligence;
    
    private Dropdown generalsDropdown;
    

    void Awake()
    {
        DataObj = GameObject.Find("GUI Controller");
        data = DataObj.GetComponent<Data>();
        guiController = DataObj.GetComponent<GUIController>();

        curPlayer = guiController.getPlayerNum();

        enemyCastle= data.getEvent(guiController.getCurUnit().PathLocation);

        enemyChampName = enemyCastle["general"];
        enemyChampStrength = data.getGeneralAttribute(enemyChampName, "strength", data.getPlayerByHouse(enemyCastle["house"]));
        enemyChampIntelligence = data.getGeneralAttribute(enemyChampName, "strength", data.getPlayerByHouse(enemyCastle["house"]));

        playerChampName = "----";
        playerChampStrength = "----";
        playerChampIntelligence = "----";

        // start enemy champ text
        enemyChampNameText = GameObject.Find("enemyChampName Text").GetComponent<Text>();
        enemyChampNameText.text = "Enemy Champion: " + enemyChampName;
        enemyChampStrengthText = GameObject.Find("enemyChampStrength Text").GetComponent<Text>();
        enemyChampStrengthText.text = "Strength: " + enemyChampStrength;
        enemyChampIntelligenceText = GameObject.Find("enemyChampIntelligence Text").GetComponent<Text>();
        enemyChampIntelligenceText.text = "Intelligence: " + enemyChampIntelligence;

        // start player champ text
        playerChampNameText = GameObject.Find("playerChampName Text").GetComponent<Text>();
        playerChampNameText.text = "Your Champion: " + playerChampName;
        playerChampStrengthText = GameObject.Find("playerChampStrength Text").GetComponent<Text>();
        playerChampStrengthText.text = "Strength: " + playerChampStrength;
        playerChampIntelligenceText = GameObject.Find("playerChampIntelligence Text").GetComponent<Text>();
        playerChampIntelligenceText.text = "Intelligence: " + playerChampIntelligence;

        // start general dropdown
        generalsPlayer = data.getPlayerAttribute(curPlayer, "generals").Split(',').ToList();
        generalsDropdown = GameObject.Find("Champion Dropdown").GetComponent<Dropdown>();
        generalsDropdown.ClearOptions();
        generalsDropdown.AddOptions(generalsPlayer);

        // start curCastle
        curCastle = data.getEvent(guiController.getCurUnit().PathLocation);
    }


    void Update()
    {

    }


    public void onGeneralDropdownChange()
    {
        // set player champ text
        playerChampName = generalsDropdown.captionText.text;
        playerChampStrength = data.getGeneralAttribute(playerChampName, "strength", curPlayer);
        playerChampIntelligence= data.getGeneralAttribute(playerChampName, "intelligence", curPlayer);
        playerChampNameText.text = "Your Champion: " + playerChampName;
        playerChampStrengthText.text = "Strength: " + playerChampStrength; 
        playerChampIntelligenceText.text = "Intelligence: " + playerChampIntelligence;
    }


    public void onFight()
    {
        if(playerChampName != "----")
        {
            var diff;
            try
            {
                diff = (int.Parse(playerChampStrength) - int.Parse(enemyChampStrength)) * 3;
            }
            catch
            {
                diff = 0;
            }
            var rand = UnityEngine.Random.Range(0, 100);
            if(rand + diff > 50)
            {
                joustWin();
            } else
            {
                joustLose();
            }

        }
    }

    public void joustWin()
    {
        string winStr = playerChampName + " defeated " + enemyChampName + " in the Joust! Your general's victory exempted you from the toll!";
        // start outcome panel
        outcomeTextObj = GameObject.Find("Outcome Text");
        outcomeTextObj.GetComponent<Text>().text = winStr;

        guiController.EndTurn();
    }

    public void joustLose()
    {
        string castleWealth = curCastle["wealth"];
        int toll = (int)Math.Ceiling(Math.Max(100, int.Parse(castleWealth) * 0.4));
        string loseStr = "You lost the Joust and must pay double! You lost " + toll + " in wealth.";

        data.setPlayerNumericAttribute(curPlayer, "wealth", 0 - toll);
        data.setPlayerNumericAttribute(data.getPlayerByHouse(curCastle["house"]), "wealth", toll);

        // start outcome panel
        outcomeTextObj = GameObject.Find("Outcome Text");
        outcomeTextObj.GetComponent<Text>().text = loseStr;

        guiController.EndTurn();
    }
}