using UnityEngine;
using System;
using System.Collections;

public class DestroyZone : MonoBehaviour {
	void OnTriggerExit(Collider c){
		if(c.transform.tag == "Bullet" || c.transform.tag == "Enemy"){
			try{
				Destroy(c.transform.parent.gameObject);
			}catch(Exception e){
				Debug.Log(e);
				Destroy(c.transform.gameObject);
			}
		}
	}
}
