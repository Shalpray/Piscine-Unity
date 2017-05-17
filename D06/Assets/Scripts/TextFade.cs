using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextFade : MonoBehaviour {

	Text blinkingText;
	Color	basic;
	// Use this for initialization
	void Start () {
		blinkingText = GetComponentInParent<Text>();
		basic = blinkingText.color;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void	helpText(string txt)
	{
		if (blinkingText)
		blinkingText.text = txt;
		StopAllCoroutines();
		StartCoroutine (fadeIn(0.5f));
	}

	IEnumerator fadeIn(float speed){
		float ratio = 0;
		while(ratio < 1){
			ratio += Time.deltaTime * speed;
			Color col = basic;
			col.a = Mathf.Lerp (0f, col.a,ratio);
			if (blinkingText)
			blinkingText.color = col;
			yield return null;
		}
		yield return new WaitForSeconds(1);
		ratio = 0;
		while(ratio < 1){
			ratio += Time.deltaTime * speed;
			Color col = basic;
			col.a = Mathf.Lerp (col.a,0f,ratio);
			blinkingText.color = col;
			yield return null;
		}
	}
}
