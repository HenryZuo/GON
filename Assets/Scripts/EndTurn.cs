using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndTurn : MonoBehaviour
{
	public GUIController Controller;
	public Button button;

	void Start()
	{
		Button btn = button.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		Debug.Log("You have clicked the button!");
		Controller.EndTurn();
	}
}