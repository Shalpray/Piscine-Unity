using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	public GameObject cam;
	private NavMeshAgent	nav;
	private Animator		anim;
	public GameObject	target;
	public bool	idle = true;
	public bool	attack = false;
	bool	cd = false;
	// Use this for initialization
	void Start () {
		nav = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		cam.transform.position = new Vector3(transform.position.x, transform.position.y + 6f, transform.position.z - 9f);

		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;

			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
			{
				if (hit.collider.tag == "enemy" && hit.collider.gameObject.GetComponent<Ennemy>().health != 0)
					target = hit.collider.gameObject;
				else
					target = null;
				anim.SetTrigger("run");
				idle = false;
				attack = false;
				nav.destination = hit.point;
			}
		}
		if (target)
		{
			if ( Vector3.Distance(transform.position , target.transform.position) < 1.5f)
			{
				if (attack && !cd)
				{
					cd = true;
					StartCoroutine(attacking ());
				}
				if (!attack)
				{
					attack = true;
					idle = false;
					anim.SetTrigger("attack");
				}
			}
			else
			{
				nav.destination = target.transform.position;
				attack = false;
			}
		}

		if (transform.position == nav.destination && !idle && !attack )
		{
			anim.SetTrigger("idle");
			idle = true;
		}
	}

	IEnumerator attacking()
	{
		yield  return new WaitForSeconds(0.7f);
		if (target)
			target.GetComponent<Ennemy>().health--;
		if (target.GetComponent<Ennemy>().health == 0)
		{
			target = null;
			attack = false;
			nav.destination = transform.position;
			anim.SetTrigger("idle");
			idle = true;
		}
		cd = false;
	}

}
