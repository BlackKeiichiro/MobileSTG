using UnityEngine;
using System.Collections;

public class Emitter : MonoBehaviour {
	public GameObject[] waves;

	private int currentwave;
	// Use this for initialization
	IEnumerator Start () {
		GameObject wave = Instantiate(waves[currentwave],this.transform.position,Quaternion.identity) as GameObject;
		wave.transform.parent = transform;
		while(wave.transform.childCount > 0){
			yield return new WaitForEndOfFrame();
		}
		Destroy(wave);
		if(waves.Length <= ++currentwave)
			currentwave = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
