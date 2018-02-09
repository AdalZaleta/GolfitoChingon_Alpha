using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour {

	public Text Exp;
	public int Puntoexp;
	public Text Blink;
	public int Puntoblink;
	public Text Gravity;
	public int Puntogravity;
	public GameObject CrownBlink;
	public GameObject CrownExp;
	public GameObject CrownGrav;

	public void SumarPuntos(GameObject _pelota)
	{
		if(_pelota.name == "Explosion_Ball")
		{
			Puntoexp += 1;
			Exp.text = Puntoexp.ToString ();
		}
		if(_pelota.name == "Blink_Ball")
		{
			Puntoblink += 1;
			Blink.text = Puntoblink.ToString ();
		}
		if(_pelota.name == "Gravity_Ball")
		{
			Puntogravity += 1;
			Gravity.text = Puntogravity.ToString ();
		}
	}

	public void Winner()
	{
		if (Puntoexp < Puntoblink && Puntoexp < Puntogravity) {
			CrownExp.SetActive (true);
		}
		if (Puntoblink < Puntoexp && Puntoblink < Puntogravity) {
			CrownBlink.SetActive (true);
		}
		if (Puntogravity < Puntoexp && Puntogravity < Puntoblink) {
			CrownGrav.SetActive (true);
		}
	}
}
