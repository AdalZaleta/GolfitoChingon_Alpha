using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ExplosionBallScript : MonoBehaviour {
	public AudioSource AS;
	public AudioClip ExplosionSound;
	public float ExpurosionForce;
<<<<<<< HEAD
	public float AtractionForce;
	ParticleSystem pomf;
=======
>>>>>>> 1f5b75e1bd170cf82f8ed61c473460ab930530c0
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
		if (Input.GetKeyDown (Activate) && !GetComponent<AllBallsNeedThis> ().isWating && ammo) {
			rigi.AddForce (new Vector3 (0f, ExpurosionForce, 0f), ForceMode.Impulse);
			AS.PlayOneShot (ExplosionSound);
			ammo = false;
			pomf.Play ();
		}
	}

	void OnCollisionEnter(Collision _col)
	{
		print ("something colided: " + _col.gameObject.tag);
		if (_col.gameObject.tag == "Gball" && GetComponent<AllBallsNeedThis>().isWating) {
			stopCollided (_col);
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

	IEnumerator stopCollided(Collision _col){
		yield return null;
		_col.gameObject.GetComponent<Rigidbody> ().velocity = Vector3.zero;
	}
}
