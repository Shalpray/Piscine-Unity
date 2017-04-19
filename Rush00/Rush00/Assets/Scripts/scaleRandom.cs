using UnityEngine;
using System.Collections;

public class scaleRandom : MonoBehaviour {

	public float 	deltaRange;
	public float 	deltaMax;
	
	private float	scale;
	
	void Start () {
		scale = 1.0f;
		deltaRange = Mathf.Abs (deltaRange);
		deltaMax = Mathf.Abs (deltaMax);
	}
	
	void Update () {
		Vector3 newScale;
		float 	delta;
		
		newScale = Vector3.one;
		delta = Random.Range (-deltaRange, deltaRange);
		if (Mathf.Abs (scale + delta - 1.0f) > deltaMax)
			delta *= -1;
		scale += delta;
		newScale *= scale;
		newScale.z = 1.0f;
		transform.localScale = newScale;
	}
}
