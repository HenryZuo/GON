using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyObj : MonoBehaviour {

	void Awake(){
		Debug.Log (gameObject);
		DontDestroyOnLoad (gameObject);
	}
}
