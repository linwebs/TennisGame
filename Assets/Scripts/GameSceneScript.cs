using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneScript : MonoBehaviour {
	public GameObject GameTime;
	public GameObject BoardTime;

	// 局數
	int board;

	// 整局計時器
	float timer_board;

	// 遊戲計時器
	float timer_game;

	void Start() {
		Screen.SetResolution(1600, 900, false);
		timer_board = Time.time;
	}

	void Update() {
		int t_board = Mathf.FloorToInt(timer_board);

	}
	public void MenuBtnClick() {
		SceneManager.LoadSceneAsync(2);
	}
}
