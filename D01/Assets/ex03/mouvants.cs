using UnityEngine;
using System.Collections;

public class mouvants : MonoBehaviour {

	public	float	x = 0;
	public	float	y = 0;
	public	float	timer = 0;

	float			time = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (time < timer) {
			transform.Translate (new Vector3 (x, y, 0));  
			time += Time.deltaTime;
		}
		else
		{
			x = -x;
			y = -y;
			time = 0; 
		}
	}

	void OnCollisionStay2D( Collision2D collision)
	{
		Transform t = collision.gameObject.GetComponent<Transform> ();
		
		t.Translate (new Vector3 (x, y, 0));  
	}

}
