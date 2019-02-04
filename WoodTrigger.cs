using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WoodTrigger : MonoBehaviour
{

    public GameObject woodenLog;
 	public Text notification;
	public GameData gameData;


	private bool woodPicked = false;
	private bool inTrigger = false;

    void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.name == "Player")
			inTrigger = true;
		
		if (inTrigger && !(woodPicked)) 
		{
			notification.text = "Press E to pick up wooden log";
		}
    }

    void OnTriggerExit(Collider other)
    {
		if (other.gameObject.name == "Player" && !(woodPicked))
        {
            inTrigger = false;
			notification.text = "";
        }
    }

    void ObjectPickUp()
    {
        if (Input.GetKey(KeyCode.E))
        {
			notification.text = "You picked up wooden log";
			Destroy(woodenLog);
			woodPicked = true;
			if (woodenLog.name == "WoodObject2")
				gameData.woodAmount++;
			else
				gameData.woodAmount += 2;
			GetComponent<AudioSource>().Play();

        }
    }

    // Use this for initialization
    void Start()
    {

	}

    // Update is called once per frame
    void Update()
    {
		if (inTrigger && !(woodPicked)) 
			ObjectPickUp ();
    }
}
