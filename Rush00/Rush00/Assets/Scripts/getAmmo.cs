using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class getAmmo : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		int 	ammo;
		string	text;

		text = "-";
		if (player.p.weapon != null) {
			ammo = player.p.weapon.GetComponent<weaponScript> ().ammo;
			if (ammo > 0)
				text = ammo.ToString ();
			if (ammo < 0)
				text = "∞";
		}
		GetComponent<Text> ().text = text;
	}
}
