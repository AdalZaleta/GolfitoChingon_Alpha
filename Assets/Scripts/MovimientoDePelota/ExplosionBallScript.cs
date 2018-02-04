using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBallScript : MonoBehaviour {

	public float ExpurosionForce;
	public float AtractionForce;
	KeyCode Activate;
	Rigidbody rigi;
	// Use this for initialization
	void Start () {
		rigi = GetComponent<Rigidbody> ();
		Activate = GetComponent<AllBallsNeedThis> ().Activate;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (Activate) && !GetComponent<AllBallsNeedThis> ().isWating) {
			rigi.AddForce (new Vector3 (0f, ExpurosionForce, 0f), ForceMode.Impulse);
		}
	}

	void OnTriggerStay(Collider _col)
	{
		if (_col.tag == "Gball") {
			if(_col.gameObject.GetComponent<AllBallsNeedThis> ().beingAttractedExpl)
				_col.GetComponent<Rigidbody>().AddForce(Vector3.one-(_col.transform.position - transform.position) * AtractionForce, ForceMode.Acceleration);
		}
	}

	void OnCollisionEnter(Collision _col)
	{
		if (_col.gameObject.tag == "Gball") {
			_col.rigidbody.velocity = Vector3.zero;
			_col.gameObject.GetComponent<AllBallsNeedThis> ().beingAttractedExpl = false;
		}
	}
}
