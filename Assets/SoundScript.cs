using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundScript : MonoBehaviour {
	public AudioSource AS;
	public AudioClip Music;

	void Start () {
		AS.GetComponent<AudioSource> ();
		AS.PlayOneShot (Music);
	}
}
