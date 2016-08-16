using UnityEngine;
using System.Collections;

public class RefrigeratorDoor : MonoBehaviour {

	// OM_2もつけてね

	public GameObject doorUM; // ドア上右の回転軸になるemptyを入れて
	public GameObject doorUH; // ドア上左の回転軸になるemptyを入れて
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void forInstanceMotion(int actNum){	
		if(actNum == 1) {
			//ドア上右が開く処理
			Transform in_target;
			in_target = doorUM.transform;
			in_target.transform.Rotate (0, -150, 0);
			ObjectMover_2 om2 = this.GetComponent<ObjectMover_2>();
			om2.startMoving(doorUM, in_target);
			return;
		}else if(actNum == 2) {
			//ドア上右が閉じる処理
			Transform in_target;
			in_target = doorUM.transform;
			in_target.transform.Rotate (0, 150, 0);
			ObjectMover_2 om2 = this.GetComponent<ObjectMover_2>();
			om2.startMoving(doorUM, in_target);
			return;
		}else if(actNum == 3) {
			//ドア上右が開く処理
			Transform in_target;
			in_target = doorUH.transform;
			in_target.transform.Rotate (0, 150, 0);
			ObjectMover_2 om2 = this.GetComponent<ObjectMover_2>();
			om2.startMoving(doorUH, in_target);
			return;
		}else if(actNum == 4) {
			//ドア上右が閉じる処理
			Transform in_target;
			in_target = doorUH.transform;
			in_target.transform.Rotate (0, -150, 0);
			ObjectMover_2 om2 = this.GetComponent<ObjectMover_2>();
			om2.startMoving(doorUH, in_target);
			return;
		}
	}
}
