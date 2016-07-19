using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;

	public AudioClip startClip;
	public AudioClip gameClip;
	public AudioClip endClip;
	public AudioClip creditsClip;

	private AudioSource music;

	void Start () {
		if (instance != null && instance != this) {
			Destroy (gameObject);
			print ("Duplicate music player self-destructing!");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
			music = GetComponent<AudioSource> ();
			music.clip = startClip;
			_play ();
		}
		
	}

	void OnLevelWasLoaded(int levelID) {
		switch(levelID) {
		case 0:
			music.clip = startClip;
			break;
		case 1:
			music.clip = gameClip;
			break;
		case 2:
			music.clip = endClip;
			break;
		case 3:
			music.clip = creditsClip;
			break;
		default:
			music.clip = startClip;
			break;
		}
		_play();
	}

	private void _play() {
		music.Stop ();
		music.loop = true;
		music.Play ();
	}
}
