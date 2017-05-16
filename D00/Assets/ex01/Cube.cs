using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {
	private float vitesse;

	void Start () {
		vitesse = Random.Range(-000.1f, -000.3f);
	}
	void Update () {
		transform.Translate(new Vector3(0, vitesse, 0));
	}

}
