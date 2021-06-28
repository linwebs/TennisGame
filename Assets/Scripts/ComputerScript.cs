using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerScript : MonoBehaviour {
	public Animator anim;
	public GameObject ball;
	public GameObject Player;
	float move_speed = 10.0f;
	bool swing_ball;

	Vector3 pos_o;
	Vector3 pos_n;
	Vector3 pos_ball;
	Vector3 pos_ball_last;
	Vector3 pos_player_swing;
	Vector3 pos_player;

	void Start() {
		anim = GetComponent<Animator>();
		anim.Play("stand");
		swing_ball = false;
		pos_player_swing.z = 10.0f;
	}

	void Update() {
		pos_o = transform.position;
		pos_ball = ball.transform.position;
		pos_player = Player.transform.position;
		pos_n.x = pos_ball.x + 1.0f;
		if(pos_n.x > 12.0f) {
			pos_n.x = 12.0f;
		} else if (pos_n.x < -12.0f) {
			pos_n.x = -12.0f;
		}
		pos_n.y = pos_o.y;
		pos_n.z = pos_player_swing.z + 10.5f;

		//Debug.Log("pos_ball {x:" + pos_ball.x + ", y:" + pos_ball.y + ", z:" + pos_ball.z + "}");
		//Debug.Log("pos_o {x:" + pos_o.x + ", y:" + pos_o.y + ", z:" + pos_o.z + "}");
		//Debug.Log("pos_n {x:" + pos_n.x + ", y:" + pos_n.y + ", z:" + pos_n.z + "}");
		//Debug.Log("pos_ball: " + pos_ball);
		//Debug.Log("pos_player: " + pos_player);
		//Debug.Log("pos_n: " + pos_n);


		if (Input.GetKey(KeyCode.Space)) {
			pos_player_swing = Player.transform.position;
		}

		float step = move_speed * Time.deltaTime;

		/*
		if (anim.GetCurrentAnimatorStateInfo(0).nameHash == Animator.StringToHash("Base Layer.stand")) {
			Debug.Log("AnimatorState: stand");
		} else if (anim.GetCurrentAnimatorStateInfo(0).nameHash == Animator.StringToHash("Base Layer.running")) {
			Debug.Log("AnimatorState: stand");
		} else if (anim.GetCurrentAnimatorStateInfo(0).nameHash == Animator.StringToHash("Base Layer.swing")) {
			Debug.Log("AnimatorState: swing");
		}
		*/

		if (((pos_ball.z - pos_player.z) <= 0.18f || (pos_ball.z - pos_player.z) >= 0.22f) && !swing_ball) {
			//Debug.Log("move: 1");
			if (pos_o.z > 1.0f && pos_ball.z < 12.4f) {
				// 電腦沒有太前面 & 球的位置沒有太後面
				//Debug.Log("running");
				transform.position = Vector3.MoveTowards(pos_o, pos_n, step);
				anim.Play("running");
			}
		}

		float dist_ball_computer = Mathf.Abs(pos_ball.z - pos_o.z);
		if (dist_ball_computer < 0.5f && !swing_ball) {
			//Debug.Log("swing");
			StartCoroutine(swing_ball_timer());
			anim.Play("swing");
			swing_ball = true;
		}

		pos_ball_last = ball.transform.position;
	}
	IEnumerator swing_ball_timer() {
		yield return new WaitForSeconds(1.0f);
		swing_ball = false;
	}
}
