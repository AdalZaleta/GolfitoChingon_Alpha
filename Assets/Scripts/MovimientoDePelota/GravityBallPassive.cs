using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBallPassive : MonoBehaviour {

	ParticleSystem SuperGrav;
	GameObject Ball;
	void Start(){
		Ball = GameObject.Find ("Gravity_Ball");
		SuperGrav = GameObject.Find ("Gravity").GetComponent<ParticleSystem> ();
	}

	void Update(){
		SuperGrav.transform.position = Ball.transform.position;

		if (Ball.GetComponent<AllBallsNeedThis> ().isWating && !SuperGrav.isPlaying)
			SuperGrav.Play ();
		else if (!Ball.GetComponent<AllBallsNeedThis> ().isWating && SuperGrav.isPlaying)
		{
			SuperGrav.Stop ();
			SuperGrav.Clear ();
		}
			
	}

	void OnTriggerStay(Collider _col){
		if (_col.CompareTag ("Gball") && GetComponentInParent<AllBallsNeedThis>().isWating) {
			_col.GetComponent<Rigidbody> ().AddForce (Vector3.down * GetComponentInParent<GravityBallScript>().GravityEmpowerRatio, ForceMode.Acceleration);
		}
	}
}
