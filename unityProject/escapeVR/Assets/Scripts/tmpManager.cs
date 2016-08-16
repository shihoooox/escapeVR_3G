using UnityEngine;
using System.Collections;

public class tmpManager : MonoBehaviour {

	public GameObject target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.W)) {
			Debug.Log ("W");
			this.pressDown_W ();
		}
	}

	void pressDown_W() {
		ObjectMover_2 om = this.GetComponent<ObjectMover_2> ();
		om.startMoving (this.gameObject, target.transform);
	}
}
