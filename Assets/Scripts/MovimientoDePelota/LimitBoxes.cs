using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitBoxes : MonoBehaviour {

	public bool currentHole;
	void OnTriggerExit(Collider _col){
		if (_col.gameObject.CompareTag ("Gball") && currentHole) {
			_col.GetComponent<AllBallsNeedThis> ().OutOfBounds ();
		}
	}
}
