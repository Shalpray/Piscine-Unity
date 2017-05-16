using UnityEngine;
using System.Collections;

public class CubeSpawner : MonoBehaviour {


	public GameObject 	prefab;
	public float 		spawnTime;
	private GameObject	tt;
	int i;
	
	// Update is called once per frame
	void Update () {
		i = Random.Range(0, 50);
		if (tt && tt.transform.position.y < -7)
			GameObject.Destroy(tt);
		if (!tt && i == 5 && prefab)
			tt = (GameObject)GameObject.Instantiate(prefab, prefab.transform.position, Quaternion.identity);
		if (tt && Input.GetKeyDown ("a") && prefab.name == "A") 
		{
			Debug.Log ("Precision: "+(tt.transform.position.y + 5));
			GameObject.Destroy(tt);
		}
		if (tt && Input.GetKeyDown ("s") && prefab.name == "S") 
		{
			Debug.Log ("Precision: "+(tt.transform.position.y + 5));
			GameObject.Destroy(tt);
		}
		if (tt && Input.GetKeyDown ("d") && prefab.name == "D") 
		{
			Debug.Log ("Precision: "+(tt.transform.position.y + 5));
			GameObject.Destroy(tt);
		}
	}
}
