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
	public float FuerzaPersonaje;
	public float PresicionPersonaje;
	public bool done;
	void Start()
	{
		AS = GetComponent<AudioSource> ();
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
}
