using UnityEngine;
using System.Collections;

public class NonDestroy : Enemy {

	// Use this for initialization
	protected override void Start () {
		speed = 0.2f;
	}
	
	// Update is called once per frame
	void Update () {
		Move(speed,Vector3.forward);
	}
}
