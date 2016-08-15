using UnityEngine;
using System.Collections;

public class Lighter : MonoBehaviour {

	public GameObject particle;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void forInstanceMotion(int actNum){
		if(actNum == 1) {
			// 火がつく処理(パーティクルをONにする)
			ParticleSystem ps = particle.GetComponent<ParticleSystem>();
			ps.Play();
			return;
		} else if(actNum == 2){
			// 火が消える処理(パーティクルをOFFにする)
			ParticleSystem ps = particle.GetComponent<ParticleSystem>();
			ps.Stop();
			return;
		} else if(actNum == 3){
			//	蓋が開く処理
			return;
		} else if(actNum == 4){
			//	蓋が閉じる処理
			return;
		}
	}
}
