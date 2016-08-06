using UnityEngine;
using System.Collections;

public class MainObjectMenuInstance : MonoBehaviour {

	public String description;
	public Vector3 homePos;
	private bool nowPos;
	private bool changePos;

	// Use this for initialization
	void Start () {
		homePos = this.translate.position;
		nowPos = false;
		changePos = false;
	}
	
	// Update is called once per frame
	void Update () {
	}

	// メニューのオブジェクトを表示させる(アイテムを取ったことにする)
	public void setObject(int objectType){
	}

	// メニューのオブジェクトを非表示にさせる(アイテムを使ったことにする)
	public void unsetObject(int objectType){
	}

	// メニューを画面から外す
	public void moveMenuForm(bool toHome){
	}

	// アイテムを全部デセレクトしてからobjectTypeのアイテムをセレクトする。
	public void indicateSelected(int objectType){
	}

	// セレクトされてるアイテムの詳細を表示する
	public void showObjectsDetail(bool pushed){
	}

	// 個々のモーションがあればframeListからobjectTypeのオブジェクトのmakeActを 呼び出す
	public void extraMotion(int objectType, int actNum){
	}

	// メニューを画面に表示させたり外したりするメソッド
	public void moveToScreen(bool to, transform cameraPos){
	}



}
