using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScript : MonoBehaviour {
	int HoleIn;
	public Camera cam;
	public Canvas Lead;

	void Start()
	{
	}

	void Update ()
	{
		if(HoleIn == 3)
		{
			Lead.enabled = true;
			cam.GetComponent<Leaderboard> ().Winner ();
		}
	}

	void OnTriggerEnter (Collider _col)
	{
		if(_col.gameObject.CompareTag("Gball"))
		{
			_col.gameObject.GetComponent<Rigidbody> ().velocity = Vector3.zero;
			_col.gameObject.GetComponent<AllBallsNeedThis> ().done = true;
			HoleIn ++;
		}
			
	}
}
