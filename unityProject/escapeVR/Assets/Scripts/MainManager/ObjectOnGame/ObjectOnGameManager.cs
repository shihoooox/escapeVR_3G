using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectOnGameManager : MonoBehaviour {

	public List<GameObject> itemList;
	private int pastFocusObjectNum = -2;

	// Use this for initialization
	void Start () {
		foreach (Transform child in transform) {
			if (!child.name.Equals ("model"))
				itemList.Add (child.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	}

	// objectTypeと対応するgameObjectのactOnDetail(actNum)を実行する
	public void motion(int objectType, int actNum){
		for (int i = 0; i < itemList.Count; i++) {
			ObjectOnGame tmp = itemList[i].GetComponent<ObjectOnGame> ();
			if (tmp.objectType == objectType) {
				tmp.actOnDetail(actNum);
				return;
			}
		}
	}

	public void setObject(int objectType) {
		for (int i = 0; i < itemList.Count; i++) {
			if (itemList [i].GetComponent<ObjectOnGame> ().objectType == objectType) {
				itemList [i].GetComponent<ObjectOnGame> ().appear (true);
			}
		}
	}

	public void unsetObject(int objectType) {
		for (int i = 0; i < itemList.Count; i++) {
			if (itemList [i].GetComponent<ObjectOnGame> ().objectType == objectType) {
				itemList [i].GetComponent<ObjectOnGame> ().appear (false);
			}
		}
	}

	public void focus(int objectNum) {
		//Debug.Log ("focus: " + objectNum);
		if (pastFocusObjectNum == 16 && objectNum != 16 && objectNum != 5) {//冷蔵庫が視界からはずれたらドアを閉める
			Debug.Log ("close fridge");
			this.motion (16, 6);
		}
			
		pastFocusObjectNum = objectNum;
	}

	public static int getStaticActNumFromObjectType(int objectType, GameObject gameObject) {

		if (objectType == 1 || objectType == 2 || objectType == 3 || objectType == 4 || objectType == 5 || objectType == 6
		    || objectType == 7 || objectType == 8) //zippo
			return -3;
		else if (objectType == 16) {
			if (!gameObject.GetComponent<RefrigeratorDoor> ().isLocked)
				return 5;
		}

		//パスワードロッカーのキーだったら、キーの番号をreturnする
		else if (objectType == 19)
			return -2;//return gameObject.GetComponent<PasswordKey> ().keyCode; //簡易的に-2を返す（動作はMainManagerのpressKeyDown_W()メソッド参照）

		else if (objectType == 23) //エレベータの階級ボタン光らすだけ
			gameObject.GetComponent<ObjectOnGame> ().actOnDetail (3);

		else if (objectType == 21) //エレベータの階級ボタン光らすだけ
			gameObject.GetComponent<ObjectOnGame> ().actOnDetail (3);

		else if(objectType == 22) //エレベータの階級ボタン光らすだけ
			gameObject.GetComponent<ObjectOnGame> ().actOnDetail (3);

		else if (objectType == 35) //エレベータのopenボタン
			gameObject.GetComponent<ObjectOnGame> ().actOnDetail (4);

		else if (objectType == 36) //エレベータのcloseボタン
			gameObject.GetComponent<ObjectOnGame> ().actOnDetail (5);

		return -2;
	}
}
