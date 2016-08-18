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
			bottle.forInstanceMotion(actNum);
			break;
		case 2:
			Alcohol al = this.GetComponent< Alcohol >();
			al.forInstanceMotion(actNum);
			break;
		case 3:
			Iron iron = this.GetComponent<Iron>();
			iron.forInstanceMotion(actNum);
			break;
		case 4:
			WoodenStick ws = this.GetComponent<WoodenStick>();
			ws.forInstanceMotion(actNum);
			break;
		case 5:
			Ice ice = this.GetComponent<Ice>();
			ice.forInstanceMotion(actNum);
			break;
		case 6:
			Cup cup = this.GetComponent<Cup>();
			cup.forInstanceMotion(actNum);
			break;
		case 7:
			StringLope strl = this.GetComponent<StringLope>();
			strl.forInstanceMotion(actNum);
			break;
		case 8:
			Lighter lig = this.GetComponent<Lighter>();
			lig.forInstanceMotion(actNum);
			break;
		case 9:
			Hammer hammer = this.GetComponent<Hammer>();
			hammer.forInstanceMotion(actNum);
			break;
		case 10:
			Key key = this.GetComponent<Key>();
			key.forInstanceMotion(actNum);
			break;
		case 11:
			AlcoholInCup aic = this.GetComponent<AlcoholInCup>();
			aic.forInstanceMotion(actNum);
			break;
		case 12:
			Candle candle = this.GetComponent<Candle>();
			candle.forInstanceMotion(actNum);
			break;
		case 13:
			Plate plate = this.GetComponent<Plate>();
			plate.forInstanceMotion(actNum);
			break;
		case 14:
			BilliardCue bc = this.GetComponent<BilliardCue>();
			bc.forInstanceMotion(actNum);
			break;
		case 15:
			BilliardBall bb = this.GetComponent<BilliardBall>();
			bb.forInstanceMotion(actNum);
			break;
		case 16:
			RefrigeratorDoor rf = this.GetComponent<RefrigeratorDoor>();
			rf.forInstanceMotion(actNum);
			break;
		case 17:
			Chair01 chair01 = this.GetComponent<Chair01>();
			chair01.forInstanceMotion(actNum);
			break;
		case 18:
			Keyhole kh = this.GetComponent<Keyhole>();
			kh.forInstanceMotion(actNum);
			break;
		case 19:
			PasswordLocker pl = this.GetComponent<PasswordLocker>();
			pl.forInstanceMotion(actNum);
			break;
		case 20:
			Shutter sh = this.GetComponent<Shutter>();
			sh.forInstanceMotion(actNum);
			break;
		case 21:
			ElevatorButton eb_1 = this.GetComponent<ElevatorButton>();
			eb_1.forInstanceMotion(actNum);
			break;
		case 22:
			ElevatorButton eb_16 = this.GetComponent<ElevatorButton>();
			eb_16.forInstanceMotion(actNum);
			break;
		case 23:
			ElevatorButton eb_other = this.GetComponent<ElevatorButton>();
			eb_other.forInstanceMotion(actNum);
			break;
		case 35:
			ElevatorButton eb_open = this.GetComponent<ElevatorButton>();
			eb_open.forInstanceMotion(actNum);
			break;
		case 36:
			ElevatorButton eb_close = this.GetComponent<ElevatorButton>();
			eb_close.forInstanceMotion(actNum);
			break;
		case 37:
			ElevatorDoor ed = this.GetComponent<ElevatorDoor>();
			ed.forInstanceMotion(actNum);
			break;
		default:
			break;
		}
	}

	public void appear(bool b) {
		this.gameObject.SetActive(b);
	}
}
