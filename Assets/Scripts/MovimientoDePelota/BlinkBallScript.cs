﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BlinkBallScript : MonoBehaviour {
	public AudioSource AS;
	public AudioClip BlinkSound;
	public float BlinkDistance;
	KeyCode Activate;
	public GameObject Trap;
	Rigidbody rigi;
	// Use this for initialization
	void Start () {
		AS = GetComponent<AudioSource>();
		rigi = GetComponent<Rigidbody> ();
		Activate = GetComponent<AllBallsNeedThis> ().Activate;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (Activate)) {
			Blink ();
		}
	}

	void Blink(){
		AS.PlayOneShot (BlinkSound);
		GameObject go = Instantiate (Trap);
		go.transform.position = transform.position;
		transform.Translate (rigi.velocity.normalized.x * BlinkDistance,
		rigi.velocity.normalized.y * BlinkDistance,
		rigi.velocity.normalized.z * BlinkDistance,
		Space.World); 
	}
}
