using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerPhase : MonoBehaviour {

	public GameObject Player1, Player2, Player3;
	GameObject currentPlayer;
	public Canvas shootUI;
	public Slider fuerzaSlider;
	public Camera cam;
	public KeyCode Right;
	public KeyCode Left;
	public KeyCode Up;
	public KeyCode Down;
	public KeyCode Go;

	int phase;
	Vector3 direccion;
	public float offsetCamMag;
	float tiroFuerza;
	int fuerzaSliderDir = 1;
	public float yOffset;

	// Use this for initialization
	void Start () {
		currentPlayer = Player1;
		direccion = Vector3.forward;
		phase = 0;
	}

	// Update is called once per frame
	void Update () {
		switch (phase) {
		case 0:
			shootUI.enabled = false;
			cam.transform.position = currentPlayer.transform.position - new Vector3 (direccion.x, direccion.y + yOffset, direccion.z) * offsetCamMag;
			cam.transform.LookAt (currentPlayer.transform.position);
			if (Input.GetKey (Left)) {
				direccion = Quaternion.AngleAxis (25 * Time.deltaTime, Vector3.up) * direccion;
			}
			if (Input.GetKey (Right)) {
				direccion = Quaternion.AngleAxis (-25 * Time.deltaTime, Vector3.up) * direccion;
			}
			if (Input.GetKey (Up)) {
				direccion = Quaternion.AngleAxis (25 * Time.deltaTime, Vector3.Cross (Vector3.up, direccion)) * direccion;
			}
			if (Input.GetKey (Down)) {
				direccion = Quaternion.AngleAxis (-25 * Time.deltaTime, Vector3.Cross (Vector3.up, direccion)) * direccion;
			}
			if (Input.GetKey (Go)) {
				phase = 1;
			}
			break;
		case 1:
			shootUI.enabled = true;
			fuerzaSlider.value += fuerzaSliderDir * currentPlayer.GetComponent<AllBallsNeedThis>().PresicionPersonaje * Time.deltaTime;
			if (fuerzaSlider.value >= 1)
				fuerzaSliderDir = -1;

			if (fuerzaSlider.value <= 0)
				fuerzaSliderDir = 1;

			break;	
		}
	}
}
