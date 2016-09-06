using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainObjectMenuManager : MonoBehaviour {

	public GameObject inCamera;
	public GameObject outCamera;
	public GameObject marker;
	public GameObject detailPos;
	public List<GameObject> frameList = new List<GameObject>(); 
	private int selectedObjectType; //選択されているobjectTypeを保持する、なければ-1
	private GameObject markerPoint; //ポインタ移動用のGameObject
	private int currentMarkerNum = -2;

	// Use this for initialization
	void Start () {

		foreach (Transform child in this.transform) {
			if(!child.name.Contains("detail")) 
				frameList.Add (child.gameObject);
			markerPoint = new GameObject (); //ポインタ移動用のGameObject
		}

		selectedObjectType = -1;
		//Debug.Log ("MainObjectMenuManagerは未完成です");

		foreach (GameObject frame in frameList) {
			frame.GetComponent<MainObjectMenuFrame>().menu_normal = 
				this.transform.root.gameObject.GetComponent<MainManager> ().getTextureManager ().menu_normal;
			frame.GetComponent<MainObjectMenuFrame>().menu_noItem = 
				this.transform.root.gameObject.GetComponent<MainManager> ().getTextureManager ().menu_noItem;
			frame.GetComponent<MainObjectMenuFrame>().menu_used = 
				this.transform.root.gameObject.GetComponent<MainManager> ().getTextureManager ().menu_used;
		}

	}
	
	// Update is called once per frame
	void Update () {
	}

	public GameObject getInstance(int in_objectType) {
		foreach(GameObject eachFrame in frameList) 
			if (eachFrame.GetComponent<MainObjectMenuFrame> ().objectType == in_objectType) 
				foreach (Transform eachInstance_1 in eachFrame.transform)
					foreach (Transform eachInstance_2 in eachInstance_1)
						return eachInstance_2.gameObject;
		return null;
	}

	public void moveMarker(int markerNum) {

		if (currentMarkerNum != markerNum) {
			Debug.Log ("移動開始 to " + markerNum);
			if (markerNum == -2) {
				markerPoint.transform.localScale = new Vector3 (0f, 0f, 0f);
				this.GetComponent<ObjectMover_2> ().startMoving (marker, markerPoint.transform);
			} else if(markerNum == 0) {
				markerPoint.transform.position = detailPos.transform.position;
				markerPoint.transform.position += detailPos.transform.up * 0.06f;
				markerPoint.transform.rotation = detailPos.transform.rotation;
				markerPoint.transform.localScale = new Vector3 (0.9f, 0.9f, 0.9f);
				this.GetComponent<ObjectMover_2> ().startMoving (marker, markerPoint.transform);
			} else {
				foreach (GameObject c in frameList) {
					if (markerNum == c.GetComponent<MainObjectMenuFrame> ().objectType) {
						markerPoint.transform.position = c.transform.position;
						markerPoint.transform.position += c.transform.up * 0.06f;
						markerPoint.transform.rotation = c.transform.rotation;
						markerPoint.transform.localScale = new Vector3 (0.2f, 0.2f, 0.2f);
						this.GetComponent<ObjectMover_2> ().startMoving (marker, markerPoint.transform);
						break;
					}
				}
			}
			currentMarkerNum = markerNum;
		}

	}

	// メニューのオブジェクトを表示させる(アイテムを取ったことにする)
	public void setObject(int objectType){
		for (int i = 0; i < frameList.Count; i++) {
			MainObjectMenuFrame tmp = frameList[i].GetComponent<MainObjectMenuFrame> ();
			if (tmp.objectType == objectType) {
				tmp.appear(true);
			}
		}
	}

	// メニューのオブジェクトを非表示にさせる(アイテムを使ったことにする)
	public void unsetObject(int objectType){
		for (int i = 0; i < frameList.Count; i++) {
			MainObjectMenuFrame tmp = frameList[i].GetComponent<MainObjectMenuFrame> ();
			if (tmp.objectType == objectType) {
				tmp.used(true);
			}
		}
	}

	// メニューを画面から外す
	public void moveMenuForm(bool toHome){
		//何の処理かわからんので一応放置、MoveToScreenで間に合うのでは？ by Okamoto
	}

	public void focus(int objectType) {
		for (int i = 0; i < frameList.Count; i++) {
			frameList [i].GetComponent<MainObjectMenuFrame> ().pointOver (
				objectType == frameList[i].GetComponent<MainObjectMenuFrame>().objectType
			);
		}
	}

	// アイテムを全部デセレクトしてからobjectTypeのアイテムをセレクトする。
	public void indicateSelected(int objectType) {
		for (int i = 0; i < frameList.Count; i++) {
			MainObjectMenuFrame tmp = frameList[i].GetComponent<MainObjectMenuFrame> ();
			tmp.selectedMotion(tmp.objectType == objectType);
		}
		if(selectedObjectType != objectType) {
			selectedObjectType = objectType; //selectedObjectType更新
		}
	}

	// セレクトされてるアイテムの詳細を表示する
	public void showObjectsDetail(int objectType){
		for (int i = 0; i < frameList.Count; i++) {
			MainObjectMenuFrame frame = frameList[i].GetComponent<MainObjectMenuFrame> ();
			if(frame.objectType == objectType || !frame.isInsideFrame) 
				frame.showDetail (frame.objectType == selectedObjectType); //frameにないものを戻して選択されたものを詳細欄に送る
		}
	}

	// 個々のモーションがあればframeListからobjectTypeのオブジェクトのmakeActを 呼び出す
	public void extraMotion(int objectType, int actNum){
		Debug.Log ("extraMotionは未完成です");
		for (int i = 0; i < frameList.Count; i++) {
			MainObjectMenuFrame tmp = frameList[i].GetComponent<MainObjectMenuFrame> ();
			if (tmp.objectType == objectType) {
				tmp.makeAct (actNum);
			}
		}
	}

	// メニューを画面に表示させたり外したりするメソッド
	public void moveToScreen(bool to){
		ObjectMover om = this.GetComponent<ObjectMover> ();
		bool onScreen;
		if (to) {
			Transform cameraTransform = Camera.main.transform;
			this.transform.eulerAngles = cameraTransform.eulerAngles;
			onScreen = true;
			Debug.Log ("move menu in Camera");
			om.startMoving (inCamera);
		} else {
			Debug.Log ("move menu out Camera");
			onScreen = false;
			om.startMoving (outCamera);
		}
		for (int i = 0; i < frameList.Count; i++) {
			frameList [i].GetComponent<MainObjectMenuFrame> ().onScreen = onScreen;
		}
	}

}
