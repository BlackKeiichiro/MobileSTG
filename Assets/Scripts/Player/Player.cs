﻿using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
	private Animator anim;
	private float speed = 10;
	private float vectorY = 1;
	private float hp = 10;
	private float maxhp = 10;
	private bool push;
	private bool shot;
	private Rigidbody playerbody;
	private Transform gunpoint;
	private GameObject bullet;
	private Vector3 init_pos;
	private Image hpUI;
	//Initialize
	void Awake(){
		init_pos = this.transform.position;
		bullet = Resources.Load("Player/Bullets") as GameObject;
		gunpoint = this.transform.FindChild("GunPoint");
		playerbody = this.GetComponent<Rigidbody>();
		anim = this.GetComponent<Animator>();
		hpUI = GameObject.Find("Hpbar").GetComponent<Image>();
	}

	IEnumerator Start(){
		while(true){
			if(shot){
				GameObject localbullet = Instantiate(bullet) as GameObject;
				localbullet.transform.position = gunpoint.position;
				localbullet.transform.rotation = this.transform.rotation;
				yield return new WaitForSeconds(0.1f);
			}else{
				yield return new WaitForSeconds(0.1f);
			}
		}
	}

	//Game Play
	void Update ()
	{
		CheckHp();
		float x = Input.GetAxis("Horizontal"); //Debug
		//float x = Input.acceleration.x;
		float y = (push)?vectorY:0;
		Vector3 direction = new Vector3(x, y , 0);
		Vector3 mypos = this.transform.position;

		if(!LimitedMove(this.transform.position)){
			playerbody.velocity = Vector3.zero;
			if(direction.sqrMagnitude > 0.1f){
				Vector3 shot_rotate = new Vector3(y,-x,0)*25;
				this.transform.rotation = Quaternion.Euler(-shot_rotate);
				mypos += direction * Time.deltaTime * speed;
			}else{
				this.transform.rotation = Quaternion.identity;
			}
		}else{
			playerbody.velocity = init_pos - this.transform.position;
		}
		this.transform.position = mypos;
	}

	void OnTriggerEnter(Collider c){
		int damage = 1;
		if(c.transform.CompareTag("Enemy") || c.transform.CompareTag("Obstacle")){
			Debug.Log("hit");
			anim.SetTrigger("Damage");
			hp -= damage;
		}
	}
	//Original Method

	void CheckHp(){
		if(hp < 0){
			Application.LoadLevel("Start");
			Debug.Log("GameOver");
		}
		hpUI.fillAmount = hp/maxhp;
	}

	//T or F for "Out of Area"
	bool LimitedMove(Vector3 ship_position){
		Vector3 pos_margin = Camera.main.WorldToViewportPoint(ship_position);
		pos_margin.z = ship_position.z;
		if(pos_margin.x >= 1 || pos_margin.x <= 0 || pos_margin.y >= 1 || pos_margin.y <= 0){
			return true;
		}
		return false;
	}

	public void PlayerDamage(int damage){
		hp -= damage;
		anim.SetTrigger("Damage");
	}

	//UI	
	public void PushingMove(int vector){
		vectorY = vector;
		push = true;
	}
	public void StopPushingMove(){
		push = false;
	}

	public void PushShot(){
		shot = true;
	}
	public void StopPushShot(){
		shot = false;
	}


}