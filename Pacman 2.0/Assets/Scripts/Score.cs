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
using UnityEngine.UI;


public class Score : MonoBehaviour 
{
	public GameManager gm;

	/*
	 * first method to be called
	 * finds the gameManager
	 */
	void Start () 
	{
		gm = GameObject.Find ("GameManager").GetComponent<GameManager> ();
	}
	
	/*
	 * when colliding with the player destroy this GO
	 * call the updateScore method in the gameManager
	 */
	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player") 
		{
			Destroy (this.gameObject);
			gm.updateScore ();

		}
	}
}
