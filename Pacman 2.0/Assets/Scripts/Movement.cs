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

public class Movement : MonoBehaviour 
{
	public float speed;
	private Vector3 playerPos = new Vector3 (0, 0, 0);

	private GameManager gm;


	/*
	 * first method to be called
	 * finds the gameManager
	 */
	void Start () 
	{
		gm = GameObject.Find ("GameManager").GetComponent<GameManager> ();
	}

	/*
	 * if lost is true return
	 * else move the player when they press the arrow keys or wasd
	 */
	void Update () 
	{
		if (gm.lost)
			return;
		float xPos = transform.position.x + (Input.GetAxis("Horizontal") * speed);
		float yPos = transform.position.y + (Input.GetAxis("Vertical") * speed);

		playerPos = new Vector3 (xPos, yPos, 0f);
		transform.position = playerPos;
	}
}
