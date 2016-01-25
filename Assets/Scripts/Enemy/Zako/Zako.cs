using UnityEngine;
using System.Collections;

public class Zako : Enemy{
	public int bullet_num = 3;
	private float canshot_range = 20;
	// Use this for initialization

	protected override void Start () {
		hp = 5;
		anim = this.GetComponent<Animator>();
		player = GameObject.Find("Player");
		StartCoroutine(ShotCoroutine(bullet_num));
	}
	
	// Update is called once per frame
	void Update () {
		if((player.transform.position - this.transform.position).magnitude < canshot_range)
			shot_flag = true;
		Move(speed,Vector3.forward);
	}


}
