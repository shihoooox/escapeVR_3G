using UnityEngine;
using System.Collections;

public class Candle : MonoBehaviour {

	public GameObject particle;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void forInstanceMotion(int actNum){	
		if(actNum == 1) {
			//火がつく処理(パーティクルをONにする)
			ParticleSystem ps = particle.GetComponent<ParticleSystem>();
			ps.Play();
			return;
		}	
	}
}
