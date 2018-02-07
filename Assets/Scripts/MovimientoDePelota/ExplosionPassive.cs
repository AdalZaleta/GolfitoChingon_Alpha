using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionPassive : MonoBehaviour {

	public float AtractionForce;
	ParticleSystem Shockwave;
	void OnTriggerStay(Collider _col)
	{
		if (_col.tag == "Gball" && GetComponentInParent<AllBallsNeedThis> ().isWating && GetComponentInParent<ExplosionBallScript> ().isAbsorbing) {
			if (_col.gameObject.GetComponentInParent<AllBallsNeedThis> ().beingAttractedExpl) {
				_col.GetComponent<Rigidbody> ().AddForce (-(transform.position - _col.transform.position) * (AtractionForce), ForceMode.Acceleration);
			}
		}
	}

	// Use this for initialization
	void Start () {
		Shockwave = GameObject.Find ("Shockwave").GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponentInParent<ExplosionBallScript> ().isAbsorbing && !Shockwave.isPlaying) {
			Shockwave.Play ();
			Debug.Log ("shocwave");
		} 
		if (Shockwave.isPlaying && !GetComponentInParent<ExplosionBallScript> ().isAbsorbing){
			Shockwave.Stop ();
			Shockwave.Clear ();
			Debug.Log ("stop");
		}
	}
}
