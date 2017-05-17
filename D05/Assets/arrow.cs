using UnityEngine;
using System.Collections;

public class arrow : MonoBehaviour {

	public GameObject ball;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = ball.transform.position+Vector3.right * -6f;
		transform.RotateAround(ball.transform.position, Vector3.up, 100*Time.deltaTime);
		if (Input.GetKey(KeyCode.A))
		{}
	}
}
