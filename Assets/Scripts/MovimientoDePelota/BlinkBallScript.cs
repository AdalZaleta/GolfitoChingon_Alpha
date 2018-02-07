using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BlinkBallScript : MonoBehaviour {
	public AudioSource AS;
	public AudioClip BlinkSound;
	public float BlinkDistance;
	KeyCode Activate;
	public GameObject Trap;
	Rigidbody rigi;
	ParticleSystem Vortex;
	// Use this for initialization
	void Start () {
		AS = GetComponent<AudioSource>();
		rigi = GetComponent<Rigidbody> ();
		Activate = GetComponent<AllBallsNeedThis> ().Activate;
		Vortex = GameObject.Find ("Vortex").GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vortex.gameObject.transform.position = transform.position;
		if (Input.GetKeyDown (Activate) && !GetComponent<AllBallsNeedThis> ().isWating) {
			StartCoroutine (prepareBlink ());
		}
	}

	IEnumerator prepareBlink(){
		Vortex.Play ();
		yield return new WaitForSeconds(0.75f);
		Blink();
		Vortex.Stop();
		Vortex.Clear();
	}

	void Blink(){
		AS.PlayOneShot (BlinkSound);
		GameObject go = Instantiate (Trap);
		go.transform.position = transform.position;
		go.GetComponent<BlinkBallPassive> ().BlinkTrapParent = gameObject;
		transform.Translate (rigi.velocity.normalized.x * BlinkDistance,
		rigi.velocity.normalized.y * BlinkDistance,
		rigi.velocity.normalized.z * BlinkDistance,
		Space.World); 
	}

	public void StartTurn(){
		GetComponent<AllBallsNeedThis> ().beingAttractedExpl = true;
		GetComponent<AllBallsNeedThis> ().triggerInvBlink = false;
		gameObject.SetActive (true);
	}
}
