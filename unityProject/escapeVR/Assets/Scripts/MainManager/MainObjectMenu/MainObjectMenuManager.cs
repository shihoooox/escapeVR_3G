﻿using UnityEngine;
using System.Collections;

public class MainObjectMenuInstance : MonoBehaviour {

	public GameObject tmp1;//アイテム数だけある　addする
	public GameObject tmp2;
	public GameObject tmp3;
	public GameObject tmp4;
	public GameObject tmp5;
	public List<GameObject> frameList = new List<GameObject>(); 
	private List<int> activeForms = new List<int>(); // アクティブになってるフォームを表示する
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
			MainObjectMenuFrame tmp = frameList.get (i).GetComponent<MainObjectMenuFrame> ();
			if (tmp.objectType == objectType) {
				tmp.appear(true);
			}
		}
	}

	// メニューのオブジェクトを非表示にさせる(アイテムを使ったことにする)
	public void unsetObject(int objectType){
		for (int i = 0; i < frameList.Count; i++) {
			MainObjectMenuFrame tmp = frameList.get (i).GetComponent<MainObjectMenuFrame> ();
			if (tmp.objectType == objectType) {
				tmp.appear(false);
			}
		}
	}

	// メニューを画面から外す
	public void moveMenuForm(bool toHome){
	}

	// アイテムを全部デセレクトしてからobjectTypeのアイテムをセレクトする。
	public void indicateSelected(int objectType){
		for (int i = 0; i < frameList.Count; i++) {
			MainObjectMenuFrame tmp = frameList.get (i).GetComponent<MainObjectMenuFrame> ();
			tmp.selectedMotion(tmp.objectType == objectType);
		}
		if(selectedObjectType != objectType){
			selectedObjectType = objectType;
		}
	}

	// セレクトされてるアイテムの詳細を表示する
	public void showObjectsDetail(bool pushed){
		for (int i = 0; i < frameList.Count; i++) {
			MainObjectMenuFrame tmp = frameList.get (i).GetComponent<MainObjectMenuFrame> ();
			if (tmp.objectType == objectType) {
				tmp.showDetail (pushed);
			}
		}
	}

	// 個々のモーションがあればframeListからobjectTypeのオブジェクトのmakeActを 呼び出す
	public void extraMotion(int objectType, int actNum){
		Debug.Log ("未完成です");
		for (int i = 0; i < frameList.Count; i++) {
			MainObjectMenuFrame tmp = frameList.get (i).GetComponent<MainObjectMenuFrame> ();
			if (tmp.objectType == objectType) {
				tmp.makeAct (actNum);
			}
		}
	}

	// メニューを画面に表示させたり外したりするメソッド
	public void moveToScreen(bool to, transform cameraPos){
	}



}
