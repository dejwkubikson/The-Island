using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameData : MonoBehaviour {

	public UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpc;

	public GameObject woodenRaftPlace;
	public Text notification;
	public Text woodText;
	public Text ropeText;
	public GameObject woodenRaft;
	public WoodTrigger woodTrigger;
	public RopeTrigger ropeTrigger;
	public AudioClip scratchingSound;
	public AudioClip missionCompleteSound;

	public int woodAmount = 0;
	public int ropeAmount = 0;

	private bool raftIsCreated = false;
	private AudioSource sound;

	IEnumerator DelayNotification()
	{
		yield return new WaitForSeconds (3);
		notification.text = "";
	}

	IEnumerator RestartGame()
	{
		yield return new WaitForSeconds (3);
		Application.LoadLevel ("Island");
	}

	IEnumerator PlaySoundAndFinish()
	{
		yield return new WaitForSeconds (sound.clip.length);
		sound = GetComponent<AudioSource> ();
		sound.clip = missionCompleteSound;
		sound.Play ();
		yield return new WaitForSeconds (sound.clip.length);
		Application.LoadLevel ("EndScene");
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (notification.text != "" && woodAmount != 5 && ropeAmount != 2)
			StartCoroutine (DelayNotification ());
		
		woodText.text = "Wooden logs: " + woodAmount.ToString ();

		if (woodAmount == 5)
			woodText.color = Color.green;

		ropeText.text = "Ropes: " + ropeAmount.ToString ();

		if (ropeAmount == 2)
			ropeText.color = Color.green;

		if (woodAmount == 5 && ropeAmount == 2)
			notification.text = "You can build a raft now! Go near water and press F!";

		if (woodAmount == 5 && ropeAmount == 2 && fpc.IsNearWater ()) {
			notification.text = "Press F to build a raft!";

			if (Input.GetKey (KeyCode.F)) {
				sound = GetComponent<AudioSource> ();
				sound.clip = scratchingSound;
				sound.Play ();

				if (!(raftIsCreated)) 
				{
					Instantiate (woodenRaft, woodenRaftPlace.transform.position, woodenRaftPlace.transform.rotation);
					raftIsCreated = true;
					ropeAmount = 0;
					woodAmount = 0;
					notification.text = "";
					notification.text = "You have made it! You will survive!";
					StartCoroutine (PlaySoundAndFinish());
				}
		
			}
	
		}
	}
}
