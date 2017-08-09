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
			{"owner", "Lanisters"},
            {"type", "castle"}
		};

		Dictionary<string, string> winterfell = new Dictionary<string, string>{
			{"name", "Winterfell"},
			{"soldiers", "20000"},
			{"wealth", "10000"},
			{"owner", "Starks"},
            {"type", "castle"}
        };

        Dictionary<string, string> lose_soldiers = new Dictionary<string, string>{
            {"name", "soldiers"},
            {"change", "negative"},
            {"events", "Greyscale has infected some of your soldiers. They must be exiled before everyone is afflicted!," +
                       "Your supply carts have been delayed and you don't have enough food!," +
                       "Winter is coming and strange things lurk about in the night. Some of your soldiers scare and desert you!," +
                       "You are attacked by the Hill Tribes and caught by suprise!," +
                       "Wildings have made it past the wall and raid your camp during the night!," +
                       "Your army has been attacked by a group of dire wolves!"},
            {"type", "random"}
        };

        Dictionary<string, string> gain_soldiers = new Dictionary<string, string>{
            {"name", "soldiers"},
            {"change", "positive"},
            {"events", "Bannermen have arrived to aid your cause!," +
                       "A group of unsullied has arrived as a gift!," +
                       "Your righteous actions have swayed enemies to join your cause!," +
                       "A new alliance has been brokered and fresh soldiers flock to your aid!," +
                       "Mysterious hooded figures ride up to your camp in the dead of night. You find that it is your bastard son and his followers!"},
            {"type", "random"}
        };
        Dictionary<string, string> lose_wealth = new Dictionary<string, string>{
            {"name", "wealth"},
            {"change", "negative"},
            {"events", "Enemy spies have infiltrated your camp and pilfered your coffers!," +
                       "You encounter a Dothraki hoard and must pay tribute to avoid battle!," +
                       "It is time to pay off loans to the Iron Bank of Braavos!," +
                       "Morale is low and you must hold a feast to raise people's spirits!"},
            {"type", "random"}
        };

        gameData.Add(lose_soldiers);
        gameData.Add(gain_soldiers);
        gameData.Add(lose_wealth);
        gameData.Add(lose_soldiers);
        gameData.Add(gain_soldiers);
        gameData.Add(lose_soldiers);
        gameData.Add(lose_wealth);
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
	public Dictionary<string, string> getEvent(int pathLocation) {
		return gameData [pathLocation];
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
