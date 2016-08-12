using UnityEngine;
using System.Collections;

public class SubObjectMenuFrame : MonoBehaviour {

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
		
	}


	//選択されていることを可視化する処理
	public void selected(bool selected){
		if(isSelected != selected){
			isSelected = selected;
			//ここに処理を書く
		}
		Debug.Log("未完成です");

	}

	//ユーザが取得したオブジェクトであれば、childObjectを表示させる
	public void appear(bool active){
		if(isActive != active){
			childObject.SetActive(active);
			isActive = active;
		}
	}
}
