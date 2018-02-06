﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleSwap : MonoBehaviour {

	public int BallsDone = 0;
	static int nOfCurrentHole = 1;
	public Transform nextP1;
	public Transform nextP2;
	public Transform nextP3;
	GameObject P1;
	GameObject P2;
	GameObject P3;
	public Camera cam;

	void OnTriggerEnter (Collider _col)
	{
		Debug.Log ("Triggered");
		if (_col.gameObject.CompareTag("Gball"))
		{
			Debug.Log ("Cleared");
			_col.gameObject.GetComponent<Rigidbody> ().velocity = Vector3.zero;
			_col.gameObject.GetComponent<AllBallsNeedThis> ().done = true;
			BallsDone++;
			Debug.Log ("BallsDone: " + BallsDone);
		}
	}

	// Use this for initialization
	void Start () {
		cam.GetComponent<PlayerPhase> ().SwitchHoles (nOfCurrentHole);
		P1 = GameObject.Find ("Explosion_Ball");
		P2 = GameObject.Find ("Blink_Ball");
		P3 = GameObject.Find ("Gravity_Ball");
	}
	
	// Update is called once per frame
	void Update () {
		if (BallsDone == 3)
		{
			cam.GetComponent<PlayerPhase> ().phase = 0;
			nOfCurrentHole++;
			cam.GetComponent<PlayerPhase> ().SwitchHoles (nOfCurrentHole);

			P1.transform.position = nextP1.position;
			P1.GetComponent<AllBallsNeedThis> ().lastStart = nextP1;
			P1.GetComponent<AllBallsNeedThis> ().done = false;
			P1.SetActive (true);

			P2.transform.position = nextP2.position;
			P2.GetComponent<AllBallsNeedThis> ().lastStart = nextP2;
			P2.GetComponent<AllBallsNeedThis> ().done = false;
			P2.SetActive (true);

			P3.transform.position = nextP3.position;
			P3.GetComponent<AllBallsNeedThis> ().lastStart = nextP3;
			P3.GetComponent<AllBallsNeedThis> ().done = false;
			P3.SetActive (true);

			BallsDone = 0;
		}
	}
}
