using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;     //UIを使用可能にする

public class SwitchScenes : MonoBehaviour {

	public float speed = 0.01f;  //透明化の速さ
	float alfa = 0.0f;    //A値を操作するための変数
	float red, green, blue;    //RGBを操作するための変数
	bool fade = false; //フェードのON/OFF

	// Use this for initialization
	void Start () {
		//Panelの色を取得
		red = GetComponent<Image>().color.r;
		green = GetComponent<Image>().color.g;
		blue = GetComponent<Image>().color.b;
	}

	// Update is called once per frame
	void Update () {
		
		//フェード開始
		if (Input.GetKey (KeyCode.A)) {
			Debug.Log ("a");
			fade = true;
		}

		//フェード
		if(fade == true && alfa < 1.5f){
			GetComponent<Image> ().color = new Color (red, green, blue, alfa);
			alfa += speed;
		}

		//シーン切り替え
		//Debug.Log (alfa);
		if(alfa >= 1.5f){
			SceneManager.LoadScene (1);
		}	
	}
}
