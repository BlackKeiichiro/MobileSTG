using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class Count : MonoBehaviour {
	int count = 0;
	float comp = 0;
	Text timeUI;
	// Use this for initialization
	void Start () {
		timeUI = GameObject.Find("Count").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		comp += Time.deltaTime;
		count = Convert.ToInt32(comp);
		timeUI.text = "Count:" + count;
	}
}
