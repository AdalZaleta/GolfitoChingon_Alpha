using System.Collections;
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

	void Start()
	{
		AS = GetComponent<AudioSource> ();
	}

	void OnCollisionEnter (Collision _col)
	{
		if (_col.gameObject.CompareTag ("BlinkBall")) {
			AS.PlayOneShot (ChoquePelotaSFX);
		}
		if (_col.gameObject.CompareTag ("GavityBall")) {
			AS.PlayOneShot (ChoquePelotaSFX);
		}
		if (_col.gameObject.CompareTag ("ExplotionBall")) {
			AS.PlayOneShot (ChoquePelotaSFX);
		}
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
}
