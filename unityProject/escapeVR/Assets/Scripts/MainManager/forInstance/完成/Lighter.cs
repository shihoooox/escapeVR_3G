using UnityEngine;
using System.Collections;

public class Lighter : MonoBehaviour {

	// OM_2もつけてね

	public GameObject particle;
	public GameObject huta;
	
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
			//	蓋が開く処理
			Transform in_target;
			in_target = huta.transform;
			in_target.transform.Rotate (-135, 0, 0);
			ObjectMover_2 om2 = this.GetComponent<ObjectMover_2>();
			om2.startMoving(huta, in_target);
			return;
		} else if(actNum == 3){
			//	蓋が閉じる処理
			// 火が消える処理(パーティクルをOFFにする)
			ParticleSystem ps = particle.GetComponent<ParticleSystem>();
			ps.Stop();
			Transform in_target;
			in_target = huta.transform;
			in_target.transform.Rotate (135, 0, 0);
			ObjectMover_2 om2 = this.GetComponent<ObjectMover_2>();
			om2.startMoving(huta, in_target);
			return;
		}
	}
}
