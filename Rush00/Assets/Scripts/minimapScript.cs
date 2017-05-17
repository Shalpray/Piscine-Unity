using UnityEngine;
using System.Collections;

public class minimapScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space))
			GetComponent<Camera> ().enabled = true;
		if (Input.GetKeyUp (KeyCode.Space))
			GetComponent<Camera> ().enabled = false;
	}
}
