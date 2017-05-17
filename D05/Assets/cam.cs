using UnityEngine;
using System.Collections;

public class cam : MonoBehaviour {
	public GameObject ball;
	public GameObject flag1;
	public GameObject flag2;
	public GameObject flag3;
	float start_y;
	float start_x;

	public float	yRotation = 280, xRotation = 0;

	private bool flag_camera = true;
	private float	rotateSpeed = 3f;
	private GameObject current_target;
	// Use this for initialization
	private Vector3 flag1_pos = new Vector3(71.91f, 92.5f, 96.32f);
	void Start ()
	{
		current_target = flag1;
	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey("e"))
		{
			flag_camera = false;
			start_y = Input.GetAxis("Mouse Y") * rotateSpeed;
			start_x = Input.GetAxis("Mouse X") * rotateSpeed;
			yRotation = 180; 
		}
		if (Input.GetKeyDown("space"))
			flag_camera = true;

		if (!flag_camera)
		{
			yRotation -= Input.GetAxis("Mouse Y") * rotateSpeed;
			yRotation = Mathf.Clamp(yRotation, -80, 80);
			xRotation += Input.GetAxis("Mouse X") * rotateSpeed;
			xRotation = xRotation % 360;
			Debug.Log(new Vector3(yRotation - start_x, xRotation - start_y, 0));
			transform.localEulerAngles = new Vector3(yRotation - start_x, xRotation - start_y, 0);

			if (Input.GetKey("w") && !hit(transform.forward * 5) && (transform.position + transform.forward * 5).y < 150)
				transform.position += transform.forward * 5;
			if (Input.GetKey("s") && !hit(-transform.forward * 5) && (transform.position - transform.forward * 5).y < 150)
				transform.position += -transform.forward * 5;
			if (Input.GetKey("d") && !hit(transform.right * 5) && (transform.position + transform.right * 5).y < 150)
				transform.position += transform.right * 5;
			if (Input.GetKey("a") && !hit(-transform.right * 5) && (transform.position - transform.right * 5).y < 150)
				transform.position += -transform.right * 5;
		}
		else
		{
			if (Input.GetKeyUp("space"))
			{
				ball.transform.LookAt(flag1_pos);
		 		Vector3 new_pos = ball.transform.position;
				new_pos.y += 5f; 
				new_pos.z += -2f;
				transform.position = new_pos;
				transform.LookAt(flag1_pos);
				ball.GetComponent<Rigidbody>().AddForce(ball.transform.forward * 50, ForceMode.VelocityChange);
			}
		}
	}

	bool hit(Vector3 vec)
	{
		RaycastHit hit;
		Ray landingRay = new Ray(transform.position, vec);

		if (Physics.Raycast(landingRay, out hit, 10))
			return (true);
		return (false);
	}
}
