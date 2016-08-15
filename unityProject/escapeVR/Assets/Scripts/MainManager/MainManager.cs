using UnityEngine;
using UnityEngine.VR;
using System.Collections;

public class MainManager : MonoBehaviour {
	public GameObject MainObjectMenuManager_G; //MainObjectMenuManagerのGameObject
	public GameObject SubObjectMenuManager_G; //SubObjectMenuManagerのGameObject
	public GameObject MarkerManager_G; //MarkerManagerのGameObject

	public GameObject audioPlayer01;

	private int selectedObjectNum;

	// Use this for initialization
	void Start () {
		selectedObjectNum = -2;

	}
	
	// Update is called once per frame
	void Update () {
		//key: Q (Qキーを押すとメニューが出て話すと上に消える処理)
		if (Input.GetKeyDown (KeyCode.Q)) {
			this.pressKeyDown_Q ();
		} else if (Input.GetKeyUp (KeyCode.Q)) {
			this.pressKeyUp_Q ();
		}
		
 		//each frame
		this.eachFrame();

		//key: W (Wキーを押すと選択される処理)
		if (Input.GetKeyDown (KeyCode.W)) {
			this.pressKeyDown_W ();
		}

		//key:E (Eキーを押すとオブジェクトが消えるデバッグ)
		if (Input.GetKeyDown (KeyCode.E)) {
			this.pressKeyDown_E ();
		}
	}





	void eachFrame() {
		Ray ray_ = new Ray (Camera.main.transform.position, Camera.main.transform.forward);
		RaycastHit hit_;
		int MarkerObjectType = -2;
		if (Physics.Raycast (ray_, out hit_, 100.0f)) {
			GameObject tmp = hit_.collider.gameObject;
			//Debug.Log ("ray : " + tmp.name + " " + tmp.transform.position);
			if (tmp.tag == "Marker") {
				MarkerObjectType = tmp.GetComponent<MarkerInstance> ().objectType;
			}
		}
		MarkerManager_G.GetComponent<MarkerManager> ().focus (MarkerObjectType);
	}

	void pressKeyDown_Q() {
		MainObjectMenuManager MomManager = MainObjectMenuManager_G.GetComponent<MainObjectMenuManager> ();
		SubObjectMenuManager SomManager = SubObjectMenuManager_G.GetComponent<SubObjectMenuManager> ();
		MomManager.moveToScreen (true);
		SomManager.moveToScreen (true);
	}

	void pressKeyUp_Q() {
		MainObjectMenuManager MomManager = MainObjectMenuManager_G.GetComponent<MainObjectMenuManager> ();
		SubObjectMenuManager SomManager = SubObjectMenuManager_G.GetComponent<SubObjectMenuManager> ();
		MomManager.moveToScreen (false);
		SomManager.moveToScreen (false);
	}

	void pressKeyDown_W() {
		Debug.Log ("W pressed");
		Ray ray = new Ray (Camera.main.transform.position, Camera.main.transform.forward);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, 100.0f)) {
			int type = -2; //衝突したobjectType

			Debug.Log ("hit type : " + hit.collider.gameObject.tag + ", name : " + hit.collider.gameObject.name);

			//hitしたのがMainObjectMenuFrameなら
			if (hit.collider.gameObject.tag == "MainObjectMenuFrame") {
				MainObjectMenuFrame frame = hit.collider.gameObject.GetComponent<MainObjectMenuFrame> (); //objectTypeを知るためにframeのインスタンス取得
				MainObjectMenuManager MomManager = MainObjectMenuManager_G.GetComponent<MainObjectMenuManager> (); //managerのインスタンス取得
				SubObjectMenuManager SomManager = SubObjectMenuManager_G.GetComponent<SubObjectMenuManager> ();
				type = frame.objectType;
				Debug.Log ("P_key pressed, hit type : " + type);
				if (type > 0) {
					if (!frame.isSelected) {
						MomManager.indicateSelected (type);
						SomManager.indicateSelected (type + 100);
						selectedObjectNum = type;
					} else {
						MomManager.showObjectsDetail (type);
					}
				}
			}

			//hitしたのがMainObjectMenuInstanceなら
			else if (hit.collider.gameObject.tag == "MainObjectMenuInstance") {

				Debug.Log ("parentsName: " + hit.collider.gameObject.transform.parent.gameObject.name +
					", grandParentsName: " + hit.collider.gameObject.transform.parent.gameObject.transform.parent.gameObject.name);

				int targetObjNum = hit.collider.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<MainObjectMenuFrame> ().objectType;
				int syntheSizedNum = this.GetComponent<ObjectSynthesizer>().synthesizeInMenu(targetObjNum, selectedObjectNum);
				Debug.Log ("合成 target: " + targetObjNum + " - selected: " + selectedObjectNum + " => " + syntheSizedNum);
				//MOMのオブジェクト削除
				MainObjectMenuManager_G.GetComponent<MainObjectMenuManager> ().unsetObject (targetObjNum);
				MainObjectMenuManager_G.GetComponent<MainObjectMenuManager> ().unsetObject (selectedObjectNum);

				//SOMのオブジェクト削除
				SubObjectMenuManager_G.GetComponent<SubObjectMenuManager> ().unsetObject (targetObjNum+100);
				SubObjectMenuManager_G.GetComponent<SubObjectMenuManager> ().unsetObject (selectedObjectNum+100);

				//Object表示
				MainObjectMenuManager_G.GetComponent<MainObjectMenuManager> ().setObject (syntheSizedNum);
				SubObjectMenuManager_G.GetComponent<SubObjectMenuManager> ().setObject (syntheSizedNum+100);
			}

			//hitしたのがMarkerなら
			else if(hit.collider.gameObject.tag == "Marker") {
				MarkerInstance instance = hit.collider.gameObject.GetComponent<MarkerInstance> ();
				MarkerManager manager =  MarkerManager_G.GetComponent<MarkerManager> ();
				type = instance.objectType;
				Debug.Log("move to " + type);
				manager.moveTo (type);
			}
		}
	}

	void pressKeyDown_E() {
		Debug.Log ("E key pressed");
		audioPlayer01.GetComponent<AudioPlayer> ().play(true);
	}
}
