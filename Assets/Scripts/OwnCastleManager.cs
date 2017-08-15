using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OwnCastleManager : MonoBehaviour {

	private GameObject data;
	private Data gameData; 
	private int soldiers;
	private int wealth;
	private Text soldiersInCastle;
	private Text wealthInCastle;
	public Slider soldierSlider;
	public Slider wealthSlider;
	private double soldiersToAdd = 0;
	private double wealthToAdd = 0;
	private Text soldiersAddedDisplay;
	private Text wealthAddedDisplay;
	private InputField soldiersInput;
	private InputField wealthInput;
	public Dropdown generals;
	private List<string> options = new List<string>()
	{
		"Ned Stark",
		"Jon Snow",
		"Robb Stark"
	};

	// Use this for initialization
	void Awake(){
		data = GameObject.Find ("DataObj");
		gameData = data.GetComponent<Data>();
		soldiers = gameData.soldiers;
		wealth = gameData.wealth;
		soldiersInCastle = GameObject.Find ("Soldiers").GetComponent<Text> ();
		soldiersInCastle.text = "Soldiers: " + soldiers;
		wealthInCastle = GameObject.Find ("Wealth").GetComponent<Text> ();
		wealthInCastle.text = "Wealth: " + wealth;

		soldiersAddedDisplay = GameObject.Find ("SoldiersToAdd").GetComponent<Text>();
		soldiersInput = GameObject.Find ("SoldiersInput").GetComponent<InputField>();
		wealthAddedDisplay = GameObject.Find ("WealthToAdd").GetComponent<Text> ();
		wealthInput = GameObject.Find ("WealthInput").GetComponent<InputField> ();

		generals.ClearOptions ();
		generals.AddOptions (options);
	}


	void Update(){
	}
		
	public void onSoldierSliderChange(){
		soldiersToAdd = System.Math.Ceiling (soldierSlider.value * soldiers);
		soldiersInput.text = soldiersToAdd.ToString();
		soldiersAddedDisplay.text = soldiersToAdd.ToString();
		soldiersInCastle.text = "Soldiers: " + (soldiers + soldiersToAdd);
	}

	public void onWealthSliderChange(){
		wealthToAdd = System.Math.Ceiling (wealthSlider.value * wealth);
		wealthInput.text = wealthToAdd.ToString ();
		wealthAddedDisplay.text = wealthToAdd.ToString ();
		wealthInCastle.text = "Wealth: " + (wealth + wealthToAdd);
	}
}