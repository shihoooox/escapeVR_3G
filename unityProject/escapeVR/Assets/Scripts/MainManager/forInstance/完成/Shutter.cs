using UnityEngine;
using System.Collections;

public class Shutter : MonoBehaviour {

	//OMもつけてください

	private GameObject target;
	//public GameObject zibun;

	// Use this for initialization
	void Start () {
		target = new GameObject ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void forInstanceMotion(int actNum){	
		if(actNum == 1) {
			// シャッターを開ける
			target.transform.position = this.transform.position;
			Vector3 pos = target.transform.position;
			pos.y += 3f;
			target.transform.position = pos;

			ObjectMover om = this.GetComponent<ObjectMover>();
			om.startMoving (this.gameObject, target);
			return;
		}
	}
}
