using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllBallsNeedThis : MonoBehaviour {

	public float invulerabilityTime;
	public bool triggerInvBlink = false;

	public void BlinkInv (){
		triggerInvBlink = true;
	}

	IEnumerator blinkInv(float time){
		yield return new WaitForSeconds (time);
		triggerInvBlink = false;
	}
}
