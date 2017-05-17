using UnityEngine;
using System.Collections;

public class script_UI : MonoBehaviour {

	public GameObject prefab_canon;
	public GameObject prefab_gatling;
	public GameObject prefab_rocket;
	public GameObject text_energy;
	public GameObject text_vie; 

	public GameObject text_rangecanon;
	public GameObject text_damagecanon;
	public GameObject text_fireratecanon;
	public GameObject text_energycanon;
	public GameObject text_rangegatling;
	public GameObject text_damagegatling;
	public GameObject text_firerategatling;
	public GameObject text_energygatling;
	public GameObject text_rangerocket;
	public GameObject text_damagerocket;
	public GameObject text_fireraterocket;
	public GameObject text_energyrocket;

	public GameObject pause_panel;
	public GameObject pause_gb;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.Escape))
		{
			CanvasGroup pause_bg_c = pause_panel.GetComponent<CanvasGroup>();
			CanvasGroup pause_panel_c = pause_gb.GetComponent<CanvasGroup>();

			gameManager.gm.pause(true);
			pause_bg_c.alpha = 1;
			pause_bg_c.interactable = true;
			pause_bg_c.blocksRaycasts = true;
			pause_panel_c.alpha = 1;
			pause_panel_c.interactable = true;
			pause_panel_c.blocksRaycasts = true;
		}

		text_energy.GetComponent<UnityEngine.UI.Text>().text = gameManager.gm.playerEnergy.ToString();
		text_vie.GetComponent<UnityEngine.UI.Text>().text = gameManager.gm.playerHp.ToString();

		text_rangecanon.GetComponent<UnityEngine.UI.Text>().text = prefab_canon.GetComponent<towerScript>().range.ToString();
		text_damagecanon.GetComponent<UnityEngine.UI.Text>().text = prefab_canon.GetComponent<towerScript>().damage.ToString();
		text_fireratecanon.GetComponent<UnityEngine.UI.Text>().text = prefab_canon.GetComponent<towerScript>().fireRate.ToString();
		text_energycanon.GetComponent<UnityEngine.UI.Text>().text = prefab_canon.GetComponent<towerScript>().energy.ToString();

		text_rangegatling.GetComponent<UnityEngine.UI.Text>().text = prefab_gatling.GetComponent<towerScript>().range.ToString();
		text_damagegatling.GetComponent<UnityEngine.UI.Text>().text = prefab_gatling.GetComponent<towerScript>().damage.ToString();
		text_firerategatling.GetComponent<UnityEngine.UI.Text>().text = prefab_gatling.GetComponent<towerScript>().fireRate.ToString();
		text_energygatling.GetComponent<UnityEngine.UI.Text>().text = prefab_gatling.GetComponent<towerScript>().energy.ToString();

		text_rangerocket.GetComponent<UnityEngine.UI.Text>().text = prefab_rocket.GetComponent<towerScript>().range.ToString();
		text_damagerocket.GetComponent<UnityEngine.UI.Text>().text = prefab_rocket.GetComponent<towerScript>().damage.ToString();
		text_fireraterocket.GetComponent<UnityEngine.UI.Text>().text = prefab_rocket.GetComponent<towerScript>().fireRate.ToString();
		text_energyrocket.GetComponent<UnityEngine.UI.Text>().text = prefab_rocket.GetComponent<towerScript>().energy.ToString();
	}


	public void make_canon(Vector3 position)
	{
		if (gameManager.gm.playerEnergy >= prefab_canon.GetComponent<towerScript>().energy)
		{
			Instantiate(prefab_canon, position, Quaternion.identity);
			gameManager.gm.playerEnergy -= prefab_canon.GetComponent<towerScript>().energy;
		}
		
	}

	public void make_gatling(Vector3 position)
	{
		if (gameManager.gm.playerEnergy >= prefab_gatling.GetComponent<towerScript>().energy)
		{
			Instantiate(prefab_gatling, position, Quaternion.identity);
			gameManager.gm.playerEnergy -= prefab_gatling.GetComponent<towerScript>().energy;
		}
	}

	public void make_rocket(Vector3 position)
	{
		if (gameManager.gm.playerEnergy >= prefab_rocket.GetComponent<towerScript>().energy)
		{
			Instantiate(prefab_rocket, position, Quaternion.identity);
			gameManager.gm.playerEnergy -= prefab_rocket.GetComponent<towerScript>().energy;
		}
	}

}
