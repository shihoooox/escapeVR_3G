using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TutorialManager : MonoBehaviour {


	public List<GameObject> dialogList;
	public int currentTutorialNum;

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

		TutorialDialog tar,tar2;  //showを使う時に呼ぶDialogオブジェクト、tar2は前のオブジェクト
		tar = new TutorialDialog();
		tar2 = new TutorialDialog();


		if(dialogType>=401&&dialogType<=406){
			currentTutorialNum++;
			foreach(GameObject ob in dialogList){
				if(ob.GetComponent<TutorialDialog>().dialogType == dialogType){
					tar = ob.GetComponent<TutorialDialog>();
				}
				if(ob.GetComponent<TutorialDialog>().dialogType == dialogType-1){
					tar2 = ob.GetComponent<TutorialDialog>();
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
