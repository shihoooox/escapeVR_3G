using UnityEngine;
using System.Collections;

public class RefrigeratorDoor : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void forInstanceMotion(int actNum){	
		if(actNum == 1) {
			//ドアが開く処理

			// y -150ど
			return;
		}else if(actNum == 2) {
			//ドアが閉じる処理
			// y 0ど
			return;
		}
	}
}
