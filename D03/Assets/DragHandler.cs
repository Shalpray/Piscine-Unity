using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	script_UI obj_ui;
	Vector3 startPosition;
	public GameObject panel;

	void Start ()
	{

		obj_ui = panel.GetComponent<script_UI>();
	}


	void Update ()
	{
		if (transform.parent.name == "canon")
		{
			if (gameManager.gm.playerEnergy >= obj_ui.prefab_canon.GetComponent<towerScript>().energy)
				GetComponent<UnityEngine.UI.Image>().color = new Color(255,255,255,255);
			else
				GetComponent<UnityEngine.UI.Image>().color = new Color(255,0,0,255);
		}

		if (transform.parent.name == "gatling")
		{
			if (gameManager.gm.playerEnergy >= obj_ui.prefab_gatling.GetComponent<towerScript>().energy)
				GetComponent<UnityEngine.UI.Image>().color = new Color(255,255,255,255);
			else
				GetComponent<UnityEngine.UI.Image>().color = new Color(255,0,0,255);
		}

		if (transform.parent.name == "rocket")
		{
			if (gameManager.gm.playerEnergy >= obj_ui.prefab_rocket.GetComponent<towerScript>().energy)
				GetComponent<UnityEngine.UI.Image>().color = new Color(255,255,255,255);
			else
				GetComponent<UnityEngine.UI.Image>().color = new Color(255,0,0,255);
		}


	}

	public void OnBeginDrag (PointerEventData eventData)
	{

		startPosition = transform.position;
	}

	public void OnDrag (PointerEventData eventData)
	{
		Vector3 temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		temp.z = 5f;
		transform.position = temp;
	}

	public void OnEndDrag (PointerEventData eventData)
	{
		transform.position = startPosition;
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

		if (hit && hit.collider.gameObject.transform.parent.gameObject.name == "empty")
		{

			if (transform.parent.name == "canon")
				obj_ui.make_canon(hit.collider.gameObject.transform.position);
			if (transform.parent.name == "gatling")
				obj_ui.make_gatling(hit.collider.gameObject.transform.position);
			if (transform.parent.name == "rocket")
				obj_ui.make_rocket(hit.collider.gameObject.transform.position);
		}
	}
	
}