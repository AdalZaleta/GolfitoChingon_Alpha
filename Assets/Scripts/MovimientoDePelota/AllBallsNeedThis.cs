using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllBallsNeedThis : MonoBehaviour {

	public float invulerabilityTime;
	public bool triggerInvBlink = false;
	public bool beingAttractedExpl = true;
	public bool isWating;
	public KeyCode Activate;
	public float FuerzaPersonaje;
	public float PresicionPersonaje;
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
