using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {

	public GameObject player;
	public GameObject other_enemy;
	public float life = 100;
	private GameObject target;
	private RaycastHit rayHit;
	public GameObject particule_bullet;
	public GameObject particule_rocket;
	public GameObject canon;
	private bool flag = true;
	private RaycastHit temp;
	private AudioSource[] tab;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		tab = canon.GetComponents<AudioSource>();
		if (this.gameObject)
		{
			Vector3 fwd = canon.transform.forward;
			if (!other_enemy)
				GetComponent<NavMeshAgent>().destination = player.transform.position;
			else
			{
				float dist_player = Vector3.Distance(transform.position, player.GetComponent<Transform>().position);
				float dist_other_enemy = Vector3.Distance(transform.position, other_enemy.GetComponent<Transform>().position);
				if (dist_player <= dist_other_enemy)
					GetComponent<NavMeshAgent>().destination = player.transform.position;
				else
					GetComponent<NavMeshAgent>().destination = other_enemy.GetComponent<Transform>().position;
			}
			if (Physics.Raycast(canon.transform.position, fwd, out rayHit, 75) && flag)
			{
				Debug.DrawLine(transform.position, temp.point, Color.red);
				temp = rayHit;
				flag = false;
				StartCoroutine(ray());
			}
			if (life <= 0)
				Destroy(this.gameObject);
		}
	}

	IEnumerator ray() {
	
		yield return new WaitForSeconds(2);
		particule_rocket.SetActive(false);
		particule_rocket.transform.position = temp.point;
		particule_rocket.SetActive(true);
		tab[0].Play();
		if (temp.collider.tag == "Player")
			player.GetComponent<cam>().life -=20;
		else if (temp.collider.tag == "enemy")
			temp.collider.GetComponent<enemy>().life -= 20;
		yield return new WaitForSeconds(2);
		flag = true;	
	}

}
