using UnityEngine;
using System.Collections;

public class teleportIN : MonoBehaviour {

	public GameObject	exit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void	OnTriggerEnter2D(Collider2D collider)
	{
		collider.transform.position = exit.transform.position;
	}
}
