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
	// Use this for initialization
	void Start () {
		AS = GetComponent<AudioSource> ();
		rigi = GetComponent<Rigidbody> ();
		Activate = GetComponent<AllBallsNeedThis> ().Activate;
		canDeactivate = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (Activate) && !GetComponent<AllBallsNeedThis> ().isWating) {
			if (canDeactivate) {
				canDeactivate = false;
				turnOff();
			}else
				StartCoroutine (antiGravity());
			AS.PlayOneShot (GravitySound);
		}
	}

	void turnOn(){
		print ("ZERO GRAVITY");
		rigi.useGravity = false;
		canDeactivate = true;
	}

	void turnOff(){
		rigi.useGravity = true;
	}

	IEnumerator antiGravity(){
		turnOn ();
		yield return new WaitForSeconds (activeDuration);
		turnOff ();
	}

	void OnTriggerStay(Collider _col){
		if (_col.CompareTag ("Gball") && GetComponent<AllBallsNeedThis>().isWating) {
			_col.GetComponent<Rigidbody> ().AddForce (Vector3.down * GravityEmpowerRatio, ForceMode.Acceleration);
		}
	}

	public void StartTurn(){
		GetComponent<AllBallsNeedThis> ().beingAttractedExpl = true;
		GetComponent<AllBallsNeedThis> ().triggerInvBlink = false;
		gameObject.SetActive (true);
	}
}