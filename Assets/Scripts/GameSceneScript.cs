using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneScript : MonoBehaviour {
	void Start() {
		Screen.SetResolution(1600, 900, false);

	}

	void Update() {

	}
	public void MenuBtnClick() {
		SceneManager.LoadSceneAsync(2);
	}
}
