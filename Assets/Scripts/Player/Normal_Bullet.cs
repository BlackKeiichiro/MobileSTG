using UnityEngine;
using System.Collections;

public class Normal_Bullet : Bullet {
	// Use this for initialization
	protected override void Start() {
		base.Start();
		speed = 1.5f;
		damage = 1;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.localPosition +=  Vector3.forward * speed;
	}
}
