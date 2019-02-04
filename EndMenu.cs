using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenu : MonoBehaviour {

	public AudioClip buttonSound;
	public AudioClip menuMusic;

	private AudioSource sound; 

	public void LoadMainMenu(){

		StartCoroutine (DelayLoadMainMenu ());
	}
		
	public void QuitGame(){

		StartCoroutine (DelayExitApplication ());
	}
		
	IEnumerator DelayLoadMainMenu(){

		sound.clip = buttonSound;
		sound.loop = false;
		sound.Play ();
		yield return new WaitForSeconds (sound.clip.length);
		Application.LoadLevel ("MainMenu");
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

		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}

	// Update is called once per frame
	void Update () {

	}
}
