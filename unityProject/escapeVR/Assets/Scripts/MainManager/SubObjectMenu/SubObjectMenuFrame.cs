using UnityEngine;
using System.Collections;

public class SubObjectMenuFrame : MonoBehaviour {

	public GameObject childObject;
	public bool isSelected;
	public bool onScreen;
	public bool isActive;
	public int objectType;
	private Color originalColor;
	public Texture[] menu_normal;
	private float gifNum = 0;

	// Use this for initialization
	void Start () {
		isSelected = false;
		onScreen = false;
		//isActive = false; //初めから表示されているかどうかはオブジェクトによって異なるのでインスペクタで調整する(デフォはfalse)
		originalColor = GetComponent<Renderer> ().material.color;
	}
	
	// Update is called once per frame
	void Update () {

		gifNum = (Time.time * 15) % menu_normal.Length;
		this.GetComponent<Renderer> ().material.mainTexture = menu_normal [(int)gifNum];
		
	}


	//選択されていることを可視化する処理
	public void selectedMotion(bool selected){
		
		if(isSelected != selected){
			if (selected) {
				Color c = Color.red;
				c.a = 0.6f;
				GetComponent<Renderer> ().material.SetColor ("_Color", c);
			} else {
				GetComponent<Renderer> ().material.SetColor ("_Color", originalColor);
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
}
