using UnityEngine;
using System.Collections;
using UnityEngine.Events;


public class manage_time : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void pause()
	{
		gameManager.gm.pause(true);
	}

	public void speed1()
	{
		gameManager.gm.pause(false);
		gameManager.gm.changeSpeed(1);
	}
	public void speed2()
	{
		gameManager.gm.pause(false);
		gameManager.gm.changeSpeed(2);
	}
	public void speed3()
	{
		gameManager.gm.pause(false);
		gameManager.gm.changeSpeed(4);
	}
}
