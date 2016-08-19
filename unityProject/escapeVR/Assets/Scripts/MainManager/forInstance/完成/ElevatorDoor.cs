using UnityEngine;
using System.Collections;

public class ElevatorDoor : MonoBehaviour {

	//それぞれのドアにOMをつけておいてください

	//実際のEVはドアの開閉に約2.5秒、開きっぱなしが約5秒

	public GameObject rightDoor;
	public GameObject leftDoor;
	private GameObject targetPosR;
	private GameObject targetPosL;
	private Vector3 doorHomePos_L;
	private Vector3 doorHomePos_R;

	private bool nowMotion;
	private float openCounter;
	private float closeNum = 7; //ドアが開き始めてから7秒で閉まる処理を実行する

	// Use this for initialization
	void Start () {
		targetPosR = new GameObject ();
		targetPosL = new GameObject ();
		nowMotion = false;
		openCounter = 0f;
		doorHomePos_L = leftDoor.transform.position;
		doorHomePos_R = rightDoor.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		if (nowMotion) 
			openCounter += Time.deltaTime;

		if (openCounter >= closeNum) {
			this.forInstanceMotion (2);
			nowMotion = false;
			openCounter = 0f;
		}

	}

	public void forInstanceMotion(int actNum){	
		if(actNum == 1) {
			if (nowMotion) //すでに空いてたらキャンセル
				return;

			Debug.Log ("open door");
			//ドアが開く処理
			//targetPosR = new GameObject ();
			//targetPosL = new GameObject ();
			targetPosR.transform.position = doorHomePos_R;
			targetPosL.transform.position = doorHomePos_L;
			Vector3 posR = targetPosR.transform.position;
			Vector3 posL = targetPosL.transform.position;
			posR.z -= 0.44f;
			posL.z += 0.44f;
			targetPosR.transform.position = posR;
			targetPosL.transform.position = posL;

			ObjectMover rd = rightDoor.GetComponent<ObjectMover>();
			ObjectMover ld = leftDoor.GetComponent<ObjectMover>();
			rd.startMoving (rightDoor, targetPosR);
			ld.startMoving (leftDoor, targetPosL);
			return;
		} else if(actNum == 2) {
			if (!nowMotion) //すでに閉まってたらキャンセル
				return;
			
			//ドアが閉まる処理
			//targetPosR = new GameObject ();
			//targetPosL = new GameObject ();
			targetPosR.transform.position = doorHomePos_R;
			targetPosL.transform.position = doorHomePos_L;

			ObjectMover rd = rightDoor.GetComponent<ObjectMover>();
			ObjectMover ld = leftDoor.GetComponent<ObjectMover>();
			rd.startMoving (rightDoor, targetPosR);
			ld.startMoving (leftDoor, targetPosL);
			return;
		} else if(actNum == 3) {
			this.forInstanceMotion (1);
			nowMotion = true;
		}
	}
}
