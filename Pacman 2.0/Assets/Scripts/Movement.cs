using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour 
{
	public float speed;
	private Vector3 playerPos = new Vector3 (0, 0, 0);

	private GameManager gm;


	// Use this for initialization
	void Start () 
	{
		gm = GameObject.Find ("GameManager").GetComponent<GameManager> ();
	}

	//Reused some script from the BrickBuster game
	// Update is called once per frame
	void Update () 
	{
		if (gm.gameOver)
			return;
		float xPos = transform.position.x + (Input.GetAxis("Horizontal") * speed);
		float yPos = transform.position.y + (Input.GetAxis("Vertical") * speed);

		playerPos = new Vector3 (xPos, yPos, 0f);
		transform.position = playerPos;
	}
}
