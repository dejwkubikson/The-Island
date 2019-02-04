using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

	public AudioClip buttonSound;
	public AudioClip menuMusic;

	private AudioSource sound; 

	public void LoadMainLevel(){

		StartCoroutine (DelayLoadMainLevel ());
	}
		
	public void QuitGame(){

		StartCoroutine (DelayExitApplication ());
	}
		
	IEnumerator DelayLoadMainLevel(){

		sound.clip = buttonSound;
		sound.loop = false;
		sound.Play ();
		yield return new WaitForSeconds (sound.clip.length);
		Application.LoadLevel ("Island");
	}
		
	IEnumerator DelayExitApplication(){

		sound.clip = buttonSound;
		sound.loop = false;
		sound.Play ();
		yield return new WaitForSeconds (sound.clip.length);
		Application.Quit ();
	}

	public void PlayBackgroundMusic(){

		sound.clip = menuMusic;
		sound.loop = true;
		sound.Play ();
	}


	// Use this for initialization
	void Start () {
		sound = GetComponent<AudioSource>();
		PlayBackgroundMusic();
	}

	// Update is called once per frame
	void Update () {

	}
}
