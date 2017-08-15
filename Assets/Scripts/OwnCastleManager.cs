using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OwnCastleManager : MonoBehaviour {

	private GameObject DataObj;

	private Data data;
    private PersistentGame persistentGame;

    // player stats
    private int curPlayer;
	private int soldiersPlayer;
	private int wealthPlayer;

    // castle stats
    private Dictionary<string, string> curCastle;
	private Text soldiersCastle;
	private Text wealthCastle;

    // castle components
	public Slider soldierSlider;
	public Slider wealthSlider;
	private double soldiersToAdd = 0;
	private double wealthToAdd = 0;
	private Text soldiersAddedDisplay;
	private Text wealthAddedDisplay;
	private InputField soldiersInput;
	private InputField wealthInput;
	private Dropdown generals;


	private List<string> options = new List<string>()
	{
		"Ned Stark",
		"Jon Snow",
		"Robb Stark"
	};

	// Use this for initialization
	void Awake(){
        DataObj = GameObject.Find ("DataObj");
		data = DataObj.GetComponent<Data>();
        persistentGame = DataObj.GetComponent<PersistentGame>();

        curPlayer = persistentGame.getPlayerNum();
        Debug.Log("player soldier string: " + data.getPlayerAttribute(curPlayer, "soldiers"));
        soldiersPlayer = int.Parse(data.getPlayerAttribute(curPlayer, "soldiers"));
        wealthPlayer = int.Parse(data.getPlayerAttribute(curPlayer, "wealth"));

        // curCastle = data.getEvent(persistentGame.getCurUnit().PathLocation);
        curCastle = data.getKingsLanding();
        Debug.Log("curCastle: " + curCastle);

        soldiersCastle = GameObject.Find ("Soldiers").GetComponent<Text> ();
		soldiersCastle.text = "Soldiers: " + curCastle["soldiers"];
		//wealthCastle = GameObject.Find ("Wealth").GetComponent<Text> ();
		//wealthCastle.text = "Wealth: " + curCastle["wealth"];

        soldiersAddedDisplay = GameObject.Find ("SoldiersToAdd").GetComponent<Text>();
		soldiersInput = GameObject.Find ("SoldiersInput").GetComponent<InputField>();
		wealthAddedDisplay = GameObject.Find ("WealthToAdd").GetComponent<Text> ();
		wealthInput = GameObject.Find ("WealthInput").GetComponent<InputField> ();

		
	}


	void Update(){
        //generals.ClearOptions();
        //generals.AddOptions(options);
    }
		
	public void onSoldierSliderChange(){
		soldiersToAdd = System.Math.Ceiling (soldierSlider.value * soldiersPlayer);
		soldiersInput.text = soldiersToAdd.ToString();
		soldiersAddedDisplay.text = soldiersToAdd.ToString();
		soldiersCastle.text = "Soldiers: " + (soldiersPlayer + soldiersToAdd);
	}

	public void onWealthSliderChange(){
		wealthToAdd = System.Math.Ceiling (wealthSlider.value * wealthPlayer);
		wealthInput.text = wealthToAdd.ToString ();
		wealthAddedDisplay.text = wealthToAdd.ToString ();
		wealthCastle.text = "Wealth: " + (wealthPlayer + wealthToAdd);
	}
}