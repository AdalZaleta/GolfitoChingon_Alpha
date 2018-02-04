using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlinkBallScript : MonoBehaviour {

	public float BlinkDistance;
	public KeyCode Activate;
	Rigidbody rigi;
	// Use this for initialization
	void Start () {
		rigi = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (Activate)) {
			transform.Translate (rigi.velocity.normalized.x * BlinkDistance,
				rigi.velocity.normalized.y * BlinkDistance,
				rigi.velocity.normalized.z * BlinkDistance,
				Space.World); 
			
		}
	}
}
