using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GravityBallScript : MonoBehaviour {
	public AudioSource AS;
	public AudioClip GravitySound;
	KeyCode Activate;
	public float activeDuration;
	public float GravityEmpowerRatio;
	Rigidbody rigi;
	bool canDeactivate;
	GameObject Antigrav;
	// Use this for initialization
	void Start () {
		AS = GetComponent<AudioSource> ();
		rigi = GetComponent<Rigidbody> ();
		Activate = GetComponent<AllBallsNeedThis> ().Activate;
		canDeactivate = false;
		Antigrav = GameObject.Find ("Antigrav");

	}
	
	// Update is called once per frame
	void Update () {
		Antigrav.transform.position = transform.position;

		if (Input.GetKeyDown (Activate) && !GetComponent<AllBallsNeedThis> ().isWating) {
			if (canDeactivate) {
				canDeactivate = false;
				turnOff();
			}else
				StartCoroutine (antiGravity());
			AS.PlayOneShot (GravitySound);
		}
	}

	void turnOn(){
		rigi.useGravity = false;
		canDeactivate = true;
		Antigrav.GetComponent<ParticleSystem>().Play ();
	}

	void turnOff(){
		rigi.useGravity = true;
		Antigrav.GetComponent<ParticleSystem>().Stop ();
		Antigrav.GetComponent<ParticleSystem>().Clear ();
	}

	IEnumerator antiGravity(){
		turnOn ();
		yield return new WaitForSeconds (activeDuration);
		turnOff ();
	}



	public void StartTurn(){
		GetComponent<AllBallsNeedThis> ().beingAttractedExpl = true;
		GetComponent<AllBallsNeedThis> ().triggerInvBlink = false;
		gameObject.SetActive (true);
	}
}