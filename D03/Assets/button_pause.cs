using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class button_pause : MonoBehaviour {

	public GameObject pause_panel;
	public GameObject pause_bg;
	public GameObject confirm_panel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void resume()
	{
		hide_panel(pause_bg.GetComponent<CanvasGroup>());
		hide_panel(pause_panel.GetComponent<CanvasGroup>());
		gameManager.gm.pause(false);
		gameManager.gm.changeSpeed(1);
	}

	public void rage_quit()
	{
		hide_panel(pause_panel.GetComponent<CanvasGroup>());
		show_panel(confirm_panel.GetComponent<CanvasGroup>());
	}

	private void hide_panel(CanvasGroup panel)
	{
		panel.alpha = 0;
		panel.interactable = false;
		panel.blocksRaycasts = false;
	}

	private void show_panel(CanvasGroup panel)
	{
		panel.alpha = 1;
		panel.interactable = true;
		panel.blocksRaycasts = true;
	}

	public void yes_quit()
	{
		Application.LoadLevel(0);
	}

	public void no_quit()
	{
		hide_panel(confirm_panel.GetComponent<CanvasGroup>());
		show_panel(pause_panel.GetComponent<CanvasGroup>());
	}
}
