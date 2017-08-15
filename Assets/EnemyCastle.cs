using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCastle : MonoBehaviour {

	private GameObject data;
	private Data gameData;
	private int soldiers;
	private int wealth;
	private int tax;
	private Text soldiersInCastle;
	private Text wealthInCastle;
	private Text castleTax;


	void Awake(){
		data = GameObject.Find ("DataObj");
		gameData = data.GetComponent<Data> ();
		soldiers = gameData.soldiers;
		wealth = gameData.wealth; //castle's wealth
		tax = (gameData.castleTaxPercent * wealth) / 100; //tax paid (percentage of castle's wealth)
		soldiersInCastle = GameObject.Find ("Soldiers").GetComponent<Text> ();
		soldiersInCastle.text = "Soldiers: " + soldiers;
		wealthInCastle = GameObject.Find ("Wealth").GetComponent<Text> ();
		wealthInCastle.text = "Wealth: " + wealth;

		castleTax = GameObject.Find ("TaxRate").GetComponent<Text> ();

		castleTax.text = "Tax (" + gameData.castleTaxPercent + "%): " + tax;

	}
}
