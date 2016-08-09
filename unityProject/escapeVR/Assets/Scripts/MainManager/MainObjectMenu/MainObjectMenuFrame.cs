using UnityEngine;
using System.Collections;

public class MainObjectMenuFrame : MonoBehaviour {

	public GameObject childObject;
	public bool isSelected;
	public bool onScreen;
	public bool isActive;
	public int objectType;

	// Use this for initialization
	void Start () {
		isSelected = false;
		onScreen = false;
		isActive = false;
	}
	
	// Update is called once per frame
	void Update () {
		//childObject.GetComponent<MainObjectMenuInstance>().homePos = this.transform.position; //Frameはマスターの子オブジェクトなので位置を合わせる必要なし
	}

	//子オブジェクトであるchildObjectを説明欄へ移動させたりもどしたりするメソッド ←仕様書のメソッドの働きを書いてください。===
	//===↓ Start, Update以外のすべてのメソッドの宣言の前に、フィールド変数のように「public」をつけてください。===
	public void showDetail(bool b){
		if(childObject.GetComponent<MainObjectMenuInstance> != null){
			MainObjectMenuInstance child = childObject.GetComponent<MainObjectMenuInstance>;
			child.moveDetailPos (b);
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
		//===無駄な処理回避のため、すでにtoとonScreenが同じであれば処理をしない条件分岐を作成してください。(*1のような処理)===
		if(isSelected != selected){
			isSelected = selected;
			//ここに処理を書く
		}
		Debug.Log("未完成です");

	}

	//自分がユーザが取得したオブジェクトであれば、childObjectを表示させる
	public void appear(bool active){
		if(isActive != active){
			childObject.SetActive(active);
			isActive = active;
		}
	}
}
