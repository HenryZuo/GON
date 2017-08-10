using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayNumSoldiers : MonoBehaviour {

	private GameObject data;
	private Data gameData; 
	private string soldiers;
	private Text instruction;


	// Use this for initialization
	void Awake(){
		data = GameObject.Find ("DataObj");
		gameData = data.GetComponent<Data>();
		soldiers = gameData.soldiers.ToString();
		Debug.Log (soldiers);
		instruction = GameObject.Find ("Soldiers").GetComponent<Text> ();
		instruction.text = "This castle currently has soldiers: " + soldiers;
	}

	void Update(){
			
	}
}
