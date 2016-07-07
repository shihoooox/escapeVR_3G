using UnityEngine;
using System.Collections;

public class MainObjectMenuInstance : MonoBehaviour {

	public String description;
	public Vector3 homePos;
	private bool nowPos;
	private bool changePos;

	// Use this for initialization
	void Start () {
		homePos = this.translate.position;
		nowPos = false;
		changePos = false;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void moveDetailPos(bool b){
		Debug.LOG("未完成です");
		changePos = b; // changePos アイテムがある場所 false：リスト true：拡大
		if(nowPos != changePos) { //--(1)
			if(changePos){
				this.ObjectMover.moveObject(GameObject object, transform, 1, 2);
				nowPos = true;
			} else {
				this.ObjectMover.moveObject(GameObject object, homePos, 1, 2);
				nowPos = false;
			}
		}
	}

	void actOnDetail(int inObjectType, int actNum){
		Debug.LOG("未完成です");
		if (this.getComponent<MinaObjectMenuForm> != null) {

			this.getComponent<MainObjectMenuFrame>.objectType;
			switch(inObjectType){
			case 0:
				if (actNum == 0) {
				}
					break;
				default:
					break;
			}
	
		}
	}
}
