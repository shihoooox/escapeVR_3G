using UnityEngine;
using System.Collections;

public class topManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.W)) {
			this.GetComponent<SceneChanger> ().changeWidthFadeOut (1f, "scene00");
		}
	}
}
