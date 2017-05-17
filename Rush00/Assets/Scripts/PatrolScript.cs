using UnityEngine;
using System.Collections;

public class PatrolScript : MonoBehaviour {

	public Vector3	dir;
	public float	freq;

	private float 	speed;
	private float 	timer;
	private float 	dirFlag;

	// Use this for initialization
	void Start () {
		speed = GetComponent<enemyScript> ().speed;
		timer = 0.0f;
		dirFlag = 1.0f;
	}

	public void doPatrol(){
		transform.Translate (dir * speed * Time.deltaTime * dirFlag, Space.World);
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > freq) {
			dirFlag *= -1;
			timer = 0.0f;
		}
	}
}
