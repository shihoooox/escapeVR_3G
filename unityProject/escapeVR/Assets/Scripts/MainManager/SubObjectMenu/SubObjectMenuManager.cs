using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SubObjectMenuManager : MonoBehaviour {

	public GameObject inCamera;
	public GameObject outCamera;
	public GameObject tmp1;//アイテム数だけある　addする
	public GameObject tmp2;
	public GameObject tmp3;
	public GameObject tmp4;
	public GameObject tmp5;
	public List<GameObject> frameList = new List<GameObject>(); 
	private int selectedObjectType; //選択されているobjectTypeを保持する、なければ-1

	// Use this for initialization
	void Start () {
		frameList.Add (tmp1);
		frameList.Add (tmp2);
		frameList.Add (tmp3);
		frameList.Add (tmp4);
		frameList.Add (tmp5);

		selectedObjectType = -1;
		Debug.Log ("未完成です");

	}
	
	// Update is called once per frame
	void Update () {
	}

	// メニューのオブジェクトを表示させる(アイテムを取ったことにする)
	public void setObject(int objectType){
		for (int i = 0; i < frameList.Count; i++) {
			SubObjectMenuFrame tmp = frameList[i].GetComponent<SubObjectMenuFrame> ();
			if (tmp.objectType == objectType) {
				tmp.appear(true);
			}
		}
	}

	// メニューのオブジェクトを非表示にさせる(アイテムを使ったことにする)
	public void unsetObject(int objectType){
		for (int i = 0; i < frameList.Count; i++) {
			SubObjectMenuFrame tmp = frameList[i].GetComponent<SubObjectMenuFrame> ();
			if (tmp.objectType == objectType) {
				tmp.appear(false);
			}
		}
	}

	// メニューを画面から外す
	public void moveMenuForm(bool toHome){
		//何の処理かわからんので一応放置、MoveToScreenで間に合うのでは？ by Okamoto
	}

	// アイテムを全部デセレクトしてからobjectTypeのアイテムをセレクトする。
	public void indicateSelected(int objectType){
		for (int i = 0; i < frameList.Count; i++) {
			SubObjectMenuFrame tmp = frameList[i].GetComponent<SubObjectMenuFrame> ();
			tmp.selected(tmp.objectType == objectType);
		}
		if(selectedObjectType != objectType){
			selectedObjectType = objectType;
		}
	}

}
