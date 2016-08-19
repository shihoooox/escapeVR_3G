using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ElevatorButton : MonoBehaviour {

	private bool isBlight;
	private float blightCounter;
	public GameObject ElevatorDoorManager;
	private List<GameObject> blightnessList = new List<GameObject>();
	//光らせたいボタン自身につけて

	// Use this for initialization
	void Start () {
		//StartCoroutine(BlinkerCoroutine());
		isBlight = false;
		blightCounter = 0f;
		foreach (Transform child in this.transform) {//光るもののみ格納
			if (child.name.Contains ("チ"))
				blightnessList.Add (child.gameObject); 
			else if (child.name.Contains ("押")) {
				blightnessList.Add (child.gameObject);
				foreach (Transform grandChild in child)
					blightnessList.Add (grandChild.gameObject);
			}
		}
		for (int i = 0; i < blightnessList.Count; i++) {
			blightnessList[i].GetComponent<Renderer> ().material.EnableKeyword ("_EMISSION");
			blightnessList[i].GetComponent<Renderer> ().material.SetColor ("_EmissionColor", new Color (0, 0, 0));
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (isBlight) 
			blightCounter += Time.deltaTime;

		if (blightCounter >= 1.0f) {
			isBlight = false;
			this.forInstanceMotion (2);//光らせなくする
			blightCounter = 0f;
		}
	}

	public void forInstanceMotion(int actNum){	
		if (actNum == 1) {
			//光る処理
			for (int i = 0; i < blightnessList.Count; i++) {
				blightnessList[i].GetComponent<Renderer> ().material.EnableKeyword ("_EMISSION");
				blightnessList[i].GetComponent<Renderer> ().material.SetColor ("_EmissionColor", new Color (1, 1, 1));
			}
			return;

		} else if (actNum == 2) {
			for (int i = 0; i < blightnessList.Count; i++) {
				blightnessList[i].GetComponent<Renderer> ().material.EnableKeyword ("_EMISSION");
				blightnessList[i].GetComponent<Renderer> ().material.SetColor ("_EmissionColor", new Color (0, 0, 0));
			}
			return;
		} else if (actNum == 3) {
			blightCounter = 0f;
			this.forInstanceMotion (1); //光らせる
			isBlight = true;
		} else if(actNum == 4) {
			this.forInstanceMotion (3);
			this.ElevatorDoorManager.GetComponent<ElevatorDoor> ().forInstanceMotion (3); //door open
		} else if(actNum == 5) {
			this.forInstanceMotion (3);
			this.ElevatorDoorManager.GetComponent<ElevatorDoor> ().forInstanceMotion (2); //door close
		}
	}
}
