using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject	Prefab;
	public GameObject	Prefab2;
	public GameObject	current;
	bool				cd = false; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!current && !cd)
			StartCoroutine(spawn());
	}

	IEnumerator spawn()
	{
		cd = true;
		yield return new WaitForSeconds(1);
		if (Random.Range(0, 2) == 0)
			current = (GameObject)Instantiate(Prefab2, transform.position, Quaternion.identity);
		else
			current = (GameObject)Instantiate(Prefab, transform.position, Quaternion.identity);
		cd = false;
	}
}
