using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class HumainManager : MonoBehaviour {

	public List<Humain> humains = new List<Humain>();
	public Ray ray;
	public RaycastHit hit;
	public Vector2 mousePosition;
	public Collider2D hitCollider;

	bool active_flag = false;

	private void resetHumain()
	{
		foreach (Humain humain in humains)
			humain.active = false;
	}

	private void moveHumain()
	{
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		AudioSource audio = GetComponent<AudioSource>();
		foreach (Humain humain in humains)
		{
			if (humain.active)
			{
				humain.ray = ray;
				active_flag = true;
			}
		}
		if (active_flag)
		{
			audio.Play();
			active_flag = false;
		}
	}
	
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonUp ("Fire2")) {
			resetHumain();
		}
		if (Input.GetButtonUp("Fire1") == true && Input.GetKey(KeyCode.LeftControl) == true) {
			mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			hitCollider = Physics2D.OverlapPoint(mousePosition);
			if (hitCollider)
				hitCollider.transform.GetComponent<Humain>().active = true;
			else
				moveHumain();
		}
		else if (Input.GetButtonDown("Fire1") == true && Input.GetKey(KeyCode.LeftControl) == false)
		{
			mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			hitCollider = Physics2D.OverlapPoint(mousePosition);
			if (hitCollider)
			{
				resetHumain();
				hitCollider.transform.GetComponent<Humain>().active = true;
			}
			else
				moveHumain();
		}
	}
}		