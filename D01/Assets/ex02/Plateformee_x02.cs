using UnityEngine;
using System.Collections;

public class Plateformee_x02 : MonoBehaviour {

	public	string	color;

	// Use this for initialization
	void Start () {
		Physics2D.IgnoreLayerCollision(8, 12 );
		Physics2D.IgnoreLayerCollision(8, 13 );
		Physics2D.IgnoreLayerCollision(9, 11 );
		Physics2D.IgnoreLayerCollision(9, 13 );
		Physics2D.IgnoreLayerCollision(10, 11 );
		Physics2D.IgnoreLayerCollision(10, 12 );

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
}
