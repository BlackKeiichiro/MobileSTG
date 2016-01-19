using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public abstract class Bullet : MonoBehaviour {
	protected Rigidbody _rigidbody;
	protected float speed = 0;
	protected Vector3 target_vector;
    protected GameObject enemy;
	protected int damage;
	// Use this for initialization
	protected virtual void Start () {} 
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider c){
		if(c.transform.CompareTag("Enemy")){
			Enemy enemy = c.GetComponent<Enemy>();
			enemy.hp -= 1;
			enemy.DamageAnimation();
			if(enemy.hp < 0){
				Destroy(c.transform.gameObject);
			}
			Destroy(this.gameObject);
		}
	}
}
