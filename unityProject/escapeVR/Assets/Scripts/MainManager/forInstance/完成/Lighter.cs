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
			GameObject in_target = new GameObject();
			in_target.transform.parent = this.transform;
			// intargetを同階層のオブジェクトに

			in_target.transform.position = huta.transform.position;
			in_target.transform.rotation = huta.transform.rotation;
			in_target.transform.localScale = huta.transform.localScale;
			in_target.transform.Rotate (-90, 0, 0);
			ObjectMover_2 om2 = this.GetComponent<ObjectMover_2>();
			om2.startMoving(huta, in_target.transform);
			return;
		} else if(actNum == 3){
			//	蓋が閉じる処理
			// 火が消える処理(パーティクルをOFFにする)
			ParticleSystem ps = particle.GetComponent<ParticleSystem>();
			ps.Stop();
			GameObject in_target = new GameObject();
			in_target.transform.parent = this.transform;
			// intargetを同階層のオブジェクトに

			in_target.transform.position = huta.transform.position;
			in_target.transform.rotation = huta.transform.rotation;
			in_target.transform.localScale = huta.transform.localScale;
			in_target.transform.Rotate (90, 0, 0);
			ObjectMover_2 om2 = this.GetComponent<ObjectMover_2>();
			om2.startMoving(huta, in_target.transform);
			return;
		}
	}
}
