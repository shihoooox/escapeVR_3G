using UnityEngine;
using System.Collections;

public class MainManager : MonoBehaviour {
	public GameObject MainObjectMenuManager_G; //MainObjectMenuManagerのGameObject
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//key: Q (Qキーを押すとメニューが出て話すと上に消える処理)
		if (Input.GetKeyDown (KeyCode.Q)) {
			MainObjectMenuManager MomManager = MainObjectMenuManager_G.GetComponent<MainObjectMenuManager> ();
			MomManager.moveToScreen (true);
		} else if (Input.GetKeyUp (KeyCode.Q)) {
			MainObjectMenuManager MomManager = MainObjectMenuManager_G.GetComponent<MainObjectMenuManager> ();
			MomManager.moveToScreen (false);
		}

		//key: P (Pキーを押すと選択される処理)
		if (Input.GetKeyDown (KeyCode.P)) {
			Vector3 pos = new Vector3 (Screen.width / 2.0f, Screen.height / 2.0f, 0);
			Ray ray = Camera.main.ScreenPointToRay (pos);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 100.0f)) {
				int type = -1; //衝突したobjectType
				if (hit.collider.gameObject.tag == "MainObjectMenuFrame") {
					MainObjectMenuFrame mainFrame = hit.collider.gameObject.GetComponent<MainObjectMenuFrame> (); //objectTypeを知るためにframeのインスタンス取得
					MainObjectMenuManager mainManager = MainObjectMenuManager_G.GetComponent<MainObjectMenuManager> (); //managerのインスタンス取得
					type = mainFrame.objectType;
					Debug.Log ("P_key pressed, hit type : " + type);
					if (type > 0) {
						if (!mainFrame.isSelected) {
							mainManager.indicateSelected (type);
						} else {
							mainManager.showObjectsDetail (type);
						}
					}
				}
			}
		}
	}
}
