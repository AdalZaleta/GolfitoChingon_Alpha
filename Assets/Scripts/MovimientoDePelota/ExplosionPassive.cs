using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionPassive : MonoBehaviour {

	public float AtractionForce;

	void OnTriggerStay(Collider _col)
	{
		if (_col.tag == "Gball" && GetComponentInParent<AllBallsNeedThis> ().isWating && GetComponentInParent<ExplosionBallScript>().isAbsorbing) {
			if (_col.gameObject.GetComponentInParent<AllBallsNeedThis> ().beingAttractedExpl) {
				_col.GetComponent<Rigidbody> ().AddForce ((_col.transform.position - transform.position) * AtractionForce * (1/(_col.transform.position - transform.position).magnitude), ForceMode.Acceleration);
				print ("atracted");
			}
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
