using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerScript : MonoBehaviour {
	public Animator anim;
	public GameObject ball;
	public GameObject Player;
	float move_speed = 10.0f;
	bool swing_ball;			// 是否正在擊球

	Vector3 pos_o;				// 電腦目前的位置
	Vector3 pos_n;				// 電腦計算後的新位置
	Vector3 pos_ball;			// 球目前的位置
	Vector3 pos_ball_last;		// 球之前的位置
	Vector3 pos_player_swing;   // 玩家發球時的位置
	Vector3 pos_player;			// 玩家目前的位置

	void Start() {
		anim = GetComponent<Animator>();
		anim.Play("stand");
		swing_ball = false;
		pos_player_swing.z = 10.0f;
	}

	void FixedUpdate() {
		pos_o = transform.position;
		pos_ball = ball.transform.position;
		pos_player = Player.transform.position;

		//Debug.Log("pos_ball: " + pos_ball);
		//Debug.Log("pos_player: " + pos_player);
		//Debug.Log("pos_n: " + pos_n);


		if (Input.GetKey(KeyCode.Space)) {
			pos_player_swing = Player.transform.position;
		}

		float step = move_speed * Time.deltaTime;

		/*
		// 查看電腦目前的動作
		if (anim.GetCurrentAnimatorStateInfo(0).nameHash == Animator.StringToHash("Base Layer.stand")) {
			Debug.Log("AnimatorState: stand");
		} else if (anim.GetCurrentAnimatorStateInfo(0).nameHash == Animator.StringToHash("Base Layer.running")) {
			Debug.Log("AnimatorState: stand");
		} else if (anim.GetCurrentAnimatorStateInfo(0).nameHash == Animator.StringToHash("Base Layer.swing")) {
			Debug.Log("AnimatorState: swing");
		}
		*/

		// 球和玩家距離的位置，計算玩家是否發球用的
		float dist_ball_computer = Mathf.Abs(pos_ball.z - pos_o.z);

		if (dist_ball_computer < 0.5f && !swing_ball) {
			// 擊球中

			//Debug.Log("swing");
			StartCoroutine(swing_ball_timer());
			anim.Play("swing");
			swing_ball = true;
		} else if ((pos_ball.z - pos_player.z) >= 0.31f && !swing_ball) {
			// 對方發球了

			//Debug.Log("move: 1");
			if (pos_o.z > 1.0f && pos_ball.z < 12.4f) {
				// 電腦沒有太前面 & 球的位置沒有太後面
				//Debug.Log("running");

				pos_n.x = pos_ball.x + 1.0f;
				if (pos_n.x > 12.0f) {
					pos_n.x = 12.0f;
				} else if (pos_n.x < -12.0f) {
					pos_n.x = -12.0f;
				}
				pos_n.y = pos_o.y;
				pos_n.z = pos_player_swing.z + 10.5f;
				transform.position = Vector3.MoveTowards(pos_o, pos_n, step);
				anim.Play("running");
			}
		} else if(!swing_ball) {
			// 對方還沒發球

			pos_n.x = pos_ball.x + 1.0f;
			if (pos_n.x > 6.5f) {
				pos_n.x = 6.5f;
			} else if (pos_n.x < -6.0f) {
				pos_n.x = -6.0f;
			}
			pos_n.y = pos_o.y;
			pos_n.z = 10.0f;
			//Debug.Log("n_x: " + pos_n.x);
			//Debug.Log("o_x: " + pos_o.x);
			if (pos_o.x != pos_n.x) {
				transform.position = Vector3.MoveTowards(pos_o, pos_n, step);
				anim.Play("running");
			} else {
				anim.Play("stand");
			}
		}

		pos_ball_last = ball.transform.position;
	}

	// 擊球結束後關閉發球狀態
	IEnumerator swing_ball_timer() {
		yield return new WaitForSeconds(1.0f);
		swing_ball = false;
	}
}
