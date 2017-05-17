using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class player : MonoBehaviour {

	public float 			moveSpeed;

	public Vector3 			playerPos;
	public Vector3 			mousePos;
	
	public GameObject 		weapon;
	public SpriteRenderer	weaponSprite;

	public Vector3 			dir;
	public float 			angle;
	private Animator 		anim;

	public AudioClip		soundDie;

	/* Static reference */
	public static player	p;

	void Start () {
		anim = GetComponent<Animator>();
		moveSpeed = 8.0f;
		if (p == null) {
			p = this;
		}
	}

	public void		die (){
		soundManager.sm.playSound(GetComponent<AudioSource>(), soundDie);
		UIManager.um.lostGame ();
	}

	private void getMoveInput(){
		if (!Input.anyKey) {
			anim.SetBool("move", false);
		}
		if (Input.GetKey ("s")) {
			anim.SetBool ("move", true);
			transform.position += Vector3.down * moveSpeed * Time.deltaTime;
			
		}
		if (Input.GetKey ("w")) {
			anim.SetBool ("move", true);
			transform.position += Vector3.up * moveSpeed * Time.deltaTime;
			
		}
		if (Input.GetKey ("d")) {
			anim.SetBool ("move", true);
			transform.position += Vector3.right * moveSpeed * Time.deltaTime;
			
		}
		if (Input.GetKey ("a")) {
			anim.SetBool ("move", true);
			transform.position += Vector3.left * moveSpeed * Time.deltaTime;
		}
	}

	private void updateDirection(){
		mousePos = Input.mousePosition;
		dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
		dir.Normalize ();
		angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		angle += 90f;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}

	void Update () {
		updateDirection ();
		getMoveInput ();
		if (Input.GetKeyDown (KeyCode.Mouse0) && weapon)
			weapon.GetComponent<weaponScript> ().shoot (dir, "Player");
		if (Input.GetKeyDown (KeyCode.Mouse1) && weapon)
			weapon.GetComponent<weaponScript> ().drop ();

	}
	
	void OnTriggerStay2D(Collider2D col){
		if (Input.GetKeyDown ("e") && col.tag == "weapon" && weapon == null) {
			col.gameObject.GetComponent<weaponScript>().equip();
		}
	}
}