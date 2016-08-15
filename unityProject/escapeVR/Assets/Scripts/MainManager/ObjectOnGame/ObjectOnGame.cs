using UnityEngine;
using System.Collections;

public class ObjectOnGame : MonoBehaviour {

	public int objectType;

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
			WoodenStick ws = this.GetComponent<WoodenStick>();
			ws.forInstanceMotion(objectType, actNum);
			break;
		case 5:
			Ice ice = this.GetComponent<Ice>();
			ice.forInstanceMotion(objectType, actNum);
			break;
		case 6:
			Cup cup = this.GetComponent<Cup>();
			cup.forInstanceMotion(objectType, actNum);
			break;
		case 7:
			String str = this.GetComponent<String>();
			str.forInstanceMotion(objectType, actNum);
			break;
		case 8:
			Lighter lig = this.GetComponent<Lighter>();
			lig.forInstanceMotion(objectType, actNum);
			break;
		case 9:
			Hammer hammer = this.GetComponent<Hammer>();
			hammer.forInstanceMotion(objectType, actNum);
			break;
		case 10:
			Key key = this.GetComponent<Key>();
			key.forInstanceMotion(objectType, actNum);
			break;
		case 11:
			AlcoholInCup aic = this.GetComponent<AlcoholInCup>();
			aic.forInstanceMotion(objectType, actNum);
			break;
		case 12:
			Candle candle = this.GetComponent<Candle>();
			candle.forInstanceMotion(objectType, actNum);
			break;
		case 13:
			Plate plate = this.GetComponent<Plate>();
			plate.forInstanceMotion(objectType, actNum);
			break;
		case 14:
			BilliardCue bc = this.GetComponent<BilliardCue>();
			bc.forInstanceMotion(objectType, actNum);
			break;
		case 15:
			BilliardBall bb = this.GetComponent<BilliardBall>();
			bb.forInstanceMotion(objectType, actNum);
			break;
		case 16:
			RefrigeratorDoor rf = this.GetComponent<RefrigeratorDoor>();
			rd.forInstanceMotion(objectType, actNum);
			break;
		case 17:
			Chair01 chair01 = this.GetComponent<Chair01>();
			chair01.forInstanceMotion(objectType, actNum);
			break;
		case 18:
			Keyhole kh = this.GetComponent<Keyhole>();
			kh.forInstanceMotion(objectType, actNum);
			break;
		case 19:
			PasswordLocker pl = this.GetComponent<PasswordLocker>();
			pl.forInstanceMotion(objectType, actNum);
			break;
		case 20:
			Shutter sh = this.GetComponent<シャッター>();
			sh.forInstanceMotion(objectType, actNum);
			break;
		case 21:
			ElevatorButton eb = this.GetComponent<ElevatorButton>();
			eb.forInstanceMotion(objectType, actNum);
			break;
		case 22:
			ElevatorButton eb = this.GetComponent<ElevatorButton>();
			eb.forInstanceMotion(objectType, actNum);
			break;
		case 23:
			ElevatorButton eb = this.GetComponent<ElevatorButton>();
			eb.forInstanceMotion(objectType, actNum);
			break;
		case 37:
			ElevatorDoor ed = this.GetComponent<ElevatorDoor>();
			ed.forInstanceMotion(objectType, actNum);
			break;
		default:
			break;
		}
	}

	public void appear(bool b) {
		this.setActive(b);
	}
}
