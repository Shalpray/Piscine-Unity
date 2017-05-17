using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour {

	public float 		speed;
	public Vector3 		direction;

	public bool			isSlash;

	private float		timer;

	void Start () {
		timer = 0.0f;
	}

	void Update () {
		timer += Time.deltaTime;
		if (isSlash && timer > 0.1f) {
			Destroy (gameObject);
			return ;
		}
		transform.Translate(direction * Time.deltaTime * speed, Space.World);
	}

	public void init(Vector3 pos, Vector3 dir, string layerName){
		float angle;
	
		direction = Vector3.ProjectOnPlane (dir, Vector3.forward);
		direction.Normalize ();
		angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		gameObject.layer = LayerMask.NameToLayer(layerName);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Enemy") {
			col.gameObject.GetComponent<enemyScript> ().die ();
			Destroy (gameObject);
		}
		if (col.tag == "Player")
			col.gameObject.GetComponent<player>().die();
		if (col.tag == "Wall")
			Destroy (gameObject);
			
	}
}
