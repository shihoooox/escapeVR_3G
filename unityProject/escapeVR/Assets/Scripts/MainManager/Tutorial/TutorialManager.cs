using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TutorialManager : MonoBehaviour {


	public List<GameObject> dialogList;

	// Use this for initialization
	void Start () {
		//子を取得、リストに格納
		Transform children = this.GetComponentInChildren<Transform> ();
		foreach (Transform ob in children) {
			dialogList.Add (ob.gameObject);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}

	public bool next(int dialogType) {
	//	Debug.Log ("TutorialManager, next()は未完成です");

		GameObject tar,tar2;  //showを使う時に呼ぶDialogオブジェクト、tar2は前のオブジェクト

		if(dialogType>=401&&dialogType<=406){
			foreach(GameObject ob in dialogList){
				if(ob.dialogType == dialogType){
					tar = ob;
				}
				if(ob.dialogType == dialogType-1){
					tar2 = ob;
				}
			}
			if(dialogType==401){
				tar.show (true);
				return true;
			}if (dialogType == 406) {
				//opening.sceneに移行、未実装
				Debug.Log ("TutorialManager.next(406)は未完成です");
				return true;
			} else {
				tar2.show (false);
				tar.show (true);
				return true;
			}
		}else {
			return false;
		}
	}
}
