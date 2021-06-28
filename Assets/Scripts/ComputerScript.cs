using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerScript : MonoBehaviour {
	public Animator anim;
	public GameObject ball;
	float move_speed = 10.0f;

	Vector3 pos_o;
	Vector3 pos_n;
	Vector3 pos_ball;

	void Start() {
		anim = GetComponent<Animator>();
		anim.Play("stand");
	}

	void Update() {
		pos_o = transform.position;
		pos_ball = ball.transform.position;
		pos_n.x = pos_ball.x - 0.0f;
		pos_n.y = pos_o.y;
		pos_n.z = pos_ball.z;
		float step = move_speed * Time.deltaTime;
		if (pos_ball.z > 0.0f && pos_ball.z < 12.4f) {
			//Debug.Log("pos_ball {x:" + pos_ball.x + ", y:" + pos_ball.y + ", z:" + pos_ball.z + "}");
			//Debug.Log("pos_o {x:" + pos_o.x + ", y:" + pos_o.y + ", z:" + pos_o.z + "}");
			//Debug.Log("pos_n {x:" + pos_n.x + ", y:" + pos_n.y + ", z:" + pos_n.z + "}");
			transform.position = Vector3.MoveTowards(pos_o, pos_n, step);
			anim.Play("running");
		}
	}
}
