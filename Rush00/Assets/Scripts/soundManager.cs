using UnityEngine;
using System.Collections;

public class soundManager : MonoBehaviour {

	public AudioClip				win;
	public AudioClip				gameOver;

	public static soundManager		sm;

	private AudioSource 			playerSource;
	
	void Start() {
		if (sm == null)
			sm = this;
		playerSource = GameObject.Find ("Player").GetComponent<AudioSource>();
	}

	public void playSound(AudioSource source, AudioClip clip)
	{
		source.clip = clip;
		source.Play();
	}

	public void playSound(AudioClip clip)
	{
		playerSource.clip = clip;
		playerSource.Play();
	}

	public void playWin()
	{
		playerSource.clip = win;
		playerSource.Play();
	}

	public void playGameover()
	{
		playerSource.clip = gameOver;
		playerSource.Play();
	}
}
