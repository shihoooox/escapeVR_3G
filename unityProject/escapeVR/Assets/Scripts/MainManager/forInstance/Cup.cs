using UnityEngine;
using System.Collections;

public class Cup : MonoBehaviour {
	
	// Use this for initialization
	public GameObject alcohol;
	public GameObject lope;
	public bool isIncludeAlcohol = false;
	public bool isIncludeLope = false;
	void Start () {
		alcohol.SetActive (false);
		lope.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	}

	public bool isReadyToFire() {
		return isIncludeLope && isIncludeAlcohol;
	}

	public void forInstanceMotion(int actNum){	
		if (actNum == 1) { //アルコール入れる
			alcohol.SetActive (true);
			this.isIncludeAlcohol = true;
		} else if(actNum == 2) { //ロープ入れる
			lope.SetActive(true);
			this.isIncludeLope = true;
		}
	}
}
