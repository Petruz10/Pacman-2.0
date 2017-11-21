using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
	public GameObject scoreText;
	public int score = 0;
	public int dots = 0;

	public bool lost = false;

	void Awake()
	{
		Setup ();
	}

	void Setup()
	{
		dots = GameObject.FindGameObjectsWithTag("pacdot").Length;
	}

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void updateScore()
	{
		score += 1;
		scoreText.GetComponent<Text> ().text = score.ToString();

		if (score == dots) {
			finish ();
		}
	}

	void finish()
	{
		Debug.Log("You Won!");
		lost = true;
	}

	public void gameOver()
	{
		Debug.Log ("GAME OVER!");
	}
}
