using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerScript : MonoBehaviour {
	public Animator anim;

	void Start() {
		anim = this.GetComponent<Animator>();
		anim.Play("stand");

	}

	void Update() {

	}
}
