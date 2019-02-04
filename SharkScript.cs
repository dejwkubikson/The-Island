using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SharkScript : MonoBehaviour {

	public Transform[] path;
	public float speed = 28.0f;
	public Text notifiactionText;
	public MapControl mapControl;

	private float reachDist = 1.0f;
	private int currentPoint = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		float dist = Vector3.Distance (path [currentPoint].position, transform.position);

		transform.position = Vector3.MoveTowards (transform.position, path [currentPoint].position, Time.deltaTime * speed);
		transform.LookAt (path[currentPoint]);

		if (dist <= reachDist) {
			currentPoint++;
		}

		if (currentPoint >= path.Length) {
			currentPoint = 0;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "Player") {
			
			notifiactionText.text = "You were eaten by a shark!";
			StartCoroutine (mapControl.RestartGame ());
		}

	}

	void OnDrawGizmos(){

		if (path.Length > 0) {
			for (int i = 0; i < path.Length; i++) {

				if (path [i] != null) {

					Gizmos.DrawSphere (path [i].position, reachDist);
				}
			}
		}
	}

}
