using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneOnClick : MonoBehaviour {

//	public float fadeSpeed = 0.8f;
//	public Color loadToColor = Color.black;
//	public Texture2D fadeOutTexture;

//	public Image black;
//	public Animator anim;
	public int scene;

//	private int drawDepth = -1000;
//	private float alpha = 1.0f;
//	private int fadeDirection = -1;

//	void OnEnable() {
//		SceneManager.sceneLoaded += OnSceneLoaded;
//	}
//
//	void OnDisable() {
//		SceneManager.sceneLoaded -= OnSceneLoaded;
//	}
//
//	private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
//		BeginFade (-1);
//	}

//	void Awake(){
//		BeginFade (-1);
//	}

//	void onGUI(){
//		// fade out/in the alpha value using a direction, speed, and Time.deltatime to calculate seconds
//		alpha += fadeDirection * fadeSpeed * Time.deltaTime;
//
//		// make alpha a value between 0 and 1 bc that's what GUI.color uses.
//		alpha = Mathf.Clamp01 (alpha);
//
//		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
//		GUI.depth = drawDepth;
//		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeOutTexture); //draw texture to fit screen area
//
//	}
		
//	IEnumerator FadeAnim(){
//		anim.SetBool ("Fade", true);
//		yield return new WaitUntil (() => black.color.a == 1);
//		SceneManager.LoadScene (scene);
//	}
//	public float BeginFade (int direction) {
//		fadeDirection = direction;
//		return fadeSpeed;
//	}
		
	public void LoadScene(){
		SceneManager.LoadScene (scene);
//		StartCoroutine (FadeAnim ());
	}
}
