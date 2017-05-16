using UnityEngine;
using System.Collections;

public class WinCondition03 : MonoBehaviour {

	public GameObject 	red;
	public GameObject	yellow;
	public GameObject	blue;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (red.GetComponent<playerScript_ex01> ().win && yellow.GetComponent<playerScript_ex01> ().win && blue.GetComponent<playerScript_ex01> ().win)
			Debug.Log ("The end!");
	}
}
