using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RopeTrigger : MonoBehaviour 
{

    public GameObject rope;
	public Text notification;
	public GameData gameData;

	private bool ropePicked = false;
	private bool inTrigger = false;

    void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.name == "Player")
			inTrigger = true;

		if (inTrigger && !(ropePicked)) 
		{
			notification.text = "Press E to pick up rope";
		}
    }

    void OnTriggerExit(Collider other)
    {
		if (other.gameObject.name == "Player")
		{
			inTrigger = false;
			notification.text = "";
		}
    }

    void ObjectPickUp()
    {
        if (Input.GetKey(KeyCode.E))
        {
			notification.text = "You picked up rope";
            Destroy(rope);
            ropePicked = true;
			gameData.ropeAmount++;
			GetComponent<AudioSource>().Play();
        } 
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (inTrigger && !(ropePicked)) 
			ObjectPickUp ();
    }
}
