using UnityEngine;
using System.Collections;

public class victoryScript : MonoBehaviour {

	public static int enemyCount;
	// Use this for initialization
	void Start () {
		GameObject[] list;
	
		list = GameObject.FindGameObjectsWithTag("Enemy");
		enemyCount = list.Length;
		Time.timeScale = 1.0f;
	}

	void Update () {
		if (enemyCount > 0)
			return;
		UIManager.um.winGame ();	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
			UIManager.um.winGame ();
	}
}
