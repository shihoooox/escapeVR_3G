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
		childObject.getComponent<MainObjectMenuInstance>().homePos = this.transform.position;
	}

	//子オブジェクトであるchildObjectを説明欄へ移動させたりもどしたりするメソッド ←仕様書のメソッドの働きを書いてください。===
	//===↓ Start, Update以外のすべてのメソッドの宣言の前に、フィールド変数のように「public」をつけてください。===
	public void showDetail(bool b){
		if(childObject.getComponent<MainObjectMenuInstance> != null){
			chaildObject.getComponent<MainObjectMenuInstance>.moveDetailPos(b);
		}
	}

	//
	public void makeAct(int actNum){
		if(childObject.getComponent<MainObjectMenuInstance>() != null){
			childObject.getComponent<MainObjectMenuInstance>().actOnDetail(objectType, actNum);
		}
	}

	void selectedMotion(bool selected){
		//===無駄な処理回避のため、すでにtoとonScreenが同じであれば処理をしない条件分岐を作成してください。(*1のような処理)===
		isSelected = selected;
		Debug.LOG("未完成です");

	}

	void appear(bool active){
		if(isActive != active){ // ---*1
			childObject.setActive(active);
			isActive = active;
		}
	}

	void moveToScreen(bool to, Transform cameraPos){
		Debug.LOG("未完成です");
		//===無駄な処理回避のため、すでにtoとonScreenが同じであれば処理をしない条件分岐を作成してください。(*1のような処理)===
		onScreen = to;

		//<(1)について>
		//===moveToScreenはFlameと子オブジェクトを丸ごとカメラの前に持ってきたり外したりするメソッドなので===
		//===ObjectMove.MoveObjectの第一引数はthisです。===
		//===(childObjectはthisの子なのでthisを移動すればchildObjectも移動します)===

		//<(2)について>
		//===最終的には、仕様書の処理内容にあるように、ObjectMover.moveObjectの第二引数のtransformは===
		//===水平移動になるよう、cameraPosから計算してください。===

		if(to){
			//カメラの中へ
			ObjectMover.moveObject (childObject/*(1)*/, transform/*(2)*/, 1, 2);
		}else{
			//カメラの外へ
			ObjectMover.moveObject (childObject/*(1)*/, transform/*(2)*/, 1, 2);
		}
	}
}
