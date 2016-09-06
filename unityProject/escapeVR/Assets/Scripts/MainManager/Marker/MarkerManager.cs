using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MarkerManager : MonoBehaviour {
	
	private List<GameObject> markers = new List<GameObject> ();


	// Use this for initialization
	void Start () {
		foreach (Transform child in transform) 
			markers.Add (child.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void focus(int objectType) {
		for (int i = 0; i < markers.Count; i++) {
			if (markers [i].GetComponent<MarkerInstance> ().objectType == objectType) {
				markers [i].GetComponent<MarkerInstance> ().isFocusOn = true;
			} else {
				markers [i].GetComponent<MarkerInstance> ().isFocusOn = false;
			}
		}
	}

	public void moveTo(int objectType) {
		for (int i = 0; i < markers.Count; i++) {
			if (markers [i].GetComponent<MarkerInstance>().objectType == objectType) {
				ObjectMover om = this.GetComponent<ObjectMover> ();
				Cm cameraManager = Camera.main.gameObject.GetComponent<Cm> ();
				om.startMoving (cameraManager.c, markers [i].GetComponent<MarkerInstance> ().getDirectionLocation());
				break;
			}
		}
	}
}
