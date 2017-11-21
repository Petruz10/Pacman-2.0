using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
	public GameObject scoreText;
	public int score = 0;

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
	}
}
