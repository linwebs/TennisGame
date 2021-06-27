using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
	public Animator anim;
	float speed;
	void Start() {
		anim = this.GetComponent<Animator>();
		anim.Play("stand");
		speed = 3f;
	}

	void Update() {
		if (Input.GetKey(KeyCode.W)) {
			transform.Translate(new Vector3(0, 0, speed * Time.deltaTime), Space.Self);  //前
			anim.Play("running");
		}
		if (Input.GetKey(KeyCode.S)) {
			transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime), Space.Self);  //後
			anim.Play("running");
		}
		if (Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.LeftArrow)) //左
		{
			this.transform.Translate(Vector3.right * -speed * Time.deltaTime);
			anim.Play("running");
		}
		if (Input.GetKey(KeyCode.D) | Input.GetKey(KeyCode.RightArrow)) //右
		{
			this.transform.Translate(Vector3.right * speed * Time.deltaTime);
			anim.Play("running");
		}
		if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)) {
			anim.Play("stand");
		}
		if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.Space)) {
			anim.Play("swing");
		}
	}
}
