using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeScript : MonoBehaviour {
	public Text GameTime;
	public Text BoardTime;
	public GameObject GameScene;

	float timer_init;
	int game_state;

	int hou;
	int min;
	int sec;

	string hou_s;
	string min_s;
	string sec_s;

	void Start() {
		timer_init = Time.time;
	}

	// Update is called once per frame
	void Update() {
		game_state = GameScene.GetComponent<GameSceneScript>().game_state;

		if (game_state == 1) {

			// 遊戲開始到現在的時間
			int time_diff = Mathf.FloorToInt(Time.time - timer_init);

			// 計算時間
			if (time_diff >= 3600) {
				hou = time_diff / 3600;
				min = (time_diff - hou * 3600) / 60;
				sec = time_diff - hou * 3600 - min * 60;
			} else if (time_diff >= 60) {
				hou = 0;
				min = time_diff / 60;
				sec = time_diff - min * 60;
			} else {
				hou = 0;
				min = 0;
				sec = time_diff;
			}

			// 轉換小時為文字
			if (hou >= 10) {
				hou_s = hou.ToString();
			} else {
				hou_s = "0" + hou.ToString();
			}

			// 轉換分鐘為文字
			if (min >= 10) {
				min_s = min.ToString();
			} else {
				min_s = "0" + min.ToString();
			}

			// 轉換秒數為文字
			if (sec >= 10) {
				sec_s = sec.ToString();
			} else {
				sec_s = "0" + sec.ToString();
			}

			GameTime.text = hou_s + ":" + min_s + ":" + sec_s;
		}
	}
}
