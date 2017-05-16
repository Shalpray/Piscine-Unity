using UnityEngine;
using System.Collections;

public class Balloon : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	public int jauge = 0;

	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown ("space")) {
			jauge++;
			if (jauge < 5)
				transform.localScale = new Vector3 (transform.localScale [0] + 0.2f, transform.localScale [1] + 0.2f, transform.localScale [2] + 0.2f);		
		}
		if ((Mathf.RoundToInt(10.0f * Time.realtimeSinceStartup) % 8) == 0)
		{
			if (jauge > 0) 
				jauge--;
		}
		if ((Mathf.RoundToInt(10.0f * Time.realtimeSinceStartup) % 2) == 0)
		{
			transform.localScale = new Vector3 (transform.localScale [0] - 0.01f, transform.localScale [1] - 0.01f, transform.localScale [2] - 0.01f);
		}
		
		
		if (transform.localScale[0] > 5 || transform.localScale [1] > 5 || transform.localScale [2] > 5 || transform.localScale[0] < 0 || transform.localScale [1] < 0 || transform.localScale [2] < 0)
		{
			GameObject.Destroy(this);
			Debug.Log ("Balloon life time: ");
			Debug.Log (Mathf.RoundToInt(Time.realtimeSinceStartup));
			Debug.Log ("s");
		}
		
	}	
}