using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class button : MonoBehaviour {


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void load()
	{
		Application.LoadLevel(1);
	}

	public void quit()
	{
		Application.Quit();
	}
}
