using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour 
{
	public GameManager gm;

	// Use this for initialization
	void Start () 
	{
		gm = GameObject.Find ("GameManager").GetComponent<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player") 
		{
			Destroy (this.gameObject);
			gm.updateScore ();

		}
	}
}
