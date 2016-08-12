using UnityEngine;
using System.Collections;

public class MainManager : MonoBehaviour {
	public GameObject MainObjectMenuManager_G; //MainObjectMenuManagerのGameObject
	public GameObject SubObjectMenuManager_G; //SubObjectMenuManagerのGameObject
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//key: Q (Qキーを押すとメニューが出て話すと上に消える処理)
		if (Input.GetKeyDown (KeyCode.Q)) {
			MainObjectMenuManager MomManager = MainObjectMenuManager_G.GetComponent<MainObjectMenuManager> ();
			SubObjectMenuManager SomManager = SubObjectMenuManager_G.GetComponent<SubObjectMenuManager> ();
			MomManager.moveToScreen (true);
			SomManager.moveToScreen (true);
		} else if (Input.GetKeyUp (KeyCode.Q)) {
			MainObjectMenuManager MomManager = MainObjectMenuManager_G.GetComponent<MainObjectMenuManager> ();
			SubObjectMenuManager SomManager = SubObjectMenuManager_G.GetComponent<SubObjectMenuManager> ();
			MomManager.moveToScreen (false);
			SomManager.moveToScreen (false);
		}

		//key: P (Pキーを押すと選択される処理)
		if (Input.GetKeyDown (KeyCode.P)) {
			Vector3 pos = new Vector3 (Screen.width / 2.0f, Screen.height / 2.0f, 0);
			Ray ray = Camera.main.ScreenPointToRay (pos);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 100.0f)) {
				int type = -1; //衝突したobjectType
				if (hit.collider.gameObject.tag == "MainObjectMenuFrame") {
					MainObjectMenuFrame frame = hit.collider.gameObject.GetComponent<MainObjectMenuFrame> (); //objectTypeを知るためにframeのインスタンス取得
					MainObjectMenuManager MomManager = MainObjectMenuManager_G.GetComponent<MainObjectMenuManager> (); //managerのインスタンス取得
					SubObjectMenuManager SomManager = SubObjectMenuManager_G.GetComponent<SubObjectMenuManager>();
					type = frame.objectType;
					Debug.Log ("P_key pressed, hit type : " + type);
					if (type > 0) {
						if (!frame.isSelected) {
							MomManager.indicateSelected (type);
							SomManager.indicateSelected (type+100);
						} else {
							MomManager.showObjectsDetail (type);
						}
					}
				}
			}
		}
	}
}
