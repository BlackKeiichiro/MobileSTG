using UnityEngine;
using System.Collections;

public class Chace_Bullet : Bullet{

	// Use this for initialization
	protected override void Start () {
		speed = 2;
		_rigidbody.AddForce(SearchEnemy().transform.position - this.transform.position);
	}
	
	// Update is callred once per frame
	void Update () {
	
	}

	GameObject SearchEnemy(){
		float keep = 100;
		GameObject close_obj = new GameObject();
		close_obj.transform.position = Vector3.zero;
		foreach(GameObject _obj in Object.FindObjectsOfType(typeof(GameObject))){
			if(_obj.transform.tag == "Enemy"){
				float dis = (this.transform.position - _obj.transform.position).magnitude;
				if(keep > dis){
					close_obj = _obj;
				}
			}
		}
		return close_obj;
	}
}
