/*
07/20 イージング関数を作成した.
08/06 仕様を満たすようにするため、moveObjectメソッドを改良した.
08/13 回転とスケールの処理を追加した.
*/

using UnityEngine;
using System.Collections;
using System;

/*
 * このコンポーネントに紐付けしたゲームオブジェクトに対してイージングを行う.
 */
public class ObjectMover_2 : MonoBehaviour
{


	public enum EasingFunction
	{
		Linear,//等速に移動(moveType0に相当)
		EaseInQuad,//だんだん速くなる(moveType3に相当)
		EaseOutQuad,//だんだん遅くなる(moveType2に相当)
		EaseInOutQuad//だんだん速くなってだんだん遅くなる(moveType1に相当)
	}

	private Transform target;//移動する先のオブジェクトを指定
	private GameObject movedObject;
	public float T0;//移動する時間を指定
	public bool trigger;//trueでイージング発動する.イージングが終わると、falseになる.
	public EasingFunction easingFunction;//イージング関数のタイプ

	private int moveType;
	private float duration;//nowTime(s)

	private Vector3 diffPosition;//ターゲットのオブジェクトの位置の差を格納するベクトル
	private Vector3 diffRotation;//ターゲットのオブジェクトの回転の差を格納するベクトル
	private Vector3 diffScale;//ターゲットのオブジェクトのスケールの差を格納するベクトル

	private Vector3 initPosition;//イージング前のゲームオブジェクトの初期位置
	private Vector3 initRotation;//イージング前のゲームオブジェクトの初期回転
	private Vector3 initScale;//イージング前のゲームオブジェクトの初期スケール

	private bool inOutSwitch;//InOutを行うための真ん中切り替え(falseならIn、trueならOut中)
	private float tempDuration;//InOutのOutからのduration


	// Use this for initialization
	void Start()
	{
		/*
		moveType = 0;
		duration = 0;

		//移動させるオブジェクトの初期位置を定める
		initPosition = movedObject.transform.position;

		//移動させるオブジェクトの初期回転を定める
		initRotation = movedObject.transform.eulerAngles;

		//移動させるオブジェクトの初期スケールを定める
		initScale = movedObject.transform.localScale;


		//ターゲットのオブジェクトの位置と移動させるオブジェクトの初期位置の差を定める
		diffPosition = target.position - initPosition;

		//ターゲットのオブジェクトの回転と移動させるオブジェクトの初期回転の差を定める
		diffRotation = target.eulerAngles - initRotation;

		//ターゲットのオブジェクトのスケールと移動させるオブジェクトの初期スケールの差を定める
		diffScale = target.localScale - initScale;


		Debug.Log("xP:" + diffPosition.x + "  yP:" + diffPosition.y + "  zP:" + diffPosition.z);
		Debug.Log("xR:" + diffRotation.x + "  yR:" + diffRotation.y + "  zR:" + diffRotation.z);
		Debug.Log("xS:" + diffScale.x + "  yS:" + diffScale.y + "  zS:" + diffScale.z);
		//Debug.Log ("値：" + movedObject.transform.eulerAngles.x);
		//Debug.Log(diff);
		*/
	}

	// Update is called once per frame
	void Update()
	{
		switch (easingFunction) {
		case EasingFunction.Linear:
			moveType = 0;
			break;
		case EasingFunction.EaseInQuad:
			moveType = 3;
			break;
		case EasingFunction.EaseOutQuad:
			moveType = 2;
			break;
		case EasingFunction.EaseInOutQuad:
			moveType = 1;
			break;
		}

		if(trigger) moveObject(movedObject,target,moveType,T0);//velocity(1flame)
	}


	public void startMoving(GameObject in_movedObject, Transform in_target) {
		this.movedObject = in_movedObject;
		this.target = in_target;

		moveType = 0;
		duration = 0;

		//移動させるオブジェクトの初期位置を定める
		initPosition = movedObject.transform.position;

		//移動させるオブジェクトの初期回転を定める
		initRotation = movedObject.transform.eulerAngles;

		//移動させるオブジェクトの初期スケールを定める
		initScale = movedObject.transform.localScale;


		//ターゲットのオブジェクトの位置と移動させるオブジェクトの初期位置の差を定める
		diffPosition = target.position - initPosition;

		//ターゲットのオブジェクトの回転と移動させるオブジェクトの初期回転の差を定める
		diffRotation = target.eulerAngles - initRotation;

		//ターゲットのオブジェクトのスケールと移動させるオブジェクトの初期スケールの差を定める
		diffScale = target.localScale - initScale;

		trigger = true;

	}


