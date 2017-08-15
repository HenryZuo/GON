using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Data : MonoBehaviour {

	private List<Dictionary<string, string>> gameData = new List<Dictionary<string, string>>();
	private List<Dictionary<string, string>> available_generals = new List<Dictionary<string, string>>();
	public List<Dictionary<string, string>> player1_generals = new List<Dictionary<string, string>>();
	private List<Dictionary<string, string>> player2_generals = new List<Dictionary<string, string>>();
	private List<Dictionary<string, string>> player3_generals = new List<Dictionary<string, string>>();
	private List<Dictionary<string, string>> player4_generals = new List<Dictionary<string, string>>();
	private List<Dictionary<string, string>> players = new List<Dictionary<string, string>>();

    public int soldiers = 3000;
	public int totalSoldiers = 10000;

	public int wealth = 100000;
	public int castleWealth = 10000;
	public int castleTaxPercent = 15;

	public void initializeData() {
		//instantiate game data
		Dictionary<string, string> kings_landing = new Dictionary<string, string>{
			{"name", "King's Landing"},
			{"soldiers", "50000"},
			{"wealth", "100000"},
			{"owner", "Lannister"},
            {"type", "castle"}
		};

		Dictionary<string, string> winterfell = new Dictionary<string, string>{
			{"name", "Winterfell"},
			{"soldiers", "20000"},
			{"wealth", "10000"},
			{"owner", "Stark"},
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

		Dictionary<string, string> gain_wealth = new Dictionary<string, string>{
			{"name", "wealth"},
			{"change", "negative"},
			{"events", "You're scouts found an abandoned castle with riches still inside!," +
					   "You are granted a gift from allies across the narrow sea!," +
					   "A distant relative who has no sons passes away. You inherit a small fortune!," +
					   "Your people are blessed with a great harvest. You trade away the excess food!,"},
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

		//instantiate generals
		Dictionary<string, string> ned = new Dictionary<string, string> {
			{"name", "Ned Stark"},
			{"strength", "91"},
			{"intelligence", "65"},
			{"military leadership", "96"},
			{"carry space", "1"},
			{"management", "57"},
			{"terrain advantage", "snow"}
		};

		Dictionary<string, string> robb_stark = new Dictionary<string, string> {
			{"name", "Robb Stark"},
			{"strength", "86"},
			{"intelligence", "58"},
			{"military leadership", "88"},
			{"carry space", "0"},
			{"management", "45"},
			{"terrain advantage", "snow"}
		};

		Dictionary<string, string> catelyn_stark = new Dictionary<string, string> {
			{"name", "Catelyn Stark"},
			{"strength", "39"},
			{"intelligence", "82"},
			{"military leadership", "45"},
			{"carry space", "1"},
			{"management", "71"},
			{"terrain advantage", "none"}
		};

		Dictionary<string, string> bran_stark = new Dictionary<string, string> {
			{"name", "Bran Stark"},
			{"strength", "2"},
			{"intelligence", "99"},
			{"military leadership", "26"},
			{"carry space", "0"},
			{"management", "64"},
			{"terrain advantage", "none"}
		};

		player1_generals.Add(ned);
		player1_generals.Add(robb_stark);
		player1_generals.Add(catelyn_stark);
		player1_generals.Add(bran_stark);

		Dictionary<string, string> daenerys = new Dictionary<string, string> {
			{"name", "Daenerys Targaryen"},
			{"strength", "38"},
			{"intelligence", "85"},
			{"military leadership", "79"},
			{"carry space", "1"},
			{"management", "74"},
			{"terrain advantage", "desert"}
		};

		Dictionary<string, string> viserys_targaryen = new Dictionary<string, string> {
			{"name", "Viserys Targaryen"},
			{"strength", "50"},
			{"intelligence", "60"},
			{"military leadership", "47"},
			{"carry space", "2"},
			{"management", "30"},
			{"terrain advantage", "none"}
		};

		Dictionary<string, string> jorah_mormont = new Dictionary<string, string> {
			{"name", "Jorah Mormont"},
			{"strength", "85"},
			{"intelligence", "75"},
			{"military leadership", "74"},
			{"carry space", "0"},
			{"management", "53"},
			{"terrain advantage", "desert,snow"}
		};

		player2_generals.Add(daenerys);
		player2_generals.Add(viserys_targaryen);
		player2_generals.Add(jorah_mormont);

		Dictionary<string, string> tywin = new Dictionary<string, string> {
			{"name", "Tywin Lannister"},
			{"strength", "48"},
			{"intelligence", "99"},
			{"military leadership", "95"},
			{"carry space", "0"},
			{"management", "99"},
			{"terrain advantage", "grassland"}
		};

		Dictionary<string, string> cersei_lannister = new Dictionary<string, string> {
			{"name", "Cersei Lannister"},
			{"strength", "25"},
			{"intelligence", "80"},
			{"military leadership", "45"},
			{"carry space", "0"},
			{"management", "55"},
			{"terrain advantage", "none"}
		};

		Dictionary<string, string> jaime_lannister = new Dictionary<string, string> {
			{"name", "Jaime Lannister"},
			{"strength", "95"},
			{"intelligence", "61"},
			{"military leadership", "89"},
			{"carry space", "0"},
			{"management", "22"},
			{"terrain advantage", "grassland"}
		};

		Dictionary<string, string> joffrey = new Dictionary<string, string> {
			{"name", "Joffrey Baratheon"},
			{"strength", "46"},
			{"intelligence", "61"},
			{"military leadership", "29"},
			{"carry space", "1"},
			{"management", "13"},
			{"terrain advantage", "grassland"}
		};

		player3_generals.Add(tywin);
		player3_generals.Add(cersei_lannister);
		player3_generals.Add(jaime_lannister);
		player3_generals.Add(joffrey);

		Dictionary<string, string> olenna = new Dictionary<string, string> {
			{"name", "Olenna Tyrell"},
			{"strength", "14"},
			{"intelligence", "93"},
			{"military leadership", "87"},
			{"carry space", "0"},
			{"management", "75"},
			{"terrain advantage", "grassland"}
		};

		Dictionary<string, string> mace_tyrell = new Dictionary<string, string> {
			{"name", "Mace Tyrell"},
			{"strength", "46"},
			{"intelligence", "52"},
			{"military leadership", "53"},
			{"carry space", "1"},
			{"management", "79"},
			{"terrain advantage", "grassland"}
		};

		Dictionary<string, string> margaery_tyrell = new Dictionary<string, string> {
			{"name", "Margaery Tyrell"},
			{"strength", "26"},
			{"intelligence", "90"},
			{"military leadership", "60"},
			{"carry space", "0"},
			{"management", "87"},
			{"terrain advantage", "grassland"}
		};

		Dictionary<string, string> loras_tyrell = new Dictionary<string, string> {
			{"name", "Loras Tyrell"},
			{"strength", "83"},
			{"intelligence", "49"},
			{"military leadership", "58"},
			{"carry space", "1"},
			{"management", "64"},
			{"terrain advantage", "grassland"}
		};

		player4_generals.Add(olenna);
		player4_generals.Add(mace_tyrell);
		player4_generals.Add(margaery_tyrell);
		player4_generals.Add(loras_tyrell);

		//available generals
		Dictionary<string, string> sansa_stark = new Dictionary<string, string> {
			{"name", "Sansa Stark"},
			{"strength", "24"},
			{"intelligence", "80"},
			{"military leadership", "74"},
			{"carry space", "1"},
			{"management", "56"},
			{"terrain advantage", "none"}
		};

		Dictionary<string, string> arya_stark = new Dictionary<string, string> {
			{"name", "Arya Stark"},
			{"strength", "85"},
			{"intelligence", "76"},
			{"military leadership", "36"},
			{"carry space", "0"},
			{"management", "19"},
			{"terrain advantage", "none"}
		};

		Dictionary<string, string> rickon_stark = new Dictionary<string, string> {
			{"name", "Rickon Stark"},
			{"strength", "26"},
			{"intelligence", "48"},
			{"military leadership", "29"},
			{"carry space", "2"},
			{"management", "42"},
			{"terrain advantage", "none"}
		};

		Dictionary<string, string> jon_snow = new Dictionary<string, string> {
			{"name", "Jon Snow"},
			{"strength", "89"},
			{"intelligence", "62"},
			{"military leadership", "91"},
			{"carry space", "1"},
			{"management", "50"},
			{"terrain advantage", "snow"}
		};

		Dictionary<string, string> theon_greyjoy = new Dictionary<string, string> {
			{"name", "Theon Greyjoy"},
			{"strength", "73"},
			{"intelligence", "41"},
			{"military leadership", "67"},
			{"carry space", "1"},
			{"management", "36"},
			{"terrain advantage", "snow"}
		};

		Dictionary<string, string> roose_bolton = new Dictionary<string, string> {
			{"name", "Roose Bolton"},
			{"strength", "78"},
			{"intelligence", "88"},
			{"military leadership", "79"},
			{"carry space", "0"},
			{"management", "72"},
			{"terrain advantage", "snow"}
		};

		Dictionary<string, string> benjen_stark = new Dictionary<string, string> {
			{"name", "Benjen Stark"},
			{"strength", "87"},
			{"intelligence", "71"},
			{"military leadership", "74"},
			{"carry space", "1"},
			{"management", "47"},
			{"terrain advantage", "snow"}
		};

		Dictionary<string, string> hodor = new Dictionary<string, string> {
			{"name", "Hodor"},
			{"strength", "71"},
			{"intelligence", "5"},
			{"military leadership", "2"},
			{"carry space", "3"},
			{"management", "1"},
			{"terrain advantage", "none"}
		};

		Dictionary<string, string> brienne_of_tarth = new Dictionary<string, string> {
			{"name", "Brienne of Tarth"},
			{"strength", "89"},
			{"intelligence", "70"},
			{"military leadership", "68"},
			{"carry space", "1"},
			{"management", "63"},
			{"terrain advantage", "grassland"}
		};

		Dictionary<string, string> greatjon_umber = new Dictionary<string, string> {
			{"name", "Greatjon Umber"},
			{"strength", "75"},
			{"intelligence", "58"},
			{"military leadership", "74"},
			{"carry space", "1"},
			{"management", "68"},
			{"terrain advantage", "snow"}
		};

		Dictionary<string, string> rickard_karstark = new Dictionary<string, string> {
			{"name", "Rickard Karstark"},
			{"strength", "72"},
			{"intelligence", "63"},
			{"military leadership", "66"},
			{"carry space", "1"},
			{"management", "71"},
			{"terrain advantage", "snow"}
		};

		Dictionary<string, string> jeor_mormont = new Dictionary<string, string> {
			{"name", "Jeor Mormont"},
			{"strength", "75"},
			{"intelligence", "66"},
			{"military leadership", "83"},
			{"carry space", "0"},
			{"management", "91"},
			{"terrain advantage", "snow"}
		};

		Dictionary<string, string> tormund_giantsbane = new Dictionary<string, string> {
			{"name", "Tormund Giantsbane"},
			{"strength", "90"},
			{"intelligence", "51"},
			{"military leadership", "84"},
			{"carry space", "0"},
			{"management", "42"},
			{"terrain advantage", "snow"}
		};

		available_generals.Add(sansa_stark);
		available_generals.Add(arya_stark);
		available_generals.Add(rickon_stark);
		available_generals.Add(jon_snow);
		available_generals.Add(theon_greyjoy);
		available_generals.Add(roose_bolton);
		available_generals.Add(benjen_stark);
		available_generals.Add(hodor);
		available_generals.Add(brienne_of_tarth);
		available_generals.Add(greatjon_umber);
		available_generals.Add(rickard_karstark);
		available_generals.Add(jeor_mormont);
		available_generals.Add(tormund_giantsbane);


		//instantiate players
		Dictionary<string, string> ned_stark = new Dictionary<string, string>{
			{"name", "Ned Stark"},
			{"soldiers", "20000"},
			{"wealth", "25000"},
			{"faction", "Stark"},
            {"castle", "0,4"},
            {"generals", "Ned Stark,Robb Stark,Catelyn Stark,Bran Stark"}
		};

		Dictionary<string, string> daenerys_targaryen = new Dictionary<string, string>{
			{"name", "Daenerys Targaryen"},
			{"soldiers", "15000"},
			{"wealth", "10000"},
			{"faction", "Targaryen"},
            {"castle", "0,4"},
            {"generals", "Daenerys Targaryen,Viserys Targaryen,Jorah Mormont"}
		};

		Dictionary<string, string> tywin_lannister = new Dictionary<string, string>{
			{"name", "Tywin Lannister"},
			{"soldiers", "23000"},
			{"wealth", "100000"},
			{"faction", "Targaryen"},
            {"castle", "0,4"},
            {"generals", "Tywin Lannister,Cersei Lannister,Jaime Lannister,Joffrey Lannister,Tommen Lannister,Gregor Clegane"}
		};

		Dictionary<string, string> olenna_tyrell = new Dictionary<string, string>{
			{"name", "Olenna Tyrell"},
			{"soldiers", "100000"},
			{"wealth", "70000"},
			{"faction", "Targaryen"},
            {"castle", "0,4"},
            {"generals", "Olenna Tyrell,Mace Tyrell,Margery Tyrell,Loras Tyrell"}
		};


		players.Add (ned_stark);
		players.Add (daenerys_targaryen);
        players.Add (tywin_lannister);
        players.Add (olenna_tyrell);
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
