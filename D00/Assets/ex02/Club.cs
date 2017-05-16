using UnityEngine;
using System.Collections;

public class Club : MonoBehaviour {

	private bool hold = false;
	private Vector3 save_position;
	private float jauge = 0;
	public GameObject Ball_GameObject;
	private int score = -15;
	private Ball ball;

	
	// Use this for initialization
	void Start () {
		ball = Ball_GameObject.GetComponent<Ball>();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown ("space"))
		{
			jauge += 0;
			save_position = transform.position;
			hold = true;
		}
		if (Input.GetKeyUp ("space")) {
			score += 5;
			Debug.Log("Score : " + score);
			hold = false;
			transform.position = save_position;
			ball.jauge = jauge;
			ball.move = true;
			jauge = 0;
		}
		if (hold)
		{
			jauge += 0.5f;
			transform.Translate (new Vector3 (0f, -0.05f, 0f));
		}
	}
}
