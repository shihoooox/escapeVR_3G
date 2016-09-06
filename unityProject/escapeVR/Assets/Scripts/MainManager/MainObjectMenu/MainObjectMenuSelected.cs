using UnityEngine;
using System.Collections;

public class MainObjectMenuSelected : MonoBehaviour {
	public Texture[] tex;
	private float gifNum = 0; //コマを保存するやつ
	// Use this for initialization
	void Start () {
		this.tex = this.transform.root.GetComponent<MainManager> ().TextureManager_G.GetComponent<TextureManager> ().menu_selected;
		this.GetComponent<Renderer> ().material.SetColor ("_EmissionColor", new Color (15, 296, 255));
	}
	
	// Update is called once per frame
	void Update () {
		//テクスチャ関連
		int fps = 15;
		gifNum = (Time.time * fps) % tex.Length;
		this.GetComponent<Renderer> ().material.mainTexture = tex [(int)gifNum];
	}
}
