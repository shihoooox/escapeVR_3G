using UnityEngine;
using System.Collections;

public class RefrigeratorDoor : MonoBehaviour {

	// OM_2もつけてね <-冷蔵庫自身につけると、両ドアの開閉ができないので、ドアにつけることにしました。（エレベータのドア開閉と同じ理由）

	public GameObject doorUM; // ドア上右の回転軸になるemptyを入れて
	public GameObject doorUH; // ドア上左の回転軸になるemptyを入れて

	GameObject in_target_R;
	GameObject in_target_L;

	// Use this for initialization
	void Start () {
		in_target_R = new GameObject ();
		in_target_L = new GameObject ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void forInstanceMotion(int actNum){	
		if (actNum == 1) {
			//ドア上右が開く処理
			//GameObject in_target = new GameObject ();
			in_target_R.transform.parent = this.transform;
			// intargetを同階層のオブジェクトに

			in_target_R.transform.position = doorUM.transform.position;
			in_target_R.transform.rotation = doorUM.transform.rotation;
			in_target_R.transform.Rotate (0, -150, 0);
			in_target_R.transform.localScale = doorUM.transform.localScale;
			ObjectMover_2 om2 = doorUM.GetComponent<ObjectMover_2> ();
			om2.startMoving (doorUM, in_target_R.transform);
			return;
		} else if (actNum == 2) {
			//ドア上右が閉じる処理
			//GameObject in_target = new GameObject ();
			in_target_R.transform.parent = this.transform;
			// intargetを同階層のオブジェクトに

			in_target_R.transform.position = doorUM.transform.position;
			in_target_R.transform.rotation = doorUM.transform.rotation;
			in_target_R.transform.Rotate (0, 150, 0);
			in_target_R.transform.localScale = doorUM.transform.localScale;
			ObjectMover_2 om2 = doorUM.GetComponent<ObjectMover_2> ();
			om2.startMoving (doorUM, in_target_R.transform);
			return;
		} else if (actNum == 3) {
			//ドア上左が開く処理
			//GameObject in_target = new GameObject ();
			in_target_L.transform.parent = this.transform;
			// intargetを同階層のオブジェクトに

			in_target_L.transform.position = doorUH.transform.position;
			in_target_L.transform.rotation = doorUH.transform.rotation;
			in_target_L.transform.Rotate (0, -150, 0);
			in_target_L.transform.localScale = doorUH.transform.localScale;
			ObjectMover_2 om2 = doorUH.GetComponent<ObjectMover_2> ();
			om2.startMoving (doorUH, in_target_L.transform);
			return;
		} else if (actNum == 4) {
			//ドア上左が閉じる処理
			//GameObject in_target = new GameObject ();
			in_target_L.transform.parent = this.transform;
			// intargetを同階層のオブジェクトに

			in_target_L.transform.position = doorUH.transform.position;
			in_target_L.transform.rotation = doorUH.transform.rotation;
			in_target_L.transform.Rotate (0, 150, 0);
			in_target_L.transform.localScale = doorUH.transform.localScale;
			ObjectMover_2 om2 = doorUH.GetComponent<ObjectMover_2> ();
			om2.startMoving (doorUH, in_target_L.transform);
			return;
		} else if (actNum == 5) { //両ドアを開く
			this.forInstanceMotion (1);
			this.forInstanceMotion (3);
		} else if (actNum == 6) { //両ドアを閉じる
			this.forInstanceMotion (2);
			this.forInstanceMotion (4);
		}
	}
}
