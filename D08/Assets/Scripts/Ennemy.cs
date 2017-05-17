using UnityEngine;
using System.Collections;

public class Ennemy : MonoBehaviour {

	private GameObject	player;
	public NavMeshAgent	nav;
	public Animator		anim;
	int					state = 0;
	public int 				health = 3;
	// Use this for initialization
	void Start () {
		player = GameManager.instance.player;
	}
	
	// Update is called once per frame
	void Update () {
		if (health == 0){
			if (state != 3)
			{
				anim.SetTrigger("death");
				GetComponent<BoxCollider>().enabled = false;
				nav.enabled = false;
				StartCoroutine(fall ());
			}
			state = 3;

		}
		else 
		{
		RaycastHit hit;

		if (Physics.Raycast(transform.position, (player.transform.position - transform.position), out hit, 15f))
		{
			if (hit.collider.tag == "Player")
			{
				nav.destination = player.transform.position;
				if ( Vector3.Distance(transform.position , player.transform.position) < 1.5f)
				{
					if (state != 2)
					{
						state = 2;
						anim.SetTrigger("attack");
					}
				}
				else if (state != 1)
				{
					anim.SetTrigger("run");
					state = 1;
				}
			}
			else
			{
				anim.SetTrigger("idle");
				state = 0;
			}

		}
		else
		{
			nav.destination = transform.position;
			anim.SetTrigger("idle");
			state = 0;
		}
		}
	}


	IEnumerator fall()
	{
		yield return new WaitForSeconds(2);
		for (int i = 0; i < 20; i++)
		{
			Vector3 temp = transform.position;
			temp.y -= 0.05f;
			transform.position = temp;
			yield return new WaitForSeconds(0.25f);
		}
		Destroy(gameObject);
	}

}
