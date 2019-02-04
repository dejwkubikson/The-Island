using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapControl : MonoBehaviour {

	public Text notification;
	public Text timeText;
	public UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpc;

	private bool outOfMap = false;
	private float timeLeft = 3.0f;


	public IEnumerator RestartGame()
	{
		yield return new WaitForSeconds (2);
		Application.LoadLevel ("Island");
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "Player")
			outOfMap = false;
		
		notification.text = "";
		timeText.text = "";
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.name == "Player")
		{
			outOfMap = true;
		}
	}

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if(outOfMap)
		{
			timeLeft -= Time.deltaTime;
			if(timeLeft > 0)
			{
				notification.text = "Get back or you'll drown!";
				timeText.text = timeLeft.ToString ("0");
			}

			if (timeLeft < 0)
			{
				notification.text = ""; // this is done so that the DelayNotification in GameData wont erease the text below
				notification.text = "You have drown. Game Over!";
				timeText.text = "";
				StartCoroutine(RestartGame());
			}
		}
		else
		{
			timeLeft = 3.0f;
		}
	}
}
