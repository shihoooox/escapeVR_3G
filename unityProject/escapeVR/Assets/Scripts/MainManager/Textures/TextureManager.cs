using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TextureManager : MonoBehaviour {
	public Texture[] menu_normal;
	public Texture[] menu_noItem;
	public Texture[] menu_used;
	public Texture[] menu_selected;
	// Use this for initialization
	void Start () {
		/*Debug.Log (System.IO.Directory.Exists("Assets"));
		for (int i = 0; i < 75; i++) {
			string textureNum = i < 10 ? "0" + i : i + ""; 
			menu_used [i] = Resources.Load ("Assets/Texture/menu_used_15/usedObject 2_000" + textureNum + ".png") as Texture;
		}
		*/

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
