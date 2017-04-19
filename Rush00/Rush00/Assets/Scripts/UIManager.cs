using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

	public GameObject  Ammo;
	public GameObject  menuPause;
	public GameObject  menuVictory;
	public GameObject  menuGameover;

	static public UIManager	um;

	// Use this for initialization
	void Start () {
		if (um == null)
			um = this;
	}
	
	public void resumeGame() {
		Time.timeScale = 1.0f;
		Ammo.SetActive (true);
		menuPause.SetActive (false);
		menuVictory.SetActive (false);
		menuGameover.SetActive (false);
	}

	public void pauseGame() {
		Time.timeScale = 0.0f;
		Ammo.SetActive (false);
		menuPause.SetActive (true);
		menuVictory.SetActive (false);
		menuGameover.SetActive (false);
	}
	
	public void winGame() {
		soundManager.sm.playWin ();
		Time.timeScale = 0.0f;
		Ammo.SetActive (false);
		menuPause.SetActive (false);
		menuVictory.SetActive (true);
		menuGameover.SetActive (false);
	}

	public void lostGame() {
		soundManager.sm.playGameover ();
		Time.timeScale = 0.0f;
		Ammo.SetActive (false);
		menuPause.SetActive (false);
		menuVictory.SetActive (false);
		menuGameover.SetActive (true);
	}

	void Update () {
		if (Input.GetKey(KeyCode.Escape))
			pauseGame();
	}
}
