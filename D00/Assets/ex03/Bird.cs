using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour {

	private bool Play = true;
	public GameObject pipe;
	public float speed = 0;
	public int score = 0;
	private float time;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Play) {
			time += Time.deltaTime;
			if (Input.GetKeyDown ("space"))
				transform.Translate (new Vector3 (0f, 1f, 0f));
			else 
				transform.Translate (new Vector3 (0f, -0.05f, 0f));
			pipe.transform.Translate (new Vector3 (-0.1f -speed, 0f, 0f));
			if (pipe.transform.position.x < -10.41)
			{
				score += 5;
				speed += 0.01f;
				pipe.transform.position = new Vector3 (9.81f, pipe.transform.position.y, pipe.transform.position.z);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Decor") {
			Debug.Log ("Score: "+score);
			Debug.Log ("Time: "+Mathf.RoundToInt(time)+"s");
			Play = false;
		}
	}
}
