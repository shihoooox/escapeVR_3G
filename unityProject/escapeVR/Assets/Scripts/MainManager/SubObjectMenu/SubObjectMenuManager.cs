using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SubObjectMenuManager : MonoBehaviour {
	public GameObject inCamera;
	public GameObject outCamera;
	public List<GameObject> frameList = new List<GameObject>(); 
	private int selectedObjectType; //選択されているobjectTypeを保持する、なければ-2

	// Use this for initialization
	void Start () {

		foreach (Transform child in this.transform) {
			frameList.Add (child.gameObject);
		}

		selectedObjectType = -2;
		//Debug.Log ("未完成です");

		foreach (GameObject frame in frameList) {
			frame.GetComponent<SubObjectMenuFrame>().menu_normal = 
				this.transform.root.gameObject.GetComponent<MainManager> ().getTextureManager ().menu_normal;
			frame.GetComponent<SubObjectMenuFrame>().menu_noItem = 
				this.transform.root.gameObject.GetComponent<MainManager> ().getTextureManager ().menu_noItem;
			frame.GetComponent<SubObjectMenuFrame>().menu_used = 
				this.transform.root.gameObject.GetComponent<MainManager> ().getTextureManager ().menu_used;
		}
	}
	
	// Update is called once per frame
	void Update () {
		//this.transform.position = inCamera.transform.position;
		//this.transform.eulerAngles = inCamera.transform.eulerAngles;
	}

	// メニューのオブジェクトを表示させる(アイテムを取ったことにする)
	public void setObject(int objectType){
		for (int i = 0; i < frameList.Count; i++) {
			SubObjectMenuFrame tmp = frameList[i].GetComponent<SubObjectMenuFrame> ();
			if (tmp.objectType == objectType) {
				tmp.appear(true);
			}
			//tmp.isActive = tmp.objectType == objectType;
		}
	}

	// メニューのオブジェクトを非表示にさせる(アイテムを使ったことにする)
	public void unsetObject(int objectType){
		for (int i = 0; i < frameList.Count; i++) {
			SubObjectMenuFrame tmp = frameList[i].GetComponent<SubObjectMenuFrame> ();
			if (tmp.objectType == objectType) {
				tmp.used(true);
			}
			//tmp.isActive = tmp.objectType == objectType;
		}
	}

	// メニューを画面から外す
	public void moveMenuForm(bool toHome){
		//何の処理かわからんので一応放置、MoveToScreenで間に合うのでは？ by Okamoto
	}

	// アイテムを全部デセレクトしてからobjectTypeのアイテムをセレクトする。
	public void indicateSelected(int objectType){
		Debug.Log ("called sub selectedMotion with type : " + objectType);
		for (int i = 0; i < frameList.Count; i++) {
			SubObjectMenuFrame tmp = frameList[i].GetComponent<SubObjectMenuFrame> ();
			tmp.selectedMotion (tmp.objectType == objectType);
		}
		if(selectedObjectType != objectType){
			selectedObjectType = objectType;
		}
	}

	//メニューを表示させたり外したりするメソッド
	public void moveToScreen(bool to) { //mainObjectMenuManager
		ObjectMover om = this.GetComponent<ObjectMover> ();
		Debug.Log ("moving " + to);
		bool onScreen; //frameのonScreen更新用
		if (to) {
			om.startMoving (outCamera);
			onScreen = false;
		} else {
			om.startMoving (inCamera);
			onScreen = true;
		}
		for (int i = 0; i < frameList.Count; i++) {
			frameList [i].GetComponent<SubObjectMenuFrame> ().onScreen = onScreen;
		}
	}

}
