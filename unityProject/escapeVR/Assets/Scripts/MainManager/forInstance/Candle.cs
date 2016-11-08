using UnityEngine;
using System.Collections;

public class Candle : MonoBehaviour {

	public GameObject particle;
	public GameObject cup;
	public GameObject ice;
	public GameObject plate;

	private bool settedCup;
	private bool settedLighter;
	private bool settedIce;

	// Use this for initialization
	void Start () {
		cup.SetActive (false);
		ice.SetActive (false);
		plate.SetActive (false);

		this.settedCup = false;
		this.settedLighter = false;
		settedIce = false;
	}
	
	// Update is called once per frame
	void Update () {
		/*if (Input.GetKeyDown (KeyCode.A)) {
			this.forInstanceMotion (1);
		}*/
	}

	public bool isReadyToFire() {
		return cup.activeSelf && ice.activeSelf;
	}

	public void forInstanceMotion(int actNum){	
		if(actNum == 1) {
			//火がつく処理(パーティクルをONにする)
			ParticleSystem ps = particle.GetComponent<ParticleSystem>();
			ps.Play();
			ice.GetComponent<Ice> ().forInstanceMotion (1);

			settedLighter = true;
			return;
		} else if(actNum == 2) { //キャンドル（cup）を設置する
			cup.SetActive(true);

			this.settedCup = true;
			return;
		} else if(actNum == 3) { //氷を(ice)設置する
			ice.SetActive(true);
			plate.SetActive (true);

			settedIce = true;
			return;
		}
	}

	//火をつけていいかどうか（ライターを適応していいかどうか）
	public bool isAlreadyToFire() {
		return this.settedCup;
	}
}
