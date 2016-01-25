using UnityEngine;
using System.Collections;

public class BigMeteo : Enemy {
	// Use this for initialization
	protected override void Start () {
		hp = 10;
		anim = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		Move(speed,Vector3.forward);
	}

}
