using UnityEngine;
using System.Collections;

public class nawer : MonoBehaviour {

	public Ray ray;
	public float angle;
	public string current = "Nothing";
	// Use this for initialization
	void Start () {
		//GetComponent<Animator> ().SetTrigger ("Nothing");
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown("Fire1")) {
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			angle = Mathf.Atan((ray.origin.y - transform.position.y) / (ray.origin.x - transform.position.x));
			if (ray.origin.x - transform.position.x < 0 && ray.origin.y - transform.position.y > 0)
				angle =  3.14f + angle;
			if (ray.origin.x - transform.position.x < 0 && ray.origin.y - transform.position.y < 0)
				angle =  - 3.14f + angle;
			angle = angle * 180.0f / 3.14f;
			AudioSource audio = GetComponent<AudioSource>();
			audio.Play();
		}

		if (ray.origin != transform.position) {
			if (angle >= 67.5f && angle <= 112.5f && current != "Up") {
				GetComponent<Animator> ().SetTrigger ("Up");
				current = "Up";
			} else if (angle >= 22.5f && angle <= 67.5f && current != "UpRight") {
				GetComponent<Animator> ().SetTrigger ("test");
				current = "UpRight";
			} else if (angle >= -22.5f && angle <= 22.5f && current != "Right") {
				GetComponent<Animator> ().SetTrigger ("Right");
				current = "Right";
			} else if (angle <= -22.5f && angle >= -67.5f && current != "DownRight") {
				GetComponent<Animator> ().SetTrigger ("DownRight");
				current = "DownRight";
			} else if (angle >= -112.5f && angle <= -67.5f && current != "Down") {
				GetComponent<Animator> ().SetTrigger ("Down");
				current = "Down";
			} else if (angle <= -112.5f && angle >= -157.5f && current != "DownLeft") {
				GetComponent<Animator> ().SetTrigger ("DownLeft");
				current = "DownLeft";
			} else if (((angle <= -157.5f && angle >= -180) || (angle <= 180 && angle >= 157.5f)) && current != "Left") {
				GetComponent<Animator> ().SetTrigger ("Left");
				current = "Left";
			} else if (angle <= 157.5f && angle >= 112.5f && current != "UpLeft") {
				GetComponent<Animator> ().SetTrigger ("UpLeft");
				current = "UpLeft";
			}

		} else if (current != "Nothing")
		{
			GetComponent<Animator> ().SetTrigger ("Nothing");
			current = "Nothing";
		}


		transform.position = Vector3.MoveTowards(transform.position, ray.origin , 3 * Time.deltaTime);
	}
}
