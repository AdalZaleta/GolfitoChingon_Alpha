using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour {
	public GameObject Hole;
	public int WinnerExp;
	public int WinnerBlink;
	public int WinnerGravity;
	public int HoleIn;
	private Leaderboard Winner;

	void Start()
	{
		Winner = GameObject.Find ("LeaderBoard").GetComponent<Leaderboard> ();
	}

	void Update ()
	{
		if(HoleIn == 3)
		{
			Winner.Winner();
		}
	}

	void OnTriggerEnter (Collider _lastRound)
	{
		if(_lastRound.gameObject.CompareTag("Gball"))
		{
			HoleIn += 1;
		}
	}
}
