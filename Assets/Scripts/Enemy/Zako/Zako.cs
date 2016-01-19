﻿using UnityEngine;
using System.Collections;

public class Zako : Enemy{

	// Use this for initialization
	protected override void Start () {
		hp = 5;
		speed = 0.3f;
		anim = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		Move(speed,Vector3.forward);
	}
}