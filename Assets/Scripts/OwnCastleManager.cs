using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OwnCastleManager : MonoBehaviour {

	private GameObject DataObj;

	private Data data;
    private GUIController guiController;

    // player stats
    private int curPlayer;
	private int soldiersPlayer;
	private int wealthPlayer;

    // castle stats
    private Dictionary<string, string> curCastle;
	private Text soldiersCastleText;
	private Text wealthCastleText;
    private Text generalCastleText;
    private Text nameCastleText;
    private Text tollCastleText;

    // castle components
    private Slider soldierSlider;
    private Slider wealthSlider;
	private Dropdown generals;


	private List<string> options = new List<string>()
	{
		"Ned Stark",
		"Jon Snow",
		"Robb Stark"
	};
    
    
    void Start(){
        DataObj = GameObject.Find("GUI Controller");
        data = DataObj.GetComponent<Data>();
        guiController = DataObj.GetComponent<GUIController>();

        curPlayer = guiController.getPlayerNum();
        soldiersPlayer = int.Parse(data.getPlayerAttribute(curPlayer, "soldiers"));
        wealthPlayer = int.Parse(data.getPlayerAttribute(curPlayer, "wealth"));

        curCastle = data.getEvent(guiController.getCurUnit().PathLocation);
        
        // start castle name
        nameCastleText = GameObject.Find("nameCastle Text").GetComponent<Text>();
        nameCastleText.text = curCastle["name"];

        // start general name
        generalCastleText = GameObject.Find("generalCastle Text").GetComponent<Text>();
        generalCastleText.text = "Guarded by: " + curCastle["general"];

        // start soldier slider 
        soldierSlider = GameObject.Find("SoldierSlider").GetComponent<Slider>();
        soldierSlider.maxValue = int.Parse(curCastle["max_soldiers"]);
        soldierSlider.value = int.Parse(curCastle["soldiers"]);
        soldiersCastleText = GameObject.Find("soldiersCastle Text").GetComponent<Text>();
        soldiersCastleText.text = curCastle["soldiers"] + " / " + curCastle["max_soldiers"];

        // start wealth slider 
        wealthSlider = GameObject.Find("WealthSlider").GetComponent<Slider>();
        wealthSlider.maxValue = int.Parse(curCastle["max_wealth"]);
        wealthSlider.value = int.Parse(curCastle["wealth"]);
        wealthCastleText = GameObject.Find("wealthCastle Text").GetComponent<Text>();
        wealthCastleText.text = curCastle["wealth"] + " / " + curCastle["max_wealth"];

        // start toll
        tollCastleText = GameObject.Find("tollCastle Text").GetComponent<Text>();
        tollCastleText.text = "Toll: " + getToll(wealthSlider.value).ToString();

        // start general options
        generals = GameObject.Find("General Dropdown").GetComponent<Dropdown>();
        generals.ClearOptions();
        generals.AddOptions(options);
    }


	void Update(){

    }
		
	public void onSoldierSliderChange(){
        if (soldiersCastleText != null) {
            soldiersCastleText.text = Math.Ceiling(soldierSlider.value).ToString() + " / " + curCastle["max_soldiers"]; ;
        }
    }

	public void onWealthSliderChange(){
        if (wealthCastleText != null)
        {
            wealthCastleText.text = Math.Ceiling(wealthSlider.value).ToString() + " / " + curCastle["max_wealth"];
            tollCastleText.text = "Toll: " + getToll(wealthSlider.value).ToString();
        }
    }

    public void onGeneralDropdownChange()
    {
        generalCastleText.text = generals.itemText.text;
    }

    public int getToll( float castleWealth )
    {
        return (int) Math.Ceiling(Math.Max(100, castleWealth * 0.2));
    }

    public void OnOK()
    {
        int soldierChangeCastle = (int) Math.Ceiling(soldierSlider.value) - int.Parse(curCastle["soldiers"]);
        int wealthChangeCastle = (int)Math.Ceiling(wealthSlider.value) - int.Parse(curCastle["wealth"]);
        int newSoldiersPlayer = soldiersPlayer - soldierChangeCastle;
        int newWealthPlayer = wealthPlayer - wealthChangeCastle;
        if ( (newSoldiersPlayer > 0) && (newWealthPlayer > 0))
        {
            data.setPlayerNumericAttribute(curPlayer, "soldiers", 0 - soldierChangeCastle);
            data.setPlayerNumericAttribute(curPlayer, "wealth", 0 - wealthChangeCastle);
            guiController.updatePlayerUI();
            data.setCastleNumericAttribute(curCastle["name"], "soldiers", (int)Math.Ceiling(soldierSlider.value));
            data.setCastleNumericAttribute(curCastle["name"], "wealth", (int)Math.Ceiling(wealthSlider.value));
            SceneManager.LoadScene(1);
            guiController.EndTurn();
        }
    }
}