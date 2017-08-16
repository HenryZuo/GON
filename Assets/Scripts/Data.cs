using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Data : MonoBehaviour {

	private List<Dictionary<string, string>> gameData = new List<Dictionary<string, string>>();
	private List<Dictionary<string, string>> available_generals = new List<Dictionary<string, string>>();
	private List<Dictionary<string, string>> player1_generals = new List<Dictionary<string, string>>();
	private List<Dictionary<string, string>> player2_generals = new List<Dictionary<string, string>>();
	private List<Dictionary<string, string>> player3_generals = new List<Dictionary<string, string>>();
	private List<Dictionary<string, string>> player4_generals = new List<Dictionary<string, string>>();
	private List<Dictionary<string, string>> players = new List<Dictionary<string, string>>();
	private List<Dictionary<string, string>> random_events = new List<Dictionary<string, string>> ();
	private List<Dictionary<string, string>> castles = new List<Dictionary<string, string>>();

	public void initializeData() {
        //instantiate game data
        Dictionary<string, string> high_garden = new Dictionary<string, string>{
			{"name", "High Garden"},
			{"soldiers", "3000"},
			{"wealth", "5000"},
			{"owner", "Tyrell"},
			{"general", ""},
			{"type", "castle"},
            {"max_soldiers", "20000" },
            {"max_wealth", "20000" },

        };
		castles.Add (high_garden);

		Dictionary<string, string> casterly_rock = new Dictionary<string, string>{
			{"name", "Casterly Rock"},
			{"soldiers", "1000"},
			{"wealth", "4000"},
			{"owner", "Lannister"},
			{"general", ""},
			{"type", "castle"},
            {"max_soldiers", "20000" },
            {"max_wealth", "20000" },
        };
		castles.Add (casterly_rock);

		Dictionary<string, string> riverrun = new Dictionary<string, string>{
			{"name", "Riverrun"},
			{"soldiers", "100"},
			{"wealth", "50"},
			{"owner", "Lannister"},
			{"general", ""},
			{"type", "castle"},
            {"max_soldiers", "20000" },
            {"max_wealth", "20000" },
        };
		castles.Add (riverrun);

		Dictionary<string, string> iron_islands = new Dictionary<string, string>{
			{"name", "The Iron Islands"},
			{"soldiers", "200"},
			{"wealth", "10"},
			{"owner", "Greyjoy"},
			{"general", ""},
			{"type", "castle"},
            {"max_soldiers", "20000" },
            {"max_wealth", "20000" },
        };
		castles.Add (iron_islands);

		Dictionary<string, string> the_twins = new Dictionary<string, string>{
			{"name", "The Twins"},
			{"soldiers", "4000"},
			{"wealth", "30"},
			{"owner", "Frey"},
			{"general", ""},
			{"type", "castle"},
            {"max_soldiers", "20000" },
            {"max_wealth", "20000" },
        };
		castles.Add (the_twins);

		Dictionary<string, string> dreadfort = new Dictionary<string, string>{
			{"name", "The Dreadfort"},
			{"soldiers", "1500"},
			{"wealth", "200"},
			{"owner", "Starks"},
			{"type", "castle"},
            {"max_soldiers", "20000" },
            {"max_wealth", "20000" },
        };
		castles.Add (dreadfort);

		Dictionary<string, string> castle_black = new Dictionary<string, string>{
			{"name", "Castle Black"},
			{"soldiers", "100"},
			{"wealth", "0"},
			{"owner", "Starks"},
			{"general", ""},
			{"type", "castle"},
            {"max_soldiers", "20000" },
            {"max_wealth", "20000" },
        };
		castles.Add (castle_black);

		Dictionary<string, string> winterfell = new Dictionary<string, string>{
			{"name", "Winterfell"},
			{"soldiers", "2000"},
			{"wealth", "1000"},
			{"owner", "Starks"},
			{"general", ""},
			{"type", "castle"},
            {"max_soldiers", "20000" },
            {"max_wealth", "20000" },
        };
		castles.Add (winterfell);

		Dictionary<string, string> eyrie = new Dictionary<string, string>{
			{"name", "The Eyrie"},
			{"soldiers", "1000"},
			{"wealth", "250"},
			{"owner", "?"},
			{"general", ""},
			{"type", "castle"},
            {"max_soldiers", "20000" },
            {"max_wealth", "20000" },
        };
		castles.Add (eyrie);

		Dictionary<string, string> harenhal = new Dictionary<string, string>{
			{"name", "Harenhal"},
			{"soldiers", "1000"},
			{"wealth", "250"},
			{"owner", "Lannister"},
			{"general", ""},
			{"type", "castle"},
            {"max_soldiers", "20000" },
            {"max_wealth", "20000" },
        };
		castles.Add (harenhal);

		Dictionary<string, string> dragonstone = new Dictionary<string, string>{
			{"name", "Dragonstone"},
			{"soldiers", "1000"},
			{"wealth", "250"},
			{"owner", "The Vale"},
			{"general", ""},
			{"type", "castle"},
            {"max_soldiers", "20000" },
            {"max_wealth", "20000" },
        };
		castles.Add (dragonstone);

		Dictionary<string, string> storms_end = new Dictionary<string, string>{
			{"name", "Storm's End"},
			{"soldiers", "1000"},
			{"wealth", "250"},
			{"owner", "?"},
			{"general", ""},
			{"type", "castle"},
            {"max_soldiers", "20000" },
            {"max_wealth", "20000" },
        };
		castles.Add (storms_end);

		Dictionary<string, string> kings_landing = new Dictionary<string, string>{
			{"name", "King's Landing"},
			{"soldiers", "5000"},
			{"wealth", "10000"},
			{"owner", "Lanisters"},
			{"general", ""},
			{"type", "castle"},
            {"max_soldiers", "20000" },
            {"max_wealth", "20000" },
        };
		castles.Add (kings_landing);

		Dictionary<string, string> sunspear = new Dictionary<string, string>{
			{"name", "Sunspear"},
			{"soldiers", "5000"},
			{"wealth", "10000"},
			{"owner", "Tyrell"},
			{"general", ""},
			{"type", "castle"},
            {"max_soldiers", "20000" },
            {"max_wealth", "20000" },
        };
		castles.Add (sunspear);


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

		Dictionary<string, string> tavern = new Dictionary<string, string>{
			{"name", "tavern"},
			{"change", "neutral"},
			{"events", ""},
			{"type", "tavern"}
		};

		Dictionary<string, string> hospital = new Dictionary<string, string>{
			{"name", "hospital"},
			{"change", "positive"},
			{"events", ""},
			{"type", "hospital"}
		};


		//mill and stables, maybe some houses
		Dictionary<string, string> town = new Dictionary<string, string>{
			{"name", "town"},
			{"change", "positive"},
			{"events", "roll again"},
			{"type", "town"}
		};

		Dictionary<string, string> bank = new Dictionary<string, string>{
			{"name", "bank"},
			{"change", "neutral"},
			{"events", ""},
			{"type", "bank"}
		};

		Dictionary<string, string> citadel = new Dictionary<string, string>{
			{"name", "general"},
			{"change", "positive"},
			{"events", ""},
			{"type", "citadel"}
		};

		Dictionary<string, string> soldier_camp = new Dictionary<string, string>{
			{"name", "soldiers"},
			{"change", "positive"},
			{"events", ""},
			{"type", "soldier_camp"}
		};

		Dictionary<string, string> mystery_positive_wealth = new Dictionary<string, string>{
			{"name", "wealth"},
			{"change", "positive"},
			{"events", "Your men find ancient ruins filled with wealth!"},
			{"type", "mystery"}
		};

		Dictionary<string, string> mystery_negative_generals = new Dictionary<string, string>{
			{"name", "generals"},
			{"change", "negative"},
			{"events", "One of your generals overdoses on seed of the poppy and dies!"},
			{"type", "mystery"}
		};

		Dictionary<string, string> blacksmith = new Dictionary<string, string>{
			{"name", "weapon"},
			{"change", "positive"},
			{"events", ""},
			{"type", "blacksmith"}
		};

		Dictionary<string, string> random = new Dictionary<string, string>{
			{"name", "random"},
			{"change", "random"},
			{"events", ""},
			{"type", "random"}
		};

        random_events.Add(lose_soldiers);
        random_events.Add(gain_soldiers);
        random_events.Add(lose_wealth);
        random_events.Add(gain_wealth);
        random_events.Add(mystery_positive_wealth);
        random_events.Add(mystery_negative_generals);

        gameData.Add(random);
		gameData.Add(random);
		gameData.Add(high_garden);
		gameData.Add(high_garden);
		for (var i = 0; i < 9; i++) {
			gameData.Add(random);
		}
		gameData.Add(casterly_rock);
		gameData.Add(casterly_rock);
		gameData.Add(random);
		gameData.Add(random);
		gameData.Add(random);
		gameData.Add(town);
		for (var i = 0; i < 4; i++) {
			gameData.Add(random);
		}
		gameData.Add(riverrun);
		gameData.Add(random);
		gameData.Add(riverrun);
		gameData.Add(riverrun);
		gameData.Add(iron_islands);
		gameData.Add(random);
		gameData.Add(random);
		gameData.Add(random);
		gameData.Add(tavern);
		gameData.Add(random);
		gameData.Add(the_twins);
		gameData.Add(random);
		gameData.Add(the_twins);
		for (var i = 0; i < 7; i++) {
			gameData.Add(random);
		}
		gameData.Add(tavern);
		gameData.Add(random);
		gameData.Add(tavern);
		for (var i = 0; i < 6; i++) {
			gameData.Add(random);
		}
		gameData.Add(dreadfort);
		gameData.Add(random);
		gameData.Add(dreadfort);
		gameData.Add(random);
		gameData.Add(random);
		gameData.Add(random);
		gameData.Add(random);
		gameData.Add(random);
		gameData.Add(castle_black);
		gameData.Add(castle_black);
		gameData.Add(castle_black);
		gameData.Add(random);
		gameData.Add(random);
		gameData.Add(winterfell);
		gameData.Add(winterfell);
		gameData.Add(random);
		gameData.Add(winterfell);
		gameData.Add(winterfell);
		gameData.Add(random);
		gameData.Add(winterfell);
		for (var i = 0; i < 7; i++) {
			gameData.Add(random);
		}
		gameData.Add(town);
		gameData.Add(random);
		gameData.Add(random);
		gameData.Add(random);
		gameData.Add(random);
		gameData.Add(tavern);
		gameData.Add(random);
		gameData.Add(random);
		gameData.Add(the_twins);
		gameData.Add(random);
		gameData.Add(the_twins);
		gameData.Add(random);
		gameData.Add(random);
		gameData.Add(eyrie);
		gameData.Add(random);
		gameData.Add(town);
		gameData.Add(random);
		gameData.Add(harenhal);
		gameData.Add(random);
		gameData.Add(harenhal);
		gameData.Add(random);
		gameData.Add(random);
		gameData.Add(kings_landing);
		gameData.Add(dragonstone);
		gameData.Add(kings_landing);
		gameData.Add(kings_landing);
		gameData.Add(kings_landing);
		gameData.Add(storms_end);
		gameData.Add(kings_landing);
		gameData.Add(random);
		gameData.Add(town);
		gameData.Add(random);
		gameData.Add(town);
		gameData.Add(tavern);
		gameData.Add(random);
		gameData.Add(town);
		gameData.Add(random);
		gameData.Add(town);
		gameData.Add(sunspear);

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

	public string getCastleAttribute(string name, string attribute) {
		for (var i = 0; i < castles.Count; i++) {
			if (castles [i] ["name"] == name) {
				return castles [i] [attribute];
			}
		}
		return null;
	}

	public bool setCastleNumericAttribute (string name, string attribute, int number) {
		for (var i = 0; i < castles.Count; i++) {
			if (castles [i] ["name"] == name) {
				castles [i] [attribute] = (float.Parse (castles [i] [attribute]) + number).ToString ();
				return true;
			}
		}
		return false;
	}

	public bool setCastleAttribute(string name, string attribute, string value) {
		for (var i = 0; i < castles.Count; i++) {
			if (castles [i] ["name"] == name) {
				castles [i] [attribute] = value;
				return true;
			}
		}
		return false;
	}
    
	public Dictionary<string, string> getRandomEvent() {
		return random_events[UnityEngine.Random.Range (0, random_events.Count)];
	}
}
