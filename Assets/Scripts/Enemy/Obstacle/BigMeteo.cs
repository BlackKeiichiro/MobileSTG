﻿using UnityEngine;
using System.Collections;

public class BigMeteo : Enemy {
	// Use this for initialization
	protected override void Start () {
		hp = 50;
		speed = 0.2f;
		anim = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		Move(speed,Vector3.forward);
	}

}
