using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddRemovePlayer : MonoBehaviour {
	public GUIController Controller;
	public Button plusButton;
	public Unit Unit;

	void Start()
	{ 
		Button btn = plusButton.GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnClick);
	}

	void TaskOnClick(){
		Instantiate (Unit);
	}
}
