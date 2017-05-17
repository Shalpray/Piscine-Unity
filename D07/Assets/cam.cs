using UnityEngine;
using System.Collections;

public class cam : MonoBehaviour {

	float xRotation;
	public float move_speed;
	public GameObject canon;
	public GameObject particule_bullet;
	public GameObject particule_rocket;
	public SpriteRenderer curseur;
	private RaycastHit rayHit;
	public float nb_roquettes = 8;
	float jauge_boost = 100;
	float time_boost = 100;
	public float life = 100;



	IEnumerator Curseur() {
		curseur.color = Color.red;
		yield return new WaitForSeconds(0.5f);
		curseur.color = Color.white;
	}
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (life <=0)
			Application.LoadLevel(0);
		AudioSource[] tab = canon.GetComponents<AudioSource>();
		Vector3 fwd = canon.transform.forward;
		canon.transform.localEulerAngles = new Vector3(0, canon.transform.localEulerAngles.x + (Input.mousePosition.x - Screen.width), 0);

		if (Physics.Raycast(canon.transform.position, fwd, out rayHit, 100))
			Debug.DrawLine(canon.transform.position, rayHit.point, Color.red);

		move_speed = 0.3f;
		if (Input.GetKey(KeyCode.LeftShift) && jauge_boost > 0)
		{
			move_speed = 0.5f;
			jauge_boost = Mathf.Clamp(jauge_boost - 1f, 0, 100);
			time_boost = 0;
		}
		else
		{
			time_boost  = Mathf.Clamp(time_boost + 0.5f, 0, 100);
			if (time_boost == 100)
				jauge_boost = Mathf.Clamp(jauge_boost + 1, 0, 100);
		}
			
		if (Input.GetKey("w"))
			GetComponent<CharacterController>().Move(transform.forward * move_speed);
		if (Input.GetKey("s"))
			transform.GetComponent<CharacterController>().Move(-transform.forward * move_speed);
		if (Input.GetKey("d") )
			transform.GetComponent<CharacterController>().transform.localEulerAngles = new Vector3(0, transform.GetComponent<CharacterController>().transform.localEulerAngles.y + 2, 0);
		if (Input.GetKey("a"))
			transform.GetComponent<CharacterController>().transform.localEulerAngles = new Vector3(0, transform.GetComponent<CharacterController>().transform.localEulerAngles.y - 2, 0);
		if (Input.GetMouseButtonDown(0)) // Left click launch bullets
		{
			tab[1].Play();
			if (Physics.Raycast(canon.transform.position, fwd, out rayHit, 75))
			{
				particule_bullet.SetActive(false);
				Debug.DrawLine(canon.transform.position, rayHit.point, Color.red);
				particule_bullet.transform.position = rayHit.point;
				particule_bullet.SetActive(true);
				if (rayHit.collider.tag == "enemy")
				{
					StartCoroutine(Curseur());
					rayHit.collider.GetComponent<enemy>().life -= 10;
				}
			}
		}
		if (Input.GetMouseButtonDown(1) && nb_roquettes >= 1) // Right click launch rockets
		{
			nb_roquettes--;
			if (Physics.Raycast(canon.transform.position, fwd, out rayHit, 100))
			{
				tab[0].Play();
				particule_rocket.SetActive(false);
				Debug.DrawLine(canon.transform.position, rayHit.point, Color.red);
				particule_rocket.transform.position = rayHit.point;
				particule_rocket.SetActive(true);
				if (rayHit.collider.tag == "enemy")
				{
					StartCoroutine(Curseur());
					rayHit.collider.GetComponent<enemy>().life -= 50;
				}
			}
			else
				tab[2].Play();
		}
		if (!GetComponent<CharacterController>().isGrounded)
			GetComponent<CharacterController>().Move(new Vector3(0, -9.81f  * Time.deltaTime * 4, 0));

		xRotation += Input.mousePosition.x - (Screen.width / 2f);
		canon.transform.localEulerAngles = new Vector3(0, xRotation / 300f, 0);
	}
}