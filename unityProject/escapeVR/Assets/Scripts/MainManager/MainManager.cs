using UnityEngine;
using UnityEngine.VR;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainManager : MonoBehaviour {
	public GameObject MainObjectMenuManager_G; //MainObjectMenuManagerのGameObject
	public GameObject SubObjectMenuManager_G; //SubObjectMenuManagerのGameObject
	public GameObject MarkerManager_G; //MarkerManagerのGameObject
	public GameObject TextureManager_G; //TextureManagerのgameObject
	public GameObject ObjectOnGameManager_G; //ObjectOnGameManagerのgameObject
	public GameObject TutorialManager_G; //TutorialManagerのgameObject
	public GameObject AudioPlayer_G; //AudioPlayerのgameObject
	public GameObject MainCamera_G;
	public int stageNumber;

	private int selectedObjectNum;

	// Use this for initialization
	void Start () {
		selectedObjectNum = -2;

		//もしステージが0ならチュートリアル401を呼び出す
		if(this.stageNumber == 0) this.startZeroStage();
	}

	void startZeroStage() {
		bool tmp = this.TutorialManager_G.GetComponent<TutorialManager> ().next (401);
	}
	
	// Update is called once per frame
	void Update () {
		//key: Q (Qキーを押すとメニューが出て話すと上に消える処理)
		if (Input.GetKeyDown (KeyCode.Q)) {
			this.pressKeyDown_Q ();
		} else if (Input.GetKeyUp (KeyCode.Q)) {
			this.pressKeyUp_Q ();
		}
		
 		//each frame
		this.eachFrame();

		//key: W (Wキーを押すと選択される処理)
		if (Input.GetKeyDown (KeyCode.W)) {
			this.pressKeyDown_W ();
		}

		//key:E (Eキーを押すとオブジェクトが消えるデバッグ)
		if (Input.GetKeyDown (KeyCode.E)) {
			this.pressKeyDown_E ();
		}
	}



	public TextureManager getTextureManager() {
		return this.TextureManager_G.GetComponent<TextureManager> ();
	}


	void eachFrame() {
		Ray ray_ = new Ray (Camera.main.transform.position, Camera.main.transform.forward);
		RaycastHit hit_;
		this.MainCamera_G.GetComponent<Cm> ().setRayPoint (ray_);
		int focusObjectType = -2;
		int focusFrameType = -2;
		if (Physics.Raycast (ray_, out hit_, 100.0f)) {
			GameObject tmp = hit_.collider.gameObject;
			//Debug.Log ("ray : " + tmp.name + " " + tmp.transform.position);
			if (tmp.tag == "Marker") {
				focusObjectType = tmp.GetComponent<MarkerInstance> ().objectType;
			} else if (tmp.tag == "MainObjectMenuFrame") {
				focusObjectType = tmp.GetComponent<MainObjectMenuFrame> ().objectType;
				focusFrameType = tmp.GetComponent<MainObjectMenuFrame> ().objectType;
			} else if (tmp.tag == "MainObjectMenuInstance") {
				focusFrameType = 0;
			} else if (tmp.tag == "ObjectOnGame") {
				focusObjectType = tmp.GetComponent<ObjectOnGame> ().objectType;
			}
		}
		//Debug.Log (focusObjectType);
		MarkerManager_G.GetComponent<MarkerManager> ().focus (focusObjectType);
		MainObjectMenuManager_G.GetComponent<MainObjectMenuManager> ().focus (focusObjectType);
		MainObjectMenuManager_G.GetComponent<MainObjectMenuManager> ().moveMarker (focusFrameType);
		ObjectOnGameManager_G.GetComponent<ObjectOnGameManager> ().focus (focusObjectType);
	}

	void pressKeyDown_Q() {
		//チュートリアル処理
		if (this.stageNumber == 0 && this.TutorialManager_G.GetComponent<TutorialManager> ().currentTutorialNum == 401)
			this.TutorialManager_G.GetComponent<TutorialManager> ().next (402);

		MainObjectMenuManager MomManager = MainObjectMenuManager_G.GetComponent<MainObjectMenuManager> ();
		SubObjectMenuManager SomManager = SubObjectMenuManager_G.GetComponent<SubObjectMenuManager> ();
		MomManager.moveToScreen (true);
		SomManager.moveToScreen (true);
	}

	void pressKeyUp_Q() {
		MainObjectMenuManager MomManager = MainObjectMenuManager_G.GetComponent<MainObjectMenuManager> ();
		SubObjectMenuManager SomManager = SubObjectMenuManager_G.GetComponent<SubObjectMenuManager> ();
		MomManager.moveToScreen (false);
		SomManager.moveToScreen (false);
	}

	void pressKeyDown_W() {
		Debug.Log ("W pressed");
		Ray ray = new Ray (Camera.main.transform.position, Camera.main.transform.forward);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, 100.0f)) {
			int type = -2; //衝突したobjectType

			//Debug.Log ("hit type : " + hit.collider.gameObject.tag + ", name : " + hit.collider.gameObject.name);

			//hitしたのがMainObjectMenuFrameなら
			if (hit.collider.gameObject.tag == "MainObjectMenuFrame") {
				//usedでもなく未取得でもなければ実行
				if (!hit.collider.gameObject.GetComponent<MainObjectMenuFrame> ().isUsed &&
				    hit.collider.gameObject.GetComponent<MainObjectMenuFrame> ().childObject.activeSelf) {

					MainObjectMenuFrame frame = hit.collider.gameObject.GetComponent<MainObjectMenuFrame> (); //objectTypeを知るためにframeのインスタンス取得
					MainObjectMenuManager MomManager = MainObjectMenuManager_G.GetComponent<MainObjectMenuManager> (); //managerのインスタンス取得
					SubObjectMenuManager SomManager = SubObjectMenuManager_G.GetComponent<SubObjectMenuManager> ();
					type = frame.objectType;
					//Debug.Log ("P_key pressed, hit type : " + type);
					if (type > 0) {
						if (!frame.isSelected) {
							//チュートリアル
							if (this.stageNumber == 0 && this.TutorialManager_G.GetComponent<TutorialManager> ().currentTutorialNum == 402 && type == 40)
								this.TutorialManager_G.GetComponent<TutorialManager> ().next (403);
							
							MomManager.indicateSelected (type);
							SomManager.indicateSelected (type + 100);
							selectedObjectNum = type; //選択されているオブジェクトを更新
						} else {

							//チュートリアル
							if (this.stageNumber == 0 && this.TutorialManager_G.GetComponent<TutorialManager> ().currentTutorialNum == 406 && type == 41)
								this.TutorialManager_G.GetComponent<TutorialManager> ().next (407);

							MomManager.showObjectsDetail (type);
						}
					}

				}
			}

			//hitしたのがMainObjectMenuInstanceなら
			else if (hit.collider.gameObject.tag == "MainObjectMenuInstance") {

				//Debug.Log ("parentsName: " + hit.collider.gameObject.transform.parent.gameObject.name +
				//	", grandParentsName: " + hit.collider.gameObject.transform.parent.gameObject.transform.parent.gameObject.name);

				int targetObjNum = hit.collider.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<MainObjectMenuFrame> ().objectType;
				int syntheSizedNum = this.GetComponent<ObjectSynthesizer> ().synthesizeInMenu (targetObjNum, selectedObjectNum);
				//Debug.Log ("合成 target: " + targetObjNum + " - selected: " + selectedObjectNum + " => " + syntheSizedNum);

				//もしnull(-2)でなければ合成処理
				if (syntheSizedNum != -2) {
					
					//チュートリアル
					if (this.stageNumber == 0 && this.TutorialManager_G.GetComponent<TutorialManager> ().currentTutorialNum == 407 && syntheSizedNum == 43) {
						//Dialogを変える
						this.TutorialManager_G.GetComponent<TutorialManager> ().next (408);
						//open ev door
						this.AudioPlayer_G.GetComponent<AudioPlayer>().play(2, false, false, 0);
						this.AudioPlayer_G.GetComponent<AudioPlayer>().play(2, false, true, 3);
						this.ObjectOnGameManager_G.GetComponent<ObjectOnGameManager> ().motion (37, 1);
					}
					
					//MOMのオブジェクト削除
					MainObjectMenuManager_G.GetComponent<MainObjectMenuManager> ().unsetObject (targetObjNum);
					MainObjectMenuManager_G.GetComponent<MainObjectMenuManager> ().unsetObject (selectedObjectNum);

					//SOMのオブジェクト削除
					SubObjectMenuManager_G.GetComponent<SubObjectMenuManager> ().unsetObject (targetObjNum + 100);
					SubObjectMenuManager_G.GetComponent<SubObjectMenuManager> ().unsetObject (selectedObjectNum + 100);

					//変化後のObject表示
					MainObjectMenuManager_G.GetComponent<MainObjectMenuManager> ().setObject (syntheSizedNum);
					SubObjectMenuManager_G.GetComponent<SubObjectMenuManager> ().setObject (syntheSizedNum + 100);
				} else {
					if (targetObjNum == 8) {//ライターだったら
						hit.collider.gameObject.GetComponent<Lighter> ().forInstanceMotion (4);
						//Debug.Log ("ライター動作");
					} else if(targetObjNum == 6) { //カップだったら
						if (selectedObjectNum == 2) {
							hit.collider.gameObject.GetComponent<Cup> ().forInstanceMotion (1);// set alcohol
							MainObjectMenuManager_G.GetComponent<MainObjectMenuManager> ().unsetObject (2);
							SubObjectMenuManager_G.GetComponent<SubObjectMenuManager> ().unsetObject (2+100);
						} else if (selectedObjectNum == 7) {
							hit.collider.gameObject.GetComponent<Cup> ().forInstanceMotion (2); // set lope
							MainObjectMenuManager_G.GetComponent<MainObjectMenuManager> ().unsetObject (7);
							SubObjectMenuManager_G.GetComponent<SubObjectMenuManager> ().unsetObject (7+100);
						}
					}
				}
			}

			//hitしたのがMarkerなら
			else if (hit.collider.gameObject.tag == "Marker") {
				MarkerInstance instance = hit.collider.gameObject.GetComponent<MarkerInstance> ();
				MarkerManager manager = MarkerManager_G.GetComponent<MarkerManager> ();
				type = instance.objectType;
				//Debug.Log ("move to " + type);
				manager.moveTo (type);

				if (this.stageNumber == 1 && type == 80) {
					this.GetComponent<SceneChanger> ().changeWidthFadeOut (1f, "ending");
				}

				if (this.TutorialManager_G.GetComponent<TutorialManager> ().currentTutorialNum == 408) {
					Debug.Log ("to opening");
					//TutorialManager_G.GetComponent<TutorialManager> ().next (409);
					this.GetComponent<SceneChanger> ().changeWidthFadeOut (1f, "opening");
				}
			}

			//hitしたのがObjectOnGameなら
			else if (hit.collider.gameObject.tag == "ObjectOnGame") {
				int hitObjectNum = hit.collider.gameObject.GetComponent<ObjectOnGame> ().objectType; //hitしたObjNumを保存
				int staticActNum = ObjectOnGameManager.getStaticActNumFromObjectType (hitObjectNum, hit.collider.gameObject); //決まったactNumを保存

				if (staticActNum == -3) { //取得可能なオブジェクトの場合
					Debug.Log("hit num:" + hitObjectNum);
					this.ObjectOnGameManager_G.GetComponent<ObjectOnGameManager> ().unsetObject (hitObjectNum);
					this.MainObjectMenuManager_G.GetComponent<MainObjectMenuManager> ().setObject (hitObjectNum);
					this.SubObjectMenuManager_G.GetComponent<SubObjectMenuManager> ().setObject (hitObjectNum + 100);


					//居酒屋のチラシでチュートリアル進行
					if (hitObjectNum == 41) {
						if (this.TutorialManager_G.GetComponent<TutorialManager> ().currentTutorialNum == 405) {
							TutorialManager_G.GetComponent<TutorialManager> ().next (406);
						}
					}

				} else if (staticActNum != -2) { //決まったactNumがあれば(-2でなければ)それを実行
					this.ObjectOnGameManager_G.GetComponent<ObjectOnGameManager> ().motion (hitObjectNum, staticActNum);
				} else {

					//冷蔵庫
					if (hitObjectNum == 16) {
						if (selectedObjectNum == 10) {
							Debug.Log ("冷蔵庫開錠");
							this.ObjectOnGameManager_G.GetComponent<ObjectOnGameManager>().motion(hitObjectNum, 7); //開錠
							MainObjectMenuManager_G.GetComponent<MainObjectMenuManager> ().unsetObject (selectedObjectNum);
							SubObjectMenuManager_G.GetComponent<SubObjectMenuManager> ().unsetObject (selectedObjectNum + 100);
						}
					}

					//パスワードロッカー
					if (hitObjectNum == 19) {
						if (selectedObjectNum == 12) {
							Debug.Log ("パスワード開錠"); //パスワード手動解除未対応（今はパスワードプレートを選択してキーパネルに触れると開錠するしくみになっている）
							this.ObjectOnGameManager_G.GetComponent<ObjectOnGameManager>().motion(hitObjectNum, 0); //パスワードロック解除
							this.ObjectOnGameManager_G.GetComponent<ObjectOnGameManager>().motion(hitObjectNum, 0); //パスワードロック解除
							this.ObjectOnGameManager_G.GetComponent<ObjectOnGameManager>().motion(hitObjectNum, 0); //パスワードロック解除
							this.ObjectOnGameManager_G.GetComponent<ObjectOnGameManager>().motion(hitObjectNum, 0); //パスワードロック解除
							MainObjectMenuManager_G.GetComponent<MainObjectMenuManager> ().unsetObject (selectedObjectNum);
							SubObjectMenuManager_G.GetComponent<SubObjectMenuManager> ().unsetObject (selectedObjectNum + 100);
						}
					}

					//キャンドル
					if (hitObjectNum == 38) {
						if (selectedObjectNum == 6 && MainObjectMenuManager_G.GetComponent<MainObjectMenuManager>().getInstance(6).GetComponent<Cup>().isReadyToFire()) { //アルコールランプ（小さいコップ設置）
							MainObjectMenuManager_G.GetComponent<MainObjectMenuManager> ().unsetObject (selectedObjectNum);
							SubObjectMenuManager_G.GetComponent<SubObjectMenuManager> ().unsetObject (selectedObjectNum + 100);
							hit.collider.gameObject.GetComponent<Candle>().forInstanceMotion(2);
						} else if (selectedObjectNum == 5) { //氷設置
							MainObjectMenuManager_G.GetComponent<MainObjectMenuManager> ().unsetObject (selectedObjectNum);
							SubObjectMenuManager_G.GetComponent<SubObjectMenuManager> ().unsetObject (selectedObjectNum + 100);
							hit.collider.gameObject.GetComponent<Candle>().forInstanceMotion(3);
						} else if (selectedObjectNum == 8 && MainObjectMenuManager_G.GetComponent<MainObjectMenuManager>().getInstance(8).GetComponent<Lighter>().isReadyToFire() &&
							hit.collider.gameObject.GetComponent<Candle>().isAlreadyToFire()) { //燃やす
							MainObjectMenuManager_G.GetComponent<MainObjectMenuManager> ().unsetObject (selectedObjectNum);
							SubObjectMenuManager_G.GetComponent<SubObjectMenuManager> ().unsetObject (selectedObjectNum + 100);
							hit.collider.gameObject.GetComponent<Candle>().forInstanceMotion(1);
						}
					}

					//カードパネル
					if (hitObjectNum == 39) {
						if (selectedObjectNum == 40) {

							TutorialManager_G.GetComponent<TutorialManager> ().next (404);
							//
							MainObjectMenuManager_G.GetComponent<MainObjectMenuManager> ().unsetObject (selectedObjectNum);
							SubObjectMenuManager_G.GetComponent<SubObjectMenuManager> ().unsetObject (selectedObjectNum + 100);
						}
					}

					//16階のボタン
					if (hitObjectNum == 22) {
						if (this.TutorialManager_G.GetComponent<TutorialManager> ().currentTutorialNum == 404) {
							TutorialManager_G.GetComponent<TutorialManager> ().next (405);
							//エレベーターの駆動音を再生する処理
							this.AudioPlayer_G.GetComponent<AudioPlayer>().play(1, false, true, 0); //加速音を再生
							this.AudioPlayer_G.GetComponent<AudioPlayer>().play(2, true, true, 7000); //ループ音を7秒後に再生
						}
					}

				}

			}
		}
	}

	void pressKeyDown_E() {
		Debug.Log ("E key pressed");

		if (this.stageNumber == 0) {
			this.GetComponent<SceneChanger> ().changeWidthFadeOut (1f, "opening");
		} else if (this.stageNumber == 1) {
			
		}
	}
}
