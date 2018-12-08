using UnityEngine;
using System.Collections;

public class Ice : MonoBehaviour {

	private bool thisGot;
	private float count = 0f;
	private bool countTrigger = false;
	private GameObject target;

	// Use this for initialization
	void Start () {
		target = new GameObject ();
		thisGot = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (countTrigger) {
			count += Time.deltaTime;
			if (count >= 1f) {
				target.transform.position = this.transform.position;
				target.transform.rotation = this.transform.rotation;
				target.transform.localScale = new Vector3 (0f, 0f, 0f);
				this.GetComponent<ObjectMover_2> ().startMoving (this.gameObject, target.transform);
				countTrigger = false;
			}
		}
	}

	public void getThis(bool b) {
		this.thisGot = b;
	}

	public bool isGot() {
		return this.thisGot;
	}

	public void forInstanceMotion(int actNum){	
		if (actNum == 1) {
			//溶ける処理 (タイマー用のサークルが1秒くらいをカウントした後、0.5秒くらいかけて小さく なって消える)
			countTrigger = true;
			return;
		}
	}
}
