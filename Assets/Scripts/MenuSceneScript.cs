using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneScript : MonoBehaviour {
	void Start() {
		Screen.SetResolution(1600, 900, false);

	}

	void Update() {

	}
	public void ContinueBtnClick() {
		SceneManager.LoadSceneAsync(1);
	}
	public void MainPageBtnClick() {
		SceneManager.LoadSceneAsync(0);
	}
}
