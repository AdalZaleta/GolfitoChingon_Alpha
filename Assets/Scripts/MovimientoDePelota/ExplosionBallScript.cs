using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ExplosionBallScript : MonoBehaviour {
	public AudioSource AS;
	public AudioClip ExplosionSound;
	public float ExpurosionForce;
	public float AtractionForce;
	ParticleSystem pomf;
	bool ammo = true;
	public bool isAbsorbing;
	KeyCode Activate;
	Rigidbody rigi;
	// Use this for initialization
	void Start () {
		AS = GetComponent<AudioSource> ();
		rigi = GetComponent<Rigidbody> ();
		Activate = GetComponent<AllBallsNeedThis> ().Activate;
		pomf = GameObject.Find ("Pomf").GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		pomf.gameObject.transform.position = transform.position;
		if (Input.GetKeyDown (Activate) && !GetComponent<AllBallsNeedThis> ().isWating && ammo) {
			rigi.AddForce (new Vector3 (0f, ExpurosionForce, 0f), ForceMode.Impulse);
			AS.PlayOneShot (ExplosionSound);
			ammo = false;
			pomf.Play ();
		}
	}

	void OnTriggerStay(Collider _col)
	{
		if (_col.tag == "Gball" && GetComponent<AllBallsNeedThis> ().isWating && isAbsorbing) {
			if (_col.gameObject.GetComponent<AllBallsNeedThis> ().beingAttractedExpl) {
				_col.GetComponent<Rigidbody> ().AddForce (Vector3.one - (_col.transform.position - transform.position) * AtractionForce, ForceMode.Acceleration);
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
