using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ExplosionBallScript : MonoBehaviour {
	public AudioSource AS;
	public AudioClip ExplosionSound;
	public float ExpurosionForce;
	public float AtractionForce;
	public float magnitudeVisible;
	bool ammo = true;
	bool isAbsorbing;
	KeyCode Activate;
	Rigidbody rigi;
	// Use this for initialization
	void Start () {
		AS = GetComponent<AudioSource> ();
		rigi = GetComponent<Rigidbody> ();
		Activate = GetComponent<AllBallsNeedThis> ().Activate;
	}
	
	// Update is called once per frame
	void Update () {
		magnitudeVisible = rigi.velocity.magnitude;
		if (Input.GetKeyDown (Activate) && !GetComponent<AllBallsNeedThis> ().isWating && ammo) {
			rigi.AddForce (new Vector3 (0f, ExpurosionForce, 0f), ForceMode.Impulse);
			AS.PlayOneShot (ExplosionSound);
			ammo = false;
		}
	}

	void OnTriggerStay(Collider _col)
	{
		if (_col.tag == "Gball" && GetComponent<AllBallsNeedThis> ().isWating && isAbsorbing) {
			if (_col.gameObject.GetComponent<AllBallsNeedThis> ().beingAttractedExpl) {
				_col.GetComponent<Rigidbody> ().AddForce (Vector3.one - (_col.transform.position - transform.position) * AtractionForce, ForceMode.Acceleration);
				print ("atracted");
			}
		}
	}

	void OnCollisionEnter(Collision _col)
	{
		print ("something colided: " + _col.gameObject.tag);
		if (_col.gameObject.tag == "Gball" && GetComponent<AllBallsNeedThis>().isWating) {
			_col.rigidbody.velocity = Vector3.zero;
			_col.gameObject.GetComponent<AllBallsNeedThis> ().beingAttractedExpl = false;
			isAbsorbing = false;
			print ("A ball colided");
		}
	}

	public void StartTurn(){
		ammo = true;
		GetComponent<AllBallsNeedThis> ().beingAttractedExpl = true;
		GetComponent<AllBallsNeedThis> ().triggerInvBlink = false;
		gameObject.SetActive (true);
		isAbsorbing = false;
	}

	public void notMyTurn(){
		isAbsorbing = true;
	}
}
