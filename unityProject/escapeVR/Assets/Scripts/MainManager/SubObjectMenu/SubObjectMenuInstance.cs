using UnityEngine;
using System.Collections;
using System;

public class SubObjectMenuInstance : MonoBehaviour {

	public String description;
	public Vector3 homePos;
	private bool nowPos;
	private bool changePos;

	// Use this for initialization
	void Start () {
		homePos = this.transform.position;
		nowPos = false;
		changePos = false;
	}
	
	// Update is called once per frame
	void Update () {
	}

	// オブジェクトを説明欄に移動させたり戻したりするメソッド
	public void setActive(bool active){
		Debug.Log("未完成です");
	}
}
