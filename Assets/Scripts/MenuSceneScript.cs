using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuSceneScript : MonoBehaviour {
	public GameObject GameScene;
	public GameObject PlayerRacket;
	public GameObject ComputerRacket;
	public GameObject Ball;
	public GameObject Player;
	public BoxCollider PlayerRacketCollider;
	public BoxCollider ComputerRacketCollider;
	public SphereCollider BallCollider;
	public Rigidbody BallRigidbody;
	public Text PlayerRacketBtnText;
	public Text ComputerRacketBtnText;
	public Text BallSizeBtnText;
	public Text PlayerSpeedBtnText;
	public GameObject Menu;

	int player_racket_size = 1;
	int computer_racket_size = 1;
	int ball_size = 1;

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

	public void PlayerRacketBtnClick() {
		Debug.Log("PlayerRacketCollider: " + PlayerRacketCollider.size.x);
		if (player_racket_size == 1) {
			PlayerRacket.transform.localScale = new Vector3(0.032f, 0.032f, 0.032f);
			PlayerRacketBtnText.text = "再放大";
			player_racket_size = 2;
			PlayerRacketCollider.size = new Vector3(62.1f, 62.1f, 62.1f);
		} else if (player_racket_size == 2) {
			PlayerRacket.transform.localScale = new Vector3(0.064f, 0.064f, 0.064f);
			PlayerRacketBtnText.text = "縮小";
			player_racket_size = 3;
			PlayerRacketCollider.size = new Vector3(93.45f, 93.4f, 93.4f);
		} else if (player_racket_size == 3) {
			PlayerRacket.transform.localScale = new Vector3(0.016f, 0.016f, 0.016f);
			PlayerRacketBtnText.text = "放大";
			player_racket_size = 1;
			PlayerRacketCollider.size = new Vector3(31.15f, 31.15f, 31.15f);
		}
	}

	public void ComputerRacketBtnClick() {
		if (computer_racket_size == 1) {
			ComputerRacket.transform.localScale = new Vector3(0.032f, 0.032f, 0.032f);
			ComputerRacketBtnText.text = "再放大";
			computer_racket_size = 2;
			ComputerRacketCollider.size = new Vector3(62.1f, 62.1f, 62.1f);
		} else if (computer_racket_size == 2) {
			ComputerRacket.transform.localScale = new Vector3(0.064f, 0.064f, 0.064f);
			ComputerRacketBtnText.text = "縮小";
			computer_racket_size = 3;
			ComputerRacketCollider.size = new Vector3(93.45f, 93.4f, 93.4f);
		} else if (computer_racket_size == 3) {
			ComputerRacket.transform.localScale = new Vector3(0.016f, 0.016f, 0.016f);
			ComputerRacketBtnText.text = "放大";
			computer_racket_size = 1;
			ComputerRacketCollider.size = new Vector3(31.15f, 31.15f, 31.15f);
		}
	}

	public void BallSizeBtnClick() {
		if (ball_size == 1) {
			Ball.transform.localScale = new Vector3(12.0f, 12.0f, 12.0f);
			BallSizeBtnText.text = "縮小";
			ball_size = 2;
			BallCollider.radius = 0.02f;
			BallRigidbody.mass = 0.5f;
		} else if (ball_size == 2) {
			Ball.transform.localScale = new Vector3(6.0f, 6.0f, 6.0f);
			BallSizeBtnText.text = "放大";
			ball_size = 1;
			BallCollider.radius = 0.01f;
			BallRigidbody.mass = 1.0f;
		}
	}

	public void PlayerMoveSpeedClick() {
		float player_move_speed = Player.GetComponent<PlayerScript>().speed;
		if (player_move_speed == 3.0f) {
			Player.GetComponent<PlayerScript>().speed = 6.0f;
			PlayerSpeedBtnText.text = "再加快";
		} else if (player_move_speed == 6.0f) {
			Player.GetComponent<PlayerScript>().speed = 9.0f;
			PlayerSpeedBtnText.text = "放慢";
		} else if (player_move_speed == 9.0f) {
			Player.GetComponent<PlayerScript>().speed = 3.0f;
			PlayerSpeedBtnText.text = "加快";
		}
	}
}
