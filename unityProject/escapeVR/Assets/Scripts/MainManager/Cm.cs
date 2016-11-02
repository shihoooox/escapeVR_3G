using UnityEngine;
using System.Collections;

public class Cm : MonoBehaviour {
	public GameObject c;
	public GameObject rayPoint;
	public float rayPoint_rotate_x;
	public float rayPoint_rotate_y;
	public float rayPoint_rotate_z;
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
		rayPoint.transform.Rotate (rayPoint_rotate_x, rayPoint_rotate_y, rayPoint_rotate_z);
	}
}
