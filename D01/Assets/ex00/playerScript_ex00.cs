﻿using UnityEngine;
using System.Collections;

public class playerScript_ex00 : MonoBehaviour {

	public bool active;
	public float speed;
	
	bool	jumping = true;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			if (gameObject.name == "red")
				active = true;
			else
				active = false;
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)){
			if (gameObject.name == "yellow")
				active = true;
			else
				active = false;
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)){
			if (gameObject.name == "blue")
				active = true;
			else
				active = false;
		}
		if (!active) {
			GetComponent<Rigidbody2D>().mass = 500f;
			GetComponent<Rigidbody2D> ().velocity = (new Vector2 (0, GetComponent<Rigidbody2D> ().velocity.y));
		}
		else {
			GetComponent<Rigidbody2D>().mass = 1f;
			if (Input.GetKey (KeyCode.RightArrow))
				GetComponent<Rigidbody2D>().velocity = (new Vector2 (speed, GetComponent<Rigidbody2D>().velocity.y));
			else if (Input.GetKey (KeyCode.LeftArrow))
				GetComponent<Rigidbody2D>().velocity = (new Vector2 (-speed, GetComponent<Rigidbody2D>().velocity.y));
			else 
				GetComponent<Rigidbody2D>().velocity = (new Vector2 (0, GetComponent<Rigidbody2D>().velocity.y));
			if (Input.GetKeyDown (KeyCode.Space) && !jumping)
			{
				GetComponent<Rigidbody2D>().AddForce(new Vector2 (0, 500f ));
				jumping = true;
			}
		}
	}
	
	void OnCollisionEnter2D( Collision2D collision)
	{
		if(collision.contacts.Length > 0)
		{
			ContactPoint2D contact = collision.contacts[0];
			if(Vector3.Dot(contact.normal, Vector3.up) > 0.5)
			{
				jumping = false;
			}
		}
	}
}
