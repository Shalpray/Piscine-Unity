using UnityEngine;
using System.Collections;

public class rotateRandom : MonoBehaviour {

	public float 	deltaRange;
	public float 	deltaMax;

	private float	angle;

	void Start () {
		angle = 0.0f;
		deltaRange = Mathf.Abs (deltaRange);
		deltaMax = Mathf.Abs (deltaMax);
	}

	void Update () {
		float delta;

		delta = Random.Range (-deltaRange, deltaRange);
		if (Mathf.Abs (angle + delta) > deltaMax)
			delta *= -1;
		angle += delta;
		transform.Rotate (Vector3.forward * delta);
	}
}
