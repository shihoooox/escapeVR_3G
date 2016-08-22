using UnityEngine;
using System.Collections;

public class ObjectSynthesizer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int synthesizeInMenu(int targetObjNum, int selectedObjNum) {

		//メニュー合成処理
		//if(targetObjNum == 1 && selectedObjNum == 2) return 3; //Debug

		if(targetObjNum == 3 && selectedObjNum == 4) return 9;
		if(targetObjNum == 1 && selectedObjNum == 9) return 10;
		if(targetObjNum == 6 && selectedObjNum == 2) return 11;
		if(targetObjNum ==11 && selectedObjNum == 7) return 13;


		return -2;

	}
}
