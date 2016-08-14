using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MarkerManager : MonoBehaviour {

	public GameObject marker01;
	public GameObject marker02;
	public GameObject marker03;
	public GameObject marker04;
	public GameObject marker05;
	public GameObject marker06;
	private List<GameObject> markers = new List<GameObject> ();


	// Use this for initialization
	void Start () {
		markers.Add (marker01);
		markers.Add (marker02);
		markers.Add (marker03);
		markers.Add (marker04);
		markers.Add (marker05);
		markers.Add (marker06);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void focus(int objectType) {
		for (int i = 0; i < markers.Count; i++) {
			if (markers [i].GetComponent<MarkerInstance> ().objectType == objectType) {
				markers[i].GetComponent<Renderer> ().material.color = Color.red;
			} else {
				markers[i].GetComponent<Renderer> ().material.color = Color.white;
			}
		}
	}

	public void moveTo(int objectType) {
		for (int i = 0; i < markers.Count; i++) {
			if (markers [i].GetComponent<MarkerInstance>().objectType == objectType) {
				ObjectMover om = this.GetComponent<ObjectMover> ();
				Cm cameraManager = Camera.main.gameObject.GetComponent<Cm> ();
				om.startMoving (cameraManager.c, markers [i].GetComponent<MarkerInstance> ().getDirectionLocation());
			}
		}
	}
}
