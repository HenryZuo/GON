using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OwnCastleManager : MonoBehaviour {

	private GameObject data;
	private Data gameData; 
	private int soldiers;
	private Text instruction;
	public Slider soldierSlider;
	private double soldiersToAdd = 0;
	private Text soldiersAddedDisplay;
	private InputField soldiersInput;
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
		instruction = GameObject.Find ("Soldiers").GetComponent<Text> ();
		instruction.text = "Soldiers " + soldiers;
		soldiersAddedDisplay = GameObject.Find ("SoldiersToAdd").GetComponent<Text>();
		soldiersInput = GameObject.Find ("SoldiersInput").GetComponent<InputField>();
		generals.ClearOptions ();
		generals.AddOptions (options);
	}


	void Update(){
	}
		
	public void onSliderChange(){
		soldiersToAdd = System.Math.Ceiling (soldierSlider.value * soldiers);
		soldiersInput.text = soldiersToAdd.ToString();
		soldiersAddedDisplay.text = soldiersToAdd.ToString();
		instruction.text = "Soldiers: " + (soldiers + soldiersToAdd);
	}
}