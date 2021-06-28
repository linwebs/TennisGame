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
	Vector3 pos_player;

	void Start() {
		anim = GetComponent<Animator>();
		anim.Play("stand");
		swing_ball = false;
	}

	void Update() {
		pos_o = transform.position;
		pos_ball = ball.transform.position;
		pos_player = Player.transform.position;
		pos_n.x = pos_ball.x + 1.0f;
		pos_n.y = pos_o.y;
		pos_n.z = pos_ball.z - 1.5f;

		Debug.Log("pos_ball {x:" + pos_ball.x + ", y:" + pos_ball.y + ", z:" + pos_ball.z + "}");
		Debug.Log("pos_o {x:" + pos_o.x + ", y:" + pos_o.y + ", z:" + pos_o.z + "}");
		//Debug.Log("pos_n {x:" + pos_n.x + ", y:" + pos_n.y + ", z:" + pos_n.z + "}");

		float step = move_speed * Time.deltaTime;

		if ((pos_ball.z - pos_ball_last.z) > 0.03f && pos_ball.z < 12.4f && !swing_ball) {
			if(pos_o.z > 1.0f) {
				transform.position = Vector3.MoveTowards(pos_o, pos_n, step);
				anim.Play("running");
			}
		}

		float dist_ball_computer = Mathf.Abs(pos_ball.z - pos_o.z);
		if (dist_ball_computer < 1.0f && !swing_ball) {
			Debug.Log("swing");
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
