using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
	public Animator anim;
	float speed;
	bool swing_ball;
	void Start() {
		anim = this.GetComponent<Animator>();
		anim.Play("stand");
		speed = 3f;
		swing_ball = false;
	}

	void Update() {
		// 前
		if (Input.GetKey(KeyCode.W)) {
			if (transform.position.z < -1.0f && !swing_ball) {
				transform.Translate(new Vector3(0, 0, speed * Time.deltaTime), Space.Self);
				anim.Play("running");
			}
		}
		// 後
		if (Input.GetKey(KeyCode.S)) {
			if (transform.position.z > -12.4f && !swing_ball) {
				transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime), Space.Self);
				anim.Play("running");
			}
		}
		// 左
		if (Input.GetKey(KeyCode.A)) {
			if (transform.position.x > -6.4f && !swing_ball) {
				this.transform.Translate(Vector3.right * -speed * Time.deltaTime);
				anim.Play("running");
			}
		}
		// 右
		if (Input.GetKey(KeyCode.D)) {
			if (transform.position.x < 6.4f && !swing_ball) {
				this.transform.Translate(Vector3.right * speed * Time.deltaTime);
				anim.Play("running");
			}
		}

		if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)) {
			anim.Play("stand");
		}

		if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.Space)) {
			anim.Play("swing");
			swing_ball = true;
			StartCoroutine(swing_ball_timer());
		}
	}
	IEnumerator swing_ball_timer() {
		yield return new WaitForSeconds(1.0f);
		swing_ball = false;
	}
}
