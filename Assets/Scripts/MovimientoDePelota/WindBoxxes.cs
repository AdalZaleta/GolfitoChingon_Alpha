using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindBoxxes : MonoBehaviour {

	public float Fuerza;

	void OnTriggerStay(Collider _col){
		if (_col.CompareTag ("Gball")) {
			_col.GetComponent<Rigidbody> ().AddForce (Vector3.left * Time.deltaTime * Fuerza, ForceMode.Force);
		}
	}
}
