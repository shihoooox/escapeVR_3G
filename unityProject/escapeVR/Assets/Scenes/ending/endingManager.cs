using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class endingManager : MonoBehaviour {

	private float countSec;
	// Use this for initialization
	void Start () {
		countSec = 0f;
	}

	// Update is called once per frame
	void Update () {
		countSec += Time.deltaTime;
		if (countSec >= 5f) {
			SceneManager.LoadScene ("scene01");
			//this.GetComponent<SceneChanger> ().changeWidthFadeOut (1f, "scene01");
		}
	}
}
