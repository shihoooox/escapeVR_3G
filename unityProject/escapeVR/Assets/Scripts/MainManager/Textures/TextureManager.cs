using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TextureManager : MonoBehaviour {
	private List<Texture> menu_normal;
	// Use this for initialization
	void Start () {
		/*
		string currentDir = System.IO.Directory.GetCurrentDirectory ();
		Debug.Log (currentDir);
		string menu_normal_texPath = currentDir + "\\Assets\\Texture\\menu_normal";
		string[] tmpstr = System.IO.Directory.GetFiles (menu_normal_texPath);
		for (int i = 0; i < tmpstr.Length; i++) {
			if(tmpstr[i].IndexOf(".meta") == -1) Debug.Log (tmpstr [i]);
		}
		*/
		System.OperatingSystem os = System.Environment.OSVersion;
		Debug.Log (os.ToString());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
