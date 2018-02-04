using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour {
	public static int PlayerOne;
	public static int PlayerTwo;
	public static int PlayerThree;
	public static int characterSelected;

	void Start()
	{
		PlayerOne = 1;
		PlayerTwo = 2;
		PlayerThree = 3;
	}

	void Update()
	{

	}

	public void LoadGameStarter(int sceneStarter )
	{
		SceneManager.LoadScene (sceneStarter);
	}
}
