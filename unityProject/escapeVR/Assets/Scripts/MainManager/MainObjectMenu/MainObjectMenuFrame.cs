using UnityEngine;
using System.Collections;
using System;

public class MainObjectMenuFrame : MonoBehaviour {

	public GameObject childObject;
	public GameObject detailPos; //詳細位置 -C
	public bool isSelected; //ユーザが選択しているかどうか
	public bool onScreen; //これが画面に出ているかどうか
	public bool isActive; //これが表示されているかどうか
	public bool isInsideFrame; //フレームの中にいるかどうか
	public bool isUsed; //アイテムが使われたかどうか
	public int objectType; //オブジェクト固有の番号
	private GameObject baseChildPos; //-C
	private bool scaling;
	private bool nowFocus = false;
	public Texture[] menu_normal; //普通のメニューテクスチャ
	public Texture[] menu_noItem; //アイテムなしのメニューテクスチャ
	public Texture[] menu_used; //使用済みのアイテム
	private float gifNum = 0; //コマを保存するやつ


	// Use this for initialization
	void Start () {
		isSelected = false;
		onScreen = false;
		isInsideFrame = true;
		isUsed = false;
		scaling = false;
		baseChildPos = new GameObject (); //こオブジェクトを保存するgameobject作成
		foreach (Transform child in this.transform) 
			childObject = child.gameObject;
		isActive = childObject.activeSelf;

		if (objectType == -1) {
			baseChildPos.transform.position = childObject.transform.position;
			baseChildPos.transform.rotation = childObject.transform.rotation;
		} else {
			childObject.transform.position = this.transform.position;
			childObject.transform.position += this.transform.up * -0.06f;
			//子オブジェクトのtransformを保存
			baseChildPos.transform.position = this.transform.position;
			baseChildPos.transform.position += this.transform.up * -0.06f;
			baseChildPos.transform.rotation = this.transform.rotation;
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (scaling) {
			Vector3 deltaScale = new Vector3 (100, 100, 100) * Time.deltaTime; //1秒で100だけ大きくなるベクトル
			if(isInsideFrame) deltaScale *= -1; //フレームに入る向きならベクトルを反転

			childObject.transform.localScale += deltaScale;

			//スケール終了条件を満たしたら終了
			if (isInsideFrame && childObject.transform.localScale.x <= 5f) {
				scaling = false;
				childObject.transform.localScale = new Vector3(5f, 5f, 5f);
			} else if (!isInsideFrame && childObject.transform.localScale.x >= 22f) {
				scaling = false;
				childObject.transform.localScale = new Vector3(22f, 22f, 22f);
			}

		}

		//childObjectの回転処理
		if (!isInsideFrame) {
			childObject.transform.Rotate (Time.deltaTime * 30f, Time.deltaTime * 30f, 0);
		} else {
			childObject.transform.rotation = Camera.main.transform.rotation;//baseChildPos.transform.rotation;
			childObject.transform.Rotate(-90, 0, 0);
		}

		//テクスチャ関連
		int fps = 15;
		gifNum = (Time.time * fps) % menu_normal.Length;
		if (childObject.activeSelf) {
			if(!isUsed)
				this.GetComponent<Renderer> ().material.mainTexture = menu_normal [(int)gifNum];
			else
				this.GetComponent<Renderer> ().material.mainTexture = menu_used [(int)gifNum];
		} else 
			this.GetComponent<Renderer> ().material.mainTexture = menu_noItem [(int)gifNum];
	}

	//子オブジェクトであるchildObjectを説明欄へ移動させたりもどしたりするメソッド ←仕様書のメソッドの働きを書いてください。===
	//===↓ Start, Update以外のすべてのメソッドの宣言の前に、フィールド変数のように「public」をつけてください。===
	public void showDetail(bool b){
		if(childObject.GetComponent<MainObjectMenuInstance>() != null){
			ObjectMover om = this.GetComponent<ObjectMover> ();
			scaling = true; //スケール変更をonに
			if (b) { //trueならframeの外へ
				Debug.Log ("ToOutSideFrame: " + objectType);
				isInsideFrame = false;// frameの外なので
				om.startMoving (childObject, detailPos); //移動開始
			} else { //falseならframeの中へ
				Debug.Log ("ToInsideFrame: " + objectType);
				baseChildPos.transform.position = this.transform.position;
				baseChildPos.transform.position += this.transform.up * -0.06f;
				baseChildPos.transform.rotation = this.transform.rotation;
				isInsideFrame = true;
				om.startMoving (childObject, baseChildPos); //移動開始
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

	public void pointOver(bool b) {
		if (nowFocus != b) {
			nowFocus = b;
			if (b) {
				GetComponent<Renderer> ().material.SetColor ("_EmissionColor", new Color(1f, 0.3f, 0.3f));
			} else {
				GetComponent<Renderer> ().material.SetColor ("_EmissionColor", new Color(0f, 0f, 0f));
			}
		}
	}

	//選択されていることを可視化する処理
	public void selectedMotion(bool selected){
		if (isSelected != selected) {
			if (selected) {
				/*
				Color c = Color.red;
				c.a = 0.6f;
				GetComponent<Renderer> ().material.SetColor ("_Color", c);*/
				Debug.Log ("selected : " + objectType);
				//baseChildPos更新
				baseChildPos.transform.position = childObject.transform.position;
				baseChildPos.transform.rotation = childObject.transform.rotation;
				baseChildPos.transform.localScale = childObject.transform.localScale + new Vector3(2f, 2f, 2f);
				this.GetComponent<ObjectMover_2> ().startMoving (childObject, baseChildPos.transform); //移動開始

			} else {
				//baseChildPos更新
				baseChildPos.transform.position = childObject.transform.position;
				baseChildPos.transform.rotation = childObject.transform.rotation;
				baseChildPos.transform.localScale = childObject.transform.localScale - new Vector3(2f, 2f, 2f);
				this.GetComponent<ObjectMover_2> ().startMoving (childObject, baseChildPos.transform); //移動開始


				//GetComponent<Renderer> ().material.SetColor ("_Color", originalColor);
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

	public void used(bool b) {
		isUsed = true;
		this.showDetail (false);
	}
}
