using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadFromOtherScenes : MonoBehaviour {

	private GameObject data;
	private Data gameData;

	void Awake(){
		data = GameObject.Find ("DataObj");
		gameData = data.GetComponent<Data>();
		// Debug.Log(gameData.players);
//		foreach(KeyValuePair<string,string> players in gameData.players)
//		{
//			//Now you can access the key and value both separately from this attachStat as:
//			Debug.Log(players.Key);
//			Debug.Log(players.Value);
//		}

	}
}
