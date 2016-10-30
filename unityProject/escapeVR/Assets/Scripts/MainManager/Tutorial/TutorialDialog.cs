using UnityEngine;
using System.Collections;

public class TutorialDialog : MonoBehaviour {

	public int dialogType;
	public float period;  //周期
	public float amplitude;  //振幅
	public float x,y;
	private float inAlpha=1.0f; //透明度
	public bool fadein;
	private float num=0.0f;


	// Use this for initialization
	void Start () {
		GetComponent<Renderer> ().material.color = new Color(0, 0, 0, 0.0f);
		//Debug.Log ("test");

	}
	
	// Update is called once per frame
	void Update () {
		//透明度0%ならオブジェクトが上下する
		if (GetComponent<Renderer> ().material.color.a >= 1.0f) {
			this.transform.position += new Vector3 (x, Mathf.Sin(period*Time.time)*amplitude, y);
		}

		//フェード
		if (fadein) {     //イン
			if (num > 1.0) {
				return;
			}
			num+=Time.deltaTime;
			GetComponent<Renderer> ().material.color = new Color(0, 0, 0, inAlpha*num);
			//Debug.Log ("test");
		} else {        //アウト
			if (num < 0.0) {
				inAlpha = 1.0f;
				return;
			}
			num-=Time.deltaTime;
			GetComponent<Renderer> ().material.color = new Color(0, 0, 0, num);
		}
	}

	//自身をフェードインさせたりフェードアウトさせたりする
	void show (bool b) {
		if (b) {
			fadein = true;
		} else {
			fadein = false;
		}
	}
}
