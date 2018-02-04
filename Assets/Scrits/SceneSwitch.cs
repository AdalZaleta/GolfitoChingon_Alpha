using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour {
	public int characterSelected;
	public void LoadGameStarter(int sceneStarter )
	{
		SceneManager.LoadScene (sceneStarter);
	}
}
