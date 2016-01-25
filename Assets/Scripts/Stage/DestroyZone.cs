using UnityEngine;
using System;
using System.Collections;

public class DestroyZone : MonoBehaviour {
	void OnTriggerEnter(Collider c){
		GameObject c_parent;
		try{
			c_parent = c.transform.parent.gameObject;
		}catch(UnityException e){
			Destroy(c.transform.gameObject);
			return;
		}
		if(c_parent.CompareTag("Enemy") || c_parent.CompareTag("Obstacle"))
			Destroy(c_parent);
		else{
			Destroy(c.transform.gameObject);
		}
	}
}
