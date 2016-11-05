using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public static MusicManager S;
	public AudioSource audioSource;

	public AudioClip windSound;
	public AudioClip mazeMusic;
	public AudioClip themeMusic;

	void Awake() {
		S = this;
	}
	// Update is called once per frame
	void Update () {
//
//		if (!audioSource.isPlaying) {
//			if (Player.S.isInAPuzzleRoom) {
//				audioSource.clip = mazeMusic;
//			} else {
//				audioSource.clip = windSound;
//			}
//			audioSource.Play();
//		}
	}

	public void playMazeMusic() {
		audioSource.Stop();
		audioSource.clip = mazeMusic;
		audioSource.Play ();
	}
	public void playWindSound() {
		audioSource.Stop();
		audioSource.clip = windSound;
		audioSource.Play ();
	}
	public void playThemeMusic() {
		audioSource.Stop();
		audioSource.clip = themeMusic;
		audioSource.Play ();
	}
}