	void moveObject(GameObject movedObject,Transform transform,int moveType,float T0)
	{
		/*
		 *	easingする前 
		 */
		if (!trigger)
		{
			initPosition = movedObject.transform.position;
			initRotation = movedObject.transform.eulerAngles;
			initScale = movedObject.transform.localScale;

			diffPosition = transform.position - initPosition;
			diffRotation = target.transform.eulerAngles - initRotation;
			diffScale = target.transform.localScale - initScale;

			return;
		}


		/*
		 *	時間が移動する時間を超えた時(easingが終了した時)
		 */
		if (T0 < duration)
		{
			trigger = false;//easingが終わったのでfalseにする.
			duration = 0;
			movedObject.transform.position = transform.position;
			movedObject.transform.eulerAngles = transform.eulerAngles;
			movedObject.transform.localScale = transform.localScale;
			return;
		}

		switch (moveType)
		{

		//等速に移動(moveType0に相当)
		case 0:
			movedObject.transform.position =
				new Vector3(
					linear(duration, T0, diffPosition.x),
					linear(duration, T0, diffPosition.y),
					linear(duration, T0, diffPosition.z)
				) + initPosition;
			movedObject.transform.eulerAngles =
				new Vector3(
					linear(duration, T0, diffRotation.x),
					linear(duration, T0, diffRotation.y),
					linear(duration, T0, diffRotation.z)
				) + initRotation;
			movedObject.transform.localScale =
				new Vector3(
					linear(duration, T0, diffScale.x),
					linear(duration, T0, diffScale.y),
					linear(duration, T0, diffScale.z)
				) + initScale;
			break;

			//だんだん速くなる(moveType3に相当)
		case 3:
			movedObject.transform.position =
				new Vector3(
					easeInQuad(duration, T0, diffPosition.x),
					easeInQuad(duration, T0, diffPosition.y),
					easeInQuad(duration, T0, diffPosition.z)
				) + initPosition;
			movedObject.transform.eulerAngles =
				new Vector3(
					easeInQuad(duration, T0, diffRotation.x),
					easeInQuad(duration, T0, diffRotation.y),
					easeInQuad(duration, T0, diffRotation.z)
				) + initRotation;
			movedObject.transform.localScale =
				new Vector3(
					easeInQuad(duration, T0, diffScale.x),
					easeInQuad(duration, T0, diffScale.y),
					easeInQuad(duration, T0, diffScale.z)
				) + initScale;
			break;

			//だんだん遅くなる(moveType2に相当)
		case 2:
			movedObject.transform.position =
				new Vector3(
					easeOutQuad(duration, T0, diffPosition.x),
					easeOutQuad(duration, T0, diffPosition.y),
					easeOutQuad(duration, T0, diffPosition.z)
				) + initPosition;
			movedObject.transform.eulerAngles =
				new Vector3(
					easeOutQuad(duration, T0, diffRotation.x),
					easeOutQuad(duration, T0, diffRotation.y),
					easeOutQuad(duration, T0, diffRotation.z)
				) + initRotation;
			movedObject.transform.localScale =
				new Vector3(
					easeOutQuad(duration, T0, diffScale.x),
					easeOutQuad(duration, T0, diffScale.y),
					easeOutQuad(duration, T0, diffScale.z)
				) + initScale;
			break;

			//だんだん速くなってだんだん遅くなる(moveType1に相当)
		case 1:


			if (duration < T0 / 2)
			{
				//だんだん速くなる
				inOutSwitch = false;
				movedObject.transform.position =
					new Vector3(
						easeInQuad(duration, T0 / 2, diffPosition.x / 2),
						easeInQuad(duration, T0 / 2, diffPosition.y / 2),
						easeInQuad(duration, T0 / 2, diffPosition.z / 2)
					) + initPosition;
				movedObject.transform.eulerAngles =
					new Vector3(
						easeInQuad(duration, T0 / 2, diffRotation.x / 2),
						easeInQuad(duration, T0 / 2, diffRotation.y / 2),
						easeInQuad(duration, T0 / 2, diffRotation.z / 2)
					) + initRotation;
				
				movedObject.transform.localScale =
					new Vector3(
						easeInQuad(duration, T0 / 2, diffScale.x / 2),
						easeInQuad(duration, T0 / 2, diffScale.y / 2),
						easeInQuad(duration, T0 / 2, diffScale.z / 2)
					) + initScale;
			}
			else
			{
				//だんだん遅くなる
				if (!inOutSwitch)
				{
					initPosition = movedObject.transform.position;
					initRotation = movedObject.transform.eulerAngles;
					initScale = movedObject.transform.localScale;

					diffPosition = transform.position - initPosition;
					diffRotation = transform.eulerAngles - initRotation;
					diffScale = transform.localScale - initScale;

					inOutSwitch = true;
					tempDuration = 0;
				}

				movedObject.transform.position =
					new Vector3(
						easeOutQuad(tempDuration, T0 / 2, diffPosition.x),
						easeOutQuad(tempDuration, T0 / 2, diffPosition.y),
						easeOutQuad(tempDuration, T0 / 2, diffPosition.z)
					) + initPosition;
				movedObject.transform.eulerAngles =
					new Vector3(
						easeOutQuad(tempDuration, T0 / 2, diffRotation.x),
						easeOutQuad(tempDuration, T0 / 2, diffRotation.y),
						easeOutQuad(tempDuration, T0 / 2, diffRotation.z)
					) + initRotation;
				movedObject.transform.localScale =
					new Vector3(
						easeOutQuad(tempDuration, T0 / 2, diffScale.x),
						easeOutQuad(tempDuration, T0 / 2, diffScale.y),
						easeOutQuad(tempDuration, T0 / 2, diffScale.z)
					) + initScale;
			}

			break;
		}


		/*
		 * 時間をすすめる
		 */	
		duration += Time.deltaTime;//nowTime(s)
		if (inOutSwitch)
		{
			tempDuration += Time.deltaTime; 
		}

	}
		
	/*
	 	時間に応じて、等速に移動するような関数
	 	function(時間t, 時間終了値T0, 変位終了値L0)
	 */
	float linear(float time, float T0, float L0)
	{
		float a = L0 / T0;
		return a * time;
	}


	/*
		だんだん速くなる関数
		function(時間t, 時間終了値T0, 変位終了値L0)
	*/ 
	float easeInQuad(float time, float T0, float L0)
	{
		float a = L0 / Mathf.Pow(T0, 2);
		return a * Mathf.Pow(time, 2);
	}

	/*
		だんだん遅くなる関数
		function(時間t, 時間終了値T0, 変位終了値L0)
	*/ 
	float easeOutQuad(float time, float T0, float L0)
	{
		float a = L0 / Mathf.Pow(T0, 2);
		return -a * Mathf.Pow(time - T0, 2) + L0;
	}
		
}
