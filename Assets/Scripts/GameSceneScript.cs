using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneScript : MonoBehaviour {
	public GameObject Menu;
	public int game_state;

	// 局數
	int board;

	void Start() {
		Screen.SetResolution(1600, 900, false);
		game_state = 1;
	}

	void Update() {

	}
	public void MenuBtnClick() {
		game_state = 0;
		Menu.SetActive(true);
	}
}
