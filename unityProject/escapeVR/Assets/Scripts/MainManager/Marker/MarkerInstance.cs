using UnityEngine;
using System.Collections;
using System;

public class MarkerInstance : MonoBehaviour {

	public int objectType;
	public bool isFocusOn = false;
	private float waveCount = 0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isFocusOn) {
			waveCount += Time.deltaTime;
			this.transform.Rotate (0f, 90f*Time.deltaTime, 0f);
			this.transform.position += new Vector3 (0f, (float)Math.Sin((double)waveCount*2)*0.005f, 0f);
		}
	}

	//マーカの移動先の位置を持つGameObjectを返す
	public GameObject getDirectionLocation() {
		GameObject tmp = new GameObject ();
		Vector3 pos = this.transform.position;
		pos.y = 1.5f;
		tmp.transform.position = pos;
		tmp.transform.rotation = this.transform.rotation;
		return tmp;
	}
}
