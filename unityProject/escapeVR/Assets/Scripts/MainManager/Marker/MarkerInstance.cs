using UnityEngine;
using System.Collections;

public class MarkerInstance : MonoBehaviour {

	public int objectType;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//マーカの移動先の位置を持つGameObjectを返す
	public GameObject getDirectionLocation() {
		GameObject tmp = new GameObject ();
		Vector3 pos = this.transform.position;
		pos.y = 1.4f;
		tmp.transform.position = pos;
		tmp.transform.rotation = this.transform.rotation;
		return tmp;
	}
}
