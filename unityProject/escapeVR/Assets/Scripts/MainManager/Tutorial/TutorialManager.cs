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
		Debug.Log ("TutorialManager, next()は未完成です");
		if(dialogType>=401&&dialogType<=406){
			if(dialogType==401){
				dialogList[0].show (true);
				return true;
			}if (dialogType == 406) {
				
				return true;
			} else {
				dialogList [dialogType - 402].show (false);
				dialogList [dialogType - 401].show (true);
				return true;
			}
		}else {
			return false;
		}
	}
}
