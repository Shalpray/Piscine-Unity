using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class stealthprogress : MonoBehaviour {

	public GameObject	hero;
	private Character	script;
	public Image		img;	
	// Use this for initialization
	void Start () {
		script = hero.GetComponent<Character> ();
	}
	
	// Update is called once per frame
	void Update () {
		img.fillAmount = (float)(script.stealth + 2) / 1000;
	}
}
