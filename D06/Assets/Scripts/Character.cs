using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Character : MonoBehaviour {
	public float speed = 15.0F;
	public float jumpSpeed = 20.0F;
	public float gravity = 10.0F;
	private Vector3 moveDirection = Vector3.zero;
	float 	yRotation = 0, xRotation = 0, lookSensitivity = 5f;
	public GameObject		cam;
	public int				stealth;
	public bool				lighted;
	public bool				spotted;
	public bool				smoked;
	public AudioSource		aMusic;
	public AudioSource		aPanic;
	public AudioSource		aAlarm;
	public AudioSource		aPickup;
	public AudioSource		aWalk;
	public AudioSource		aEnd;
	public AudioSource		aDoor;
	public bool				key = false;
	public GameObject		door;
	private bool			ending = false;
	public GameObject		text;
	private	TextFade		fade;

	// Use this for initialization
	void Start () {
		fade = text.GetComponent<TextFade> ();
		fade.helpText ("Recuperez les plans de l'arme secrete au fond de la base");
	}
	
	// Update is called once per frame
	void Update () {
		CharacterController controller = GetComponent<CharacterController>();
		if (controller.isGrounded) {
			if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
			{
				if (!aWalk.isPlaying)
					aWalk.Play();
			}
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;
			
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
		yRotation += Input.GetAxis ("Mouse X") * lookSensitivity;
//		xRotation += Input.GetAxis ("Mouse Y") * lookSensitivity;
		transform.rotation = Quaternion.Euler (0, yRotation, 0);
		if (lighted)
			stealth += 10;
			else {
			if (stealth > 0)
				stealth -= 2;
		}
		if (spotted) {
			if (smoked)
				stealth += 5;
			else
				stealth += 20;
		}
		if (stealth >= 1000)
			Application.LoadLevel (Application.loadedLevel);
		if (stealth > 700 && !aAlarm.isPlaying) {
			if (aMusic.isPlaying)
			{
				aMusic.Stop();
				aPanic.Play();
			}
			aAlarm.Play ();
		}
		else if (stealth < 700 && aAlarm.isPlaying)
			aAlarm.Stop ();
	}

	void OnTriggerEnter(Collider coll)
	{
		if (coll.tag == "light")
			fade.helpText ("Attention, la lumiere vous revele");
		if (coll.tag == "security")
			fade.helpText ("Attention, une camera de securite vous repere");
		if (coll.tag == "key")
			fade.helpText ("Vous avez recuperez la cle de la porte blindee");
		if (coll.tag == "console")
			fade.helpText ("Appuyez sur E pour ouvrir la porte");
		if (coll.tag == "end")
			fade.helpText ("Appuyez sur E pour photographier les plans");
	}

	void OnTriggerStay(Collider coll)
	{
		if (coll.tag == "light") {
			lighted = true;
		}
		if (coll.tag == "smoke") {
			smoked = true;
		}
		if (coll.tag == "security") {
			spotted = true;
		}
		if (coll.tag == "key") {
			key = true;
			aPickup.Play();
			GameObject.Destroy(coll.gameObject);
		}
		if (coll.tag == "console") {
			if (Input.GetKeyDown(KeyCode.E) && key)
			{
				key = false;
				aDoor.Play();
				door.GetComponent<Animator>().SetTrigger("door");
				fade.helpText ("Recuperez les plans au fond du coffre!");
			}
			else if (Input.GetKeyDown(KeyCode.E))
				fade.helpText ("Il vous manque la cle de la porte");
		}
		if (coll.tag == "end") {
			if (Input.GetKeyDown(KeyCode.E) && !ending)
			{
				aEnd.Play();
				ending = true;
				if (aMusic.isPlaying)
					aMusic.Stop();
				if (aPanic.isPlaying)
					aPanic.Stop();
				StartCoroutine(end());
			}
		}
	}

	IEnumerator	end()
	{
		for (int i = 0; i < 5 ; i++) {
			yield return new WaitForSeconds(1);
		}
		Application.LoadLevel (Application.loadedLevel);
	}

	void OnTriggerExit(Collider coll)
	{
		if (coll.tag == "light") {
			text.GetComponent<Text>().text = "";
			lighted = false;
		}
		if (coll.tag == "smoke")
			smoked = false;
		if (coll.tag == "security") {
			text.GetComponent<Text>().text = "";
			spotted = false;
		}
	}



}
