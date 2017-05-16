using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public bool move ;
	public float jauge;


	// Use this for initialization
	void Start () {
		move = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (move == true)
		{
			transform.Translate (new Vector3 (0f, 0.01f * jauge, 0f));
			//jauge = jauge * 0.95f;
			if (jauge < 0)
				jauge += 0.5f;
			else if (jauge > 0)  
				jauge -= 0.5f;
			if (jauge < 0.1f && jauge > -0.1f)
				move = false;
			if (transform.position.y > 10.48f || transform.position.y < -7f)
				jauge = jauge * -1;
			if ((transform.position.y > 8.60 && transform.position.y < 9) && (jauge < 5 && jauge > -5))
				transform.position = (new Vector3 (5000f, 0f , 0f));
		}
	}
}
