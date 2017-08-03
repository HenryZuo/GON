using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Data : MonoBehaviour {

	private List<Dictionary<string, string>> gameData = new List<Dictionary<string, string>>();
	private List<Dictionary<string, string>> players = new List<Dictionary<string, string>>();

	void Start() {
		//instantiate game data
		Dictionary<string, string> kings_landing = new Dictionary<string, string>{
			{"name", "King's Landing"},
			{"soldiers", "50000"},
			{"wealth", "100000"},
			{"owner", "Lanisters"}
		};

		Dictionary<string, string> winterfell = new Dictionary<string, string>{
			{"name", "Winterfell"},
			{"soldiers", "20000"},
			{"wealth", "10000"},
			{"owner", "Starks"}
		};

		gameData.Add (kings_landing);
		gameData.Add (winterfell);

		//instantiate players
		Dictionary<string, string> john_snow = new Dictionary<string, string>{
			{"name", "John Snow"},
			{"soldiers", "3000"},
			{"wealth", "1000"},
			{"faction", "Night's Watch"}
		};

		Dictionary<string, string> ned_stark = new Dictionary<string, string>{
			{"name", "Ned Stark"},
			{"soldiers", "30000"},
			{"wealth", "50000"},
			{"faction", "Starks"}
		};

		players.Add (john_snow);
		players.Add (ned_stark);
	}

	/*
	 * Helper method that checks for errors
	 * Inputs: playerNumber (int), attribute to look for (string), value to change the attribute by (int)
	 * Ouputs: string with error message or null;
	*/
	private string playerAttributeErrorHandling(int playerNumber, string attribute, Nullable<int> number) {
		if (playerNumber >= players.Count || playerNumber < 0) {
			return "falsePlayer";
		}
		if (!players [playerNumber].ContainsKey (attribute)) {
			return "falseAttribute";
		}
		if (number.HasValue && (Int32.Parse (players [playerNumber] [attribute]) + number.Value) < 0) {
			return ("not enough " + attribute);
		}
		return null;
	}

	//player get/set function
	public string getPlayerAttribute(int playerNumber, string attribute) {
		//error handling
		string err = playerAttributeErrorHandling(playerNumber, attribute, null);
		if (err != null)
			return err;
		
		return players [playerNumber] [attribute];
	}

	public bool setPlayerNumericAttribute(int playerNumber, string attribute, int number) {
		//error handling
		string err = playerAttributeErrorHandling(playerNumber, attribute, number);
		if (err != null) {
			Debug.Log ("error: " + err);	
			return false;
		}
		players [playerNumber] [attribute] = (float.Parse(players [playerNumber] [attribute]) + number).ToString();
		return true;
	}

	//map tile get/set function
	public string getEvent(int pathLocation) {
		return gameData [pathLocation]["eventType"];
	}

	public string getSoldiers(int pathLocation) {
		return gameData [pathLocation] ["soldiers"];
	}

	public bool setSoldiers(int pathLocation, int number) {
		if (float.Parse(gameData [pathLocation] ["soldiers"]) + number < 0) {
			return false;
		}
		gameData [pathLocation] ["soldiers"] = (float.Parse(gameData [pathLocation] ["soldiers"]) + number).ToString();
		return true;
	}

	public string getWealth(int pathLocation) {
		return gameData [pathLocation] ["wealth"];
	}

	public bool setWealth(int pathLocation, int number) {
		if (float.Parse(gameData [pathLocation] ["wealth"]) + number < 0) {
			return false;
		}
		gameData [pathLocation] ["wealth"] = (float.Parse(gameData [pathLocation] ["wealth"]) + number).ToString();
		return true;
	}
}
