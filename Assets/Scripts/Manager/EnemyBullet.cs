using UnityEngine;
using System.Collections;

public class EnemyBullet : Bullet {

	// Use this for initialization
	protected override void Start () {
		base.Start();
		speed = 0.5f;
		damage = 3;
		shot_range = 100;
		target_vector = GameObject.Find("Player").transform.position;
		_rigidbody.velocity = (target_vector - this.transform.position) * speed;
	}

	protected override void OnTriggerEnter(Collider c){
		if(c.transform.CompareTag("Player")){
			try{
				Player player = c.GetComponent<Player>();
				player.PlayerDamage(damage);
			}
			catch(UnityException e){
				Debug.Log(e);
				return;
			}
			Destroy(this.gameObject);
		}
	}

	// Update is called once per frame
	void Update () {
		if((save_position - this.transform.position).magnitude > shot_range)
			Destroy(this.transform.gameObject);
	}


}
