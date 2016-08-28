using UnityEngine;
using System.Collections;

public class SubObjectMenuFrame : MonoBehaviour {

	public GameObject childObject;
	public bool isSelected;
	public bool onScreen;
	public bool isActive;
	public bool isUsed;
	public int objectType;
	public Texture[] menu_normal;//普通のメニューテクスチャ
	public Texture[] menu_noItem; //アイテムなしのメニューテクスチャ
	public Texture[] menu_used; //使用済みのアイテム
	private float gifNum = 0; //コマを保存するやつ

	// Use this for initialization
	void Start () {

		Debug.Log (System.IO.Directory.GetCurrentDirectory());

		isSelected = false;
		isUsed = false;
		onScreen = false;
		//isActive = false; //初めから表示されているかどうかはオブジェクトによって異なるのでインスペクタで調整する(デフォはfalse)
		foreach (Transform child in this.transform) 
			childObject = child.gameObject;
		isActive = childObject.activeSelf;
	}
	
	// Update is called once per frame
	void Update () {

		//テクスチャ関連
		int fps = 15;
		gifNum = (Time.time * fps) % menu_normal.Length;
		if (childObject.activeSelf) {
			if(!isUsed)
				this.GetComponent<Renderer> ().material.mainTexture = menu_normal [(int)gifNum];
			else
				this.GetComponent<Renderer> ().material.mainTexture = menu_used [(int)gifNum];
		} else 
			this.GetComponent<Renderer> ().material.mainTexture = menu_used [(int)gifNum];//menu_noItem [(int)gifNum];
	}


	//選択されていることを可視化する処理
	public void selectedMotion(bool selected){
		
		if(isSelected != selected){
			if (selected) {
				GetComponent<Renderer> ().material.SetColor ("_EmissionColor", Color.red); //とりあえず選択されてたら赤くしとく
			} else {
				GetComponent<Renderer> ().material.SetColor ("_EmissionColor", Color.black); //とりあえず（以下略
			}
			isSelected = selected;
		}

	}

	//ユーザが取得したオブジェクトであれば、childObjectを表示させる
	public void appear(bool active){
		Debug.Log ("appear obj: " + objectType + " appear->" + active);
		if(isActive != active){
			childObject.SetActive(active);
			isActive = active;
		}
	}

	public void used(bool b) {
		isUsed = b;
	}
}
