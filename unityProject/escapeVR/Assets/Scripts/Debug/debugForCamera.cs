using UnityEngine;
using System.Collections;

public class debugForCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 delta = new Vector3 (Time.deltaTime, 0, 0);
		this.transform.position += delta;
	}
}
