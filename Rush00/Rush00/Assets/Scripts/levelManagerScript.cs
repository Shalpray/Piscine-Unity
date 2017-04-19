using UnityEngine;
using System.Collections;

public class levelManagerScript : MonoBehaviour {

	public string nextLevelName;

	void Start() {
		Time.timeScale = 1.0f;
	}

	public void reloadCurrent() {
		Application.LoadLevel(Application.loadedLevel);
	}

	public void loadNext () {
		Application.LoadLevel(nextLevelName);
	}

	public void quitGame () {
		Application.Quit();
	}

	public void loadTitleScreen () {
		Application.LoadLevel (0);
	}
}
