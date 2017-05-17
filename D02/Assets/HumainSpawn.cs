using UnityEngine;
using System.Collections;

public class HumainSpawn : MonoBehaviour {

	public GameObject	humain;
	public float		spawnTime;
	
	private float		timer;
	private GameObject	go;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (timer >= spawnTime) 
		{
			timer = 0;
			go = GameObject.Instantiate(humain, humain.transform.position, Quaternion.identity) as GameObject;
			go.tag = "Humain";


		}
		timer += Time.deltaTime;
	}
}
