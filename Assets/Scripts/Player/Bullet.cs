using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public abstract class Bullet : MonoBehaviour {
	protected int damage;
	protected Rigidbody _rigidbody;
	protected float speed = 0;
	protected float shot_range;
	protected Vector3 save_position;
	protected Vector3 target_vector;

	// Use this for initialization
	protected virtual void Start () {
		_rigidbody = this.GetComponent<Rigidbody>();
		save_position = this.transform.position;
	} 

	protected virtual void OnTriggerEnter(Collider c){
		if(c.transform.CompareTag("Enemy")){
			try{
				Enemy enemy = c.GetComponent<Enemy>();
				enemy.hp -= 1;
				enemy.DamageAnimation();
				if(enemy.hp < 0){
					Destroy(c.transform.gameObject);

					Instantiate(Resources.Load("Obstacle/Explosion")as GameObject,this.transform.position,Quaternion.identity);
				}
			}catch(UnityException e){
				Debug.Log(e);
				return;
			}
			Destroy(this.gameObject);
		}
	}

	//public void SetTarget(Vector3 target){
	//		target_vector = target;
	//	}
}
