using UnityEngine;
using System.Collections;

public class sceneswitcher : MonoBehaviour {

	public int i;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R))
			Application.LoadLevel ("ex0" + i);
	}
}
