﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AllBallsNeedThis : MonoBehaviour {
	public AudioSource AS;
	[Tooltip("SFX cuando choque con Pared")]
	public AudioClip ChoqueParedSFX;
	[Tooltip("SFX cuando choca con otra Pelota")]
	public AudioClip ChoquePelotaSFX;
	public float invulerabilityTime;
	public bool triggerInvBlink = false;
	public bool beingAttractedExpl = true;
	public bool isWating;
	public KeyCode Activate;
	public float FuerzaPersonaje;
	public float PresicionPersonaje;
	public float floorGluines;
	public Transform lastStart;
	public bool done;
	public float RigVelocity;

	void Start()
	{
		AS = GetComponent<AudioSource> ();
		gameObject.SetActive (false);
		transform.position = lastStart.position;
	}

	void Update(){
		if (transform.position.y <= -50f) {
			OutOfBounds ();
		}
		EverythingMustEnd ();

		if (done && gameObject.activeSelf)
		{
			gameObject.SetActive (false);
		}
	}

	void OnCollisionEnter (Collision _col)
	{
		if (_col.gameObject.CompareTag ("Gball")) {
			AS.PlayOneShot (ChoquePelotaSFX);
		}
	}

	public void Saludar(){
		print (FuerzaPersonaje);
		GetComponent<Rigidbody> ().AddForce (Vector3.up * 100);
	}

	public void BlinkInv (){
		triggerInvBlink = true;
	}

	void StartOfTurn(){
		triggerInvBlink = false;
		beingAttractedExpl = true;
	}

	IEnumerator blinkInv(float time){
		yield return new WaitForSeconds (time);
		triggerInvBlink = false;
	}

	public void OutOfBounds(){
		transform.position = lastStart.position;
		GetComponent<Rigidbody> ().velocity = Vector3.zero;
		print ("out of bouds: " + lastStart.position);
	}

	void EverythingMustEnd(){
		RigVelocity = GetComponent<Rigidbody> ().velocity.magnitude;
		if (GetComponent<Rigidbody> ().velocity.magnitude <= 1.5f && GetComponent<Rigidbody> ().velocity.magnitude > 0.5f) {
			GetComponent<Rigidbody> ().velocity -= GetComponent<Rigidbody> ().velocity.normalized * 1.0f * Time.deltaTime;
		}
		else if (GetComponent<Rigidbody> ().velocity.magnitude <= 0.5f) {
			GetComponent<Rigidbody> ().velocity = Vector3.zero;
		}
	}
}
