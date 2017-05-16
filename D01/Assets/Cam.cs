using UnityEngine;
using System.Collections;

public class Cam : MonoBehaviour {

	public GameObject 	red;
	public GameObject	yellow;
	public GameObject	blue;
	
	GameObject	current;
	
	// Use this for initialization
	void Start () {
		current = red;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1))
			current = red;
		if (Input.GetKeyDown (KeyCode.Alpha2))
			current = yellow;
		if (Input.GetKeyDown (KeyCode.Alpha3))
			current = blue;
		Transform t;
		t = current.GetComponent<Transform> (); 
		transform.localPosition = new Vector3 (t.position.x, t.position.y, -9.997596f);
	}
}
