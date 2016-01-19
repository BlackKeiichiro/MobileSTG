using UnityEngine;
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
	private int hp = 3;
	private bool push;
	private bool shot;
	private Rigidbody playerbody;
	private GameObject bullet;
	private Vector3 init_pos;
	//Initialize
	void Awake(){
		init_pos = this.transform.position;
		bullet = Resources.Load("Player/Bullets") as GameObject;
		playerbody = this.GetComponent<Rigidbody>();
		anim = this.GetComponent<Animator>();
	}

	IEnumerator Start(){
		while(true){
			if(shot){
				GameObject localbullet = Instantiate(bullet) as GameObject;
				localbullet.transform.position = this.transform.position;
				yield return new WaitForSeconds(0.05f);
			}else{
				yield return new WaitForSeconds(0.05f);
			}
		}
	}

	//Game Play
	void Update ()
	{
		float x = Input.GetAxis("Horizontal"); //Debug
		//float x = Input.acceleration.x;	
		float y = (push)?vectorY:0;
		Vector3 direction = new Vector3(x, y , 0);
		Vector3 mypos = this.transform.position;

		if(!LimitedMove(this.transform.position)){
			playerbody.velocity = Vector3.zero;
			if(direction.magnitude > 0.1){
				mypos += direction * Time.deltaTime * speed;
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

	//T or F for "Out of Area"
	bool LimitedMove(Vector3 ship_position){
		Vector3 pos_margin = Camera.main.WorldToViewportPoint(ship_position);
		pos_margin.z = ship_position.z;
		if(pos_margin.x >= 1 || pos_margin.x <= 0 || pos_margin.y >= 1 || pos_margin.y <= 0){
			return true;
		}
		return false;
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