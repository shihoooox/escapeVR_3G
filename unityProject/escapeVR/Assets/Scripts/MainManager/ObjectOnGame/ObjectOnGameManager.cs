using UnityEngine;
using System.Collections;

public class ObjectOnGameManager : MonoBehaviour {

	public List<GameObject> itemList;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	// objectTypeと対応するgameObjectのactOnDetail(actNum)を実行する
	public void motion(int objectType, int actNum){
		ObjectOnGame tmp = this.GetComponent<ObjectOnGame>();
		//tmp.objectType = objectType;
		tmp.actOnDetail(actNum);		
	}
}
