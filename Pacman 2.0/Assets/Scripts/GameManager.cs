using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
	public GameObject scoreText;
	public GameObject gameAreaGO;
	public GameObject playBtn;
	public GameObject startTxt;

	public int score = 0;
	public int dots = 0;

	private int highscore;

	public bool lost = false;

	private GameObject cloneGameAreaGO;

	void Awake()
	{
		Setup ();
	}

	void Setup()
	{
		dots = GameObject.FindGameObjectsWithTag("pacdot").Length;
		highscore = PlayerPrefs.GetInt ("highscore", highscore);
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
		scoreText.GetComponent<Text> ().text = score.ToString() + ", High  " + highscore.ToString();

		if (score == dots) {
			Invoke ("finish", 1);
		}
	}

	public void play()
	{
		score = 0;
		startTxt.SetActive (false);
		playBtn.SetActive(false);

		cloneGameAreaGO = Instantiate (gameAreaGO, new Vector3(-11,0,0), transform.rotation) as GameObject;
		lost = false;
	}

	void finish()
	{
		checkHighscore ();

		startTxt.GetComponent<Text>().text = "You Won!";
		startTxt.SetActive (true);
	}

	public void gameOver()
	{
		checkHighscore ();

		Destroy (cloneGameAreaGO);

		startTxt.GetComponent<Text>().text = "GAME OVER!";
		startTxt.SetActive (true);
		playBtn.SetActive (true);
	}

	void checkHighscore ()
	{
		if (highscore < score) 
		{
			highscore = score;
			PlayerPrefs.SetInt ("highscore", highscore);
		}

	}
}
