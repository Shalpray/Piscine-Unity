using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour {

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (player.p.transform.position.x, player.p.transform.position.y, -10f);
	}
}
