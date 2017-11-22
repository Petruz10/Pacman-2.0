using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMove : MonoBehaviour 
{
	public Transform[] waypoints;
	int cur = 0;
	public float speed;

	private GameManager gm;

	// Use this for initialization
	void Start () {
		gm = GameObject.Find ("GameManager").GetComponent<GameManager> ();
	}

	// Update is called once per frame
	void Update () 
	{
		if (gm.lost)
			return;
		if (transform.position != waypoints[cur].position) {
			Vector2 p = Vector2.MoveTowards(transform.position, waypoints[cur].position, speed);
			GetComponent<Rigidbody>().MovePosition(p);
		}
		// Waypoint reached, select next one
		else cur = (cur + 1) % waypoints.Length;
		
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player") 
		{
			gm.lost = true;
			gm.gameOver ();
		}
	}
}
