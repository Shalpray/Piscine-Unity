using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gui : MonoBehaviour {

	// Use this for initialization
	public GameObject Life;
	public GameObject Ammo;
	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Life.GetComponent<Text>().text = (GetComponent<cam>().life).ToString();
		Ammo.GetComponent<Text>().text = (GetComponent<cam>().nb_roquettes).ToString();
	}
}
