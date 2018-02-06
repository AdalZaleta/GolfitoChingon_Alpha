using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkBallPassive : MonoBehaviour {

	public float revertSeconds;
	public GameObject BlinkTrapParent;

	void Update(){
		
	}

	void OnTriggerEnter(Collider _col)
	{
		print ("Entro al trigger");
		if(_col.tag == "Gball")
		{
			if(!_col.GetComponent<AllBallsNeedThis>().triggerInvBlink){
				float x = _col.transform.position.x;
				float y = _col.transform.position.y;
				float z = _col.transform.position.z;
				StartCoroutine (blinkBackTrap (_col, x, y, z));
				print (_col.transform.position);
			}
		}
	}

	IEnumerator blinkBackTrap(Collider _col, float _x, float _y, float _z){
		print ("Entro al IEnumerator");
		yield return new WaitForSeconds (revertSeconds);
		_col.transform.Translate (new Vector3 (-_col.transform.position.x + _x, -_col.transform.position.y + _y, -_col.transform.position.z + _z), Space.World);
		_col.GetComponent<AllBallsNeedThis> ().BlinkInv ();
		Destroy(gameObject);
	}
}
