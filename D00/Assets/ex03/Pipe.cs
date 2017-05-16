using UnityEngine;
using System.Collections;

public class Pipe : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (-0.1f, 0f, 0f));
		if (transform.position.x < -10.41)
			transform.position = new Vector3 (9.81f, transform.position.y, transform.position.z);
	}
}
