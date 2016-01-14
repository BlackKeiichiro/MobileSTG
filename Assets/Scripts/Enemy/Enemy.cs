﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public abstract class Enemy : MonoBehaviour {
	protected float speed = 0;
	public int hp = 0;
	protected Rigidbody _rigidbody;
	protected Animator anim;
	protected virtual void Start(){}

	void OnTriggerEnter(Collider c){

	}

	public void Damage(){
		anim.SetTrigger("damage_flag");
	}

	protected void Move(float speed,Vector3 vector){
		this.transform.localPosition -= speed * vector;
	}
}