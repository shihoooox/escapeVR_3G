using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MarkerManager : MonoBehaviour {

	public GameObject marker01;
	public GameObject marker02;
	public GameObject marker03;
	public GameObject marker04;
	public GameObject marker05;
	private List<GameObject> markers = new List<GameObject> ();


	// Use this for initialization
	void Start () {
		markers.Add (marker01);
		markers.Add (marker02);
		markers.Add (marker03);
		markers.Add (marker04);
		markers.Add (marker05);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void moveTo(int objectType) {
		for (int i = 0; i < markers.Count; i++) {
			if (markers [i].GetComponent<MarkerInstance>().objectType == objectType) {
				ObjectMover om = this.GetComponent<ObjectMover> ();
				om.startMoving (Camera.main.gameObject, markers [i].GetComponent<MarkerInstance> ().getDirectionLocation());
			}
		}
	}
}
