using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Initialize : MonoBehaviour {


	public GameObject Game;
	public Button button;
	public GameObject MainMenu;



	void Start()
	{
		Button btn = button.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		Game.SetActive (true);
		MainMenu.SetActive (false);
		Camera.main.transform.position = new Vector3 (4.35f, 0.75f, -20f);
		Camera.main.transform.rotation = Quaternion.Euler (-10, 0, 0);
//		Camera.main.transform.position.x = 4.35;
//		Camera.main.transform.position.y = 0.75;
//		Camera.main.transform.position.z = -20;
//		Camera.main.transform.rotation = Quaternion.Euler (-10, 0, 0);
	}
}
