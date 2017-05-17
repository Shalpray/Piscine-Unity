using UnityEngine;
using System.Collections;

public class enemyScript : MonoBehaviour {

	public float			speed;
	public float			shootRange;
	public float			moveRange;

	public AudioClip		soundDie;

	private weaponScript 	weapon;
	private PatrolScript	patrol;

	void Start () {
		weapon = GetComponent<weaponScript> ();
		patrol = GetComponent<PatrolScript> ();
	}

	private void updateDirection(Vector3 dir) {
		float angle;

		angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		angle += 90.0f;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}

	private void move(Vector3 dir) {
		transform.Translate (dir * speed * Time.deltaTime, Space.World);
	}

	// Update is called once per frame
	void Update () {
		Vector3		dir;
		RaycastHit2D[] hits;

		dir = player.p.transform.position - transform.position;
		dir.Normalize ();
		hits = Physics2D.RaycastAll (transform.position, dir);
		foreach (RaycastHit2D hit in hits)
		{
			if (hit && hit.collider.tag == "Enemy") {
				continue ;
			}
			if (hit && hit.collider.tag == "Wall") {
				doPatrol () ;
				break ;
			}
			if (hit && hit.collider.tag == "Player") {
				updateDirection(dir);
				if (hit.distance < shootRange)
					weapon.shoot (dir, "Enemy");
				if (hit.distance > moveRange)
					move (dir);
				break ;
			}
		}
	}

	public void doPatrol()
	{
		if (patrol == null)
			return;
		patrol.doPatrol ();
	}
	public void die () {
		soundManager.sm.playSound(soundDie);
		victoryScript.enemyCount--;
		Destroy (gameObject);
	}
}
