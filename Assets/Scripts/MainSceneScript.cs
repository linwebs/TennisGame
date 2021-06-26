using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneScript : MonoBehaviour {
	void Start() {
		Screen.SetResolution(1600, 900, false);

	}

	void Update() {

	}
	public void StartGameBtnClick() {
		SceneManager.LoadSceneAsync(1);
	}
	public void EndGameBtnClick() {
		Application.Quit();
	}
}
