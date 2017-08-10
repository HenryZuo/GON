using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistOnSceneChange : MonoBehaviour {

	void Awake() {
		DontDestroyOnLoad (this);
	}
}
