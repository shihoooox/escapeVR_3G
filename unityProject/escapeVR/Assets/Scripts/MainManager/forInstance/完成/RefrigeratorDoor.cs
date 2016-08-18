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
			GameObject in_target = new GameObject();
			in_target.transform.parent = this.transform;
			// intargetを同階層のオブジェクトに

			in_target.transform.position = doorUM.transform.position;
			in_target.transform.rotation = doorUM.transform.rotation;
			in_target.transform.Rotate (0, -150, 0);
			ObjectMover_2 om2 = this.GetComponent<ObjectMover_2> ();
			om2.startMoving (doorUM, in_target.transform);
			return;
		}else if(actNum == 2) {
			//ドア上右が閉じる処理
			GameObject in_target = new GameObject();
			in_target.transform.parent = this.transform;
			// intargetを同階層のオブジェクトに

			in_target.transform.position = doorUM.transform.position;
			in_target.transform.rotation = doorUM.transform.rotation;
			in_target.transform.Rotate (0, 150, 0);
			ObjectMover_2 om2 = this.GetComponent<ObjectMover_2> ();
			om2.startMoving (doorUM, in_target.transform);
			return;
		}else if(actNum == 3) {
			//ドア上左が開く処理
			GameObject in_target = new GameObject();
			in_target.transform.parent = this.transform;
			// intargetを同階層のオブジェクトに

			in_target.transform.position = doorUH.transform.position;
			in_target.transform.rotation = doorUH.transform.rotation;
			in_target.transform.Rotate (0, -150, 0);
			ObjectMover_2 om2 = this.GetComponent<ObjectMover_2> ();
			om2.startMoving (doorUH, in_target.transform);
			return;
		}else if(actNum == 4) {
			//ドア上左が閉じる処理
			GameObject in_target = new GameObject();
			in_target.transform.parent = this.transform;
			// intargetを同階層のオブジェクトに

			in_target.transform.position = doorUH.transform.position;
			in_target.transform.rotation = doorUH.transform.rotation;
			in_target.transform.Rotate (0, 150, 0);
			ObjectMover_2 om2 = this.GetComponent<ObjectMover_2> ();
			om2.startMoving (doorUH, in_target.transform);
			return;
		}
	}
}
