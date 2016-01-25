using UnityEngine;
using System.Collections;

public class Normal_Bullet : Bullet {
	// Use this for initialization
	protected override void Start() {
		base.Start();
		speed = 3;
		damage = 1;
		shot_range = 30;
		target_vector = GameObject.Find("Player/Point").transform.position;
		_rigidbody.velocity = (target_vector - this.transform.position)*speed;
	}
	
	// Update is called once per frame
	void Update () {
		if((save_position - this.transform.position).magnitude > shot_range)
			Destroy(this.transform.gameObject);
	}
}
