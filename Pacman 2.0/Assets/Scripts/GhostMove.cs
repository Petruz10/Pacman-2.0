/*
 * Petra Íris Leifsdóttir
 * 2304549
 * leifsdottir@chapman.edu
 * CPSC-236-02
 * Final Project - Pacman 2.0 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMove : MonoBehaviour 
{
	public Transform[] waypoints;
	int cur = 0;
	public float speed;

	private GameManager gm;

	/*
	 * first method to be called
	 * finds the gameManager
	 */
	void Start () {
		gm = GameObject.Find ("GameManager").GetComponent<GameManager> ();
	}

	/*
	 * called once per frame
	 * if the user has lost return 
	 * else moves the ghost between the different waypoints, if all have been reaced start at the first
	 */
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

	/*
	 * If you collide with the player set lost to true and call gameOver method in 1 sec
	 */
	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player") 
		{
			gm.lost = true;
			Invoke ("gameOver", 1);

		}
	}

	/*
	 * calls gameOver method in the gameManager
	 */
	void gameOver()
	{
		gm.gameOver ();
	}
}
