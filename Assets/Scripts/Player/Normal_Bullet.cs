using UnityEngine;
using System.Collections;

public class Normal_Bullet : Bullet {
	// Use this for initialization
	protected override void Start() {
		_rigidbody = this.GetComponent<Rigidbody>();
		speed = 1.5f;
		damage = 1;
		shot_range = 60;
		save_position = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if((save_position - this.transform.position).magnitude > shot_range)
			Destroy(this.transform.gameObject);
		this.transform.localPosition += Vector3.forward * speed;
	}
}
