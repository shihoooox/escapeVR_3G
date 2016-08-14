using UnityEngine;
using System.Collections;

public class ObjectOnGameManager : MonoBehaviour {

	public List<GameObject> itemList;
	public GameObject tmp1;//アイテム数だけある　addする
	public GameObject tmp2;
	public GameObject tmp3;
	public GameObject tmp4;
	public GameObject tmp5;

	// Use this for initialization
	void Start () {
		itemList.Add (tmp1);
		itemList.Add (tmp2);
		itemList.Add (tmp3);
		itemList.Add (tmp4);
		itemList.Add (tmp5);

	}
	
	// Update is called once per frame
	void Update () {
	}

	// objectTypeと対応するgameObjectのactOnDetail(actNum)を実行する
	public void motion(int objectType, int actNum){
		for (int i = 0; i < itemList.Count; i++) {
			ObjectOnGame tmp = itemList[i].GetComponent<MainObjectMenuFrame> ();
			if (tmp.objectType == objectType) {
				tmp.actOnDetail(actNum);
			}
		}
	}
}
