using UnityEngine;
using System.Collections;

public class ObjectOnGame : MonoBehaviour {

	public List<GameObject> itemList;
	private int objectType;

	// Use this for initialization
	void Start () {
	}
	
	void Update () {
	}

	// 特殊動作を実行する
	public void actOnDetail(int actNum){
		switch (objectType){
		case 1:
			WineBottle bottle = this.GetComponent<WineBottle>();
			bottle.forInstanceMotion(objectType, actNum);
			break;
		case 2:
			Alcohol al = this.GetComponent< Alcohol >();
			al.forInstanceMotion(objectType, actNum);
			break;
		case 3:
			Iron iron = this.GetComponent<Iron>();
			iron.forInstanceMotion(objectType, actNum);
			break;
		case 4:
			WoodenStick ws = this.GetComponent<Iron>();
			ws.forInstanceMotion(objectType, actNum);
			break;
		case 5:
			Ice ice = this.GetComponent<Iron>();
			ice.forInstanceMotion(objectType, actNum);
			break;
		case 6:
			Cup cup = this.GetComponent<Iron>();
			cup.forInstanceMotion(objectType, actNum);
			break;
		case 7:
			String str = this.GetComponent<Iron>();
			str.forInstanceMotion(objectType, actNum);
			break;
		case 8:
			Lighter lig = this.GetComponent<Iron>();
			lig.forInstanceMotion(objectType, actNum);
			break;
		case 9:
			Hammer hammer = this.GetComponent<Iron>();
			hammer.forInstanceMotion(objectType, actNum);
			break;
		case 10:
			Key key = this.GetComponent<Iron>();
			key.forInstanceMotion(objectType, actNum);
			break;
		case 11:
			AlcoholInCup aic = this.GetComponent<Iron>();
			aic.forInstanceMotion(objectType, actNum);
			break;
		case 12:
			Candle candle = this.GetComponent<Iron>();
			candle.forInstanceMotion(objectType, actNum);
			break;
		case 13:
			Plate plate = this.GetComponent<Iron>();
			plate.forInstanceMotion(objectType, actNum);
			break;
		case 14:
			BilliardCue bc = this.GetComponent<Iron>();
			bc.forInstanceMotion(objectType, actNum);
			break;
		case 15:
			BilliardBall bb = this.GetComponent<Iron>();
			bb.forInstanceMotion(objectType, actNum);
			break;
		case 16:
			RefrigeratorDoor rf = this.GetComponent<Iron>();
			rd.forInstanceMotion(objectType, actNum);
			break;
		case 17:
			Chair01 chair01 = this.GetComponent<Iron>();
			chair01.forInstanceMotion(objectType, actNum);
			break;
		case 18:
			Keyhole kh = this.GetComponent<Iron>();
			kh.forInstanceMotion(objectType, actNum);
			break;
		case 19:
			PasswordLocker pl = this.GetComponent<Iron>();
			pl.forInstanceMotion(objectType, actNum);
			break;
		case 20:
			シャッター ** = this.GetComponent<Iron>();
			**.forInstanceMotion(objectType, actNum);
			break;
		case 21:
			ElevatorButton eb = this.GetComponent<Iron>();
			eb.forInstanceMotion(objectType, actNum);
			break;
		case 22:
			ElevatorButton eb = this.GetComponent<Iron>();
			eb.forInstanceMotion(objectType, actNum);
			break;
		case 23:
			ElevatorButton eb = this.GetComponent<Iron>();
			eb.forInstanceMotion(objectType, actNum);
			break;
		case 37:
			ElevatorDoor ed = this.GetComponent<Iron>();
			ed.forInstanceMotion(objectType, actNum);
			break;
		default:
			break;
		}
	}
}
