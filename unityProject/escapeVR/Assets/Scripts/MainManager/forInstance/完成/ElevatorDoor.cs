using UnityEngine;
using System.Collections;

public class ElevatorDoor : MonoBehaviour {

	//それぞれのドアにOMをつけておいてください

	public GameObject rightDoor;
	public GameObject leftDoor;
	private GameObject targetPosR;
	private GameObject targetPosL;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void forInstanceMotion(int actNum){	
		if(actNum == 1) {
			//ドアが開く処理
			targetPosR = new GameObject ();
			targetPosL = new GameObject ();
			targetPosR.transform.position = rightDoor.transform.position;
			targetPosL.transform.position = leftDoor.transform.position;
			Vector3 posR = targetPosR.transform.position;
			Vector3 posL = targetPosL.transform.position;
			posR.x -= 0.44f;
			posL.x += 0.44f;
			targetPosR.transform.position = posR;
			targetPosL.transform.position = posL;

			ObjectMover rd = rightDoor.GetComponent<ObjectMover>();
			ObjectMover ld = leftDoor.GetComponent<ObjectMover>();
			rd.startMoving (rightDoor, targetPosR);
			ld.startMoving (leftDoor, targetPosL);
			return;
		}else if(actNum == 2) {
			//ドアが閉まる処理
			targetPosR = new GameObject ();
			targetPosL = new GameObject ();
			targetPosR.transform.position = rightDoor.transform.position;
			targetPosL.transform.position = leftDoor.transform.position;
			Vector3 posR = targetPosR.transform.position;
			Vector3 posL = targetPosL.transform.position;
			posR.x += 0.44f;
			posL.x -= 0.44f;
			targetPosR.transform.position = posR;
			targetPosL.transform.position = posL;

			ObjectMover rd = rightDoor.GetComponent<ObjectMover>();
			ObjectMover ld = leftDoor.GetComponent<ObjectMover>();
			rd.startMoving (rightDoor, targetPosR);
			ld.startMoving (leftDoor, targetPosL);
			return;
		}
	}
}
