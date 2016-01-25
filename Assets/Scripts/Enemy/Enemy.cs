using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public abstract class Enemy : MonoBehaviour {
	public bool shot_flag = false;
	public float speed = 0.1f;
	public int hp = 0;
	protected GameObject player;
	protected Rigidbody _rigidbody;
	protected Animator anim;
	protected virtual void Start(){}

	public void DamageAnimation(){
		anim.SetTrigger("Damage");
	}

	protected void Move(float speed,Vector3 vector){
		this.transform.localPosition -= speed * vector;
	}
	protected IEnumerator ShotCoroutine(int limit){
		int bullet_num = 0;
		while(limit > bullet_num){
			if(shot_flag){
				Debug.Log("SHOT");
				GameObject localbullet = Instantiate(Resources.Load("Enemy/EnemyBullet")) as GameObject;
				localbullet.transform.position = this.transform.position;
				localbullet.transform.rotation = this.transform.rotation;
				bullet_num++;
				yield return new WaitForSeconds(1);
			}else{
				yield return new WaitForEndOfFrame();
			}
		}
	}

}
