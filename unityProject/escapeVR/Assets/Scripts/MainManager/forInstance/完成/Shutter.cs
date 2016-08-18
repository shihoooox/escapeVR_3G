using UnityEngine;
using System.Collections;

public class Shutter : MonoBehaviour {

	//OMもつけてください

	private GameObject target;
	public GameObject zibun;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void forInstanceMotion(int actNum){	
		if(actNum == 1) {
			// シャッターを開ける
			target = new GameObject ();
			target.transform.position = this.transform.position;
			Vector3 pos = target.transform.position;
			pos.y += 4f;
			target.transform.position = pos;

			ObjectMover om = this.GetComponent<ObjectMover>();
			om.startMoving (zibun, target);
			return;
		}
	}
}
