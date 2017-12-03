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
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
	public GameObject scoreText;
	public GameObject highscoreText;
	public GameObject gameAreaGO;
	public GameObject playBtn;
	public GameObject startTxt;

	public int score = 0;
	public int dots = 0;

	public bool lost = false;

	private int highscore;
	private GameObject cloneGameAreaGO;

	/*
	 * The first method to run
	 * Calls a setup method
	 */
	void Awake()
	{
		Setup ();
	}

	/*
	 * Get all the pacdots in the game and gets the saved highscore and shows it
	 */
	void Setup()
	{
		dots = GameObject.FindGameObjectsWithTag("pacdot").Length;
		highscore = PlayerPrefs.GetInt ("highscore", highscore);

		highscoreText.GetComponent<Text> ().text = highscore.ToString ();
	}

	/*
	 * Method to update the score,
	 * adds one to the score and update the UI
	 * if the score is equal to the dots, wait 1 sec and calls the youWin method
	 */
	public void updateScore()
	{
		score += 1;
		scoreText.GetComponent<Text> ().text = score.ToString();

		if (score == dots) {
			Invoke ("youWin", 1);
		}
	}

	/*
	 * sets the score to zero and removes the play btn and start text
	 * Instanciate a new clone of the GameAreaGO
	 * set lost to false
	 */
	public void play()
	{
		score = 0;
		startTxt.SetActive (false);
		playBtn.SetActive(false);

		cloneGameAreaGO = Instantiate (gameAreaGO, new Vector3(-11,0,0), transform.rotation) as GameObject;
		lost = false;
	}

	/*
	 * calls the check highscore method
	 * shows the play btn
	 * shows the startText
	 * destroys the GameArea
	 */
	void finish()
	{
		checkHighscore ();

		Destroy (cloneGameAreaGO);
		
		startTxt.SetActive (true);
		playBtn.SetActive (true);
	}

	/*
	 * sets the startText to "you won"
	 * calls the finish method
	 */
	void youWin()
	{
		startTxt.GetComponent<Text>().text = "You Won!";

		finish();
	}

	/*
	 * sets the startText to "Game over"
	 * calls the finish method
	 */
	public void gameOver()
	{
		startTxt.GetComponent<Text>().text = "GAME OVER!";

		finish();
	}

	/*
	 * checks if the current highscore is smaller than your score
	 * if yes, sets the highscore to your score and saves it
	 * shows the new highscore
	 */
	void checkHighscore ()
	{
		if (highscore < score) 
		{
			highscore = score;
			PlayerPrefs.SetInt ("highscore", highscore);
			highscoreText.GetComponent<Text> ().text = highscore.ToString ();
		}

	}
}
