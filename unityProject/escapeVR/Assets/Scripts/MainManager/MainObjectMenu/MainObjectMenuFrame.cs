﻿using UnityEngine;
using System.Collections;
using System;

public class MainObjectMenuFrame : MonoBehaviour {

	public GameObject childObject;
	public GameObject detailPos; //詳細位置 -C
	public bool isSelected; //ユーザが選択しているかどうか
	public bool onScreen; //これが画面に出ているかどうか
	public bool isActive; //これが表示されているかどうか
	public bool isInsideFrame; //フレームの中にいるかどうか
	public int objectType; //オブジェクト固有の番号
	private Color originalColor;
	private GameObject baseChildPos; //-C

	// Use this for initialization
	void Start () {
		isSelected = false;
		onScreen = false;
		isActive = false;
		isInsideFrame = true;
		originalColor = GetComponent<Renderer> ().material.color;
		childObject.transform.position = this.transform.position;
		childObject.transform.position += this.transform.up * -0.06f;

		//子オブジェクトのtransformを保存
		baseChildPos = new GameObject (); 
		baseChildPos.transform.position = this.transform.position;
		baseChildPos.transform.position += this.transform.up * -0.06f;
		baseChildPos.transform.rotation = this.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		try {
			//MainObjectMenuInstance instance = childObject.GetComponent<MainObjectMenuInstance>();
			//instance.homePos = this.transform.position; //移動処理はFrameが行うことになったのでこの処理自体不要になった
		} catch (NullReferenceException e) {
			//Debug.Log ("ぬるぽ"); //上の代入処理でぬるぽになるのを解決する必要がある。
		}


	}

	//子オブジェクトであるchildObjectを説明欄へ移動させたりもどしたりするメソッド ←仕様書のメソッドの働きを書いてください。===
	//===↓ Start, Update以外のすべてのメソッドの宣言の前に、フィールド変数のように「public」をつけてください。===
	public void showDetail(bool b){
		if(childObject.GetComponent<MainObjectMenuInstance>() != null){
			ObjectMover om = this.GetComponent<ObjectMover> ();
			if (b) { //trueならframeの外へ
				Debug.Log ("ToOutSideFrame: " + objectType);
				om.startMoving (childObject, detailPos); //移動開始
				isInsideFrame = false;// frameの外なので
			} else { //falseならframeの中へ
				Debug.Log ("ToInsideFrame: " + objectType);
				baseChildPos.transform.position = this.transform.position;
				baseChildPos.transform.position += this.transform.up * -0.06f;
				baseChildPos.transform.rotation = this.transform.rotation;
				om.startMoving (childObject, baseChildPos); //移動開始
				isInsideFrame = true;
			}
		}
	}

	//子オブジェクトに特別な動きを命令するメソッド
	public void makeAct(int actNum){
		if(childObject.GetComponent<MainObjectMenuInstance>() != null){
			MainObjectMenuInstance child = childObject.GetComponent<MainObjectMenuInstance>();
			child.actOnDetail (objectType, actNum);
		}
	}

	//選択されていることを可視化する処理
	public void selectedMotion(bool selected){
		if (isSelected != selected) {
			if (selected) {
				Color c = Color.red;
				c.a = 0.6f;
				GetComponent<Renderer> ().material.SetColor ("_Color", c);
			} else {
				GetComponent<Renderer> ().material.SetColor("_Color", originalColor);
			}
			isSelected = selected;
		}

	}

	//自分がユーザが取得したオブジェクトであれば、childObjectを表示させる
	public void appear(bool active){
		if(isActive != active){
			childObject.SetActive(active);
			isActive = active;
		}
	}
}