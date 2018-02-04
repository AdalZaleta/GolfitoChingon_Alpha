using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerPhase : MonoBehaviour {

	public GameObject Player1, Player2, Player3;
	GameObject currentPlayer;
	public Canvas shootUI;
	public Camera cam;

	int phase;
	Vector3 direccion;
	float tiroFuerza;
	int fuerzaSliderDir;

	// Use this for initialization
	void Start () {
		currentPlayer = Player1;
		phase = 0;
	}

	// Update is called once per frame
	void Update () {
		switch (phase) {
		case 0:
			cam.transform.position = currentPlayer.transform.position - Vector3.zero;
			break;
		}
	}
}
