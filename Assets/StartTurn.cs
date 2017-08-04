using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StartTurn : MonoBehaviour {

	public GUIController Controller;
	public Button button;

	void Start()
	{
		Button btn = button.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		Debug.Log("Turn has started!");
		Controller.startTurn ();
	}
}
