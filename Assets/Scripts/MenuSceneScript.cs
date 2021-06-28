using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneScript : MonoBehaviour {
	public GameObject GameScene;
	public GameObject Menu;

	void Start() {
		Screen.SetResolution(1600, 900, false);

	}

	void Update() {

	}
	public void ContinueBtnClick() {
		int state = GameScene.GetComponent<GameSceneScript>().game_state;

		if (state == 0) {
			Menu.SetActive(false);
			GameScene.GetComponent<GameSceneScript>().game_state = 1;
		}
	}
	public void MainPageBtnClick() {
		SceneManager.LoadSceneAsync(0);
	}
}
