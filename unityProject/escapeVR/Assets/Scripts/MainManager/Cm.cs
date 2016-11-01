using UnityEngine;
using System.Collections;

public class Cm : MonoBehaviour {
	public GameObject c;
	public GameObject rayPoint;
	public float pointDist;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setRayPoint(Ray ray) {
		rayPoint.transform.position = ray.GetPoint (pointDist);
		rayPoint.transform.rotation = Camera.main.transform.rotation;
		rayPoint.transform.Rotate (-45f, 0f, 0f);
	}
}
