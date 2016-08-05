using UnityEngine;
using System.Collections;
using System;

/*
 * このコンポーネントに紐付けしたゲームオブジェクトに対してイージングを行う.
 */
public class ObjectMover : MonoBehaviour
{


	public enum EasingFunction
	{
		Linear,//等速に移動(moveType0に相当)
		EaseInQuad,//だんだん速くなる(moveType3に相当)
		EaseOutQuad,//だんだん遅くなる(moveType2に相当)
		EaseInOutQuad//だんだん速くなってだんだん遅くなる(moveType1に相当)
	}

	public GameObject target;//移動する先のオブジェクトを指定
	public GameObject movedObject;
	public float T0;//移動する時間を指定
	public bool trigger;//trueでイージング発動する.イージングが終わると、falseになる.
	public EasingFunction easingFunction;//イージング関数のタイプ


	private float duration;//nowTime(s)
	private Vector3 diff;//ターゲットとの距離ベクトル
	private Vector3 initPos;//イージング前のこのゲームオブジェクトの初期位置
	private bool inOutSwitch;//InOutを行うための真ん中切り替え(falseならIn、trueならOut中)
	private float tempDuration;//InOutのOutからのduration

	// Use this for initialization
	void Start()
	{
		duration = 0;

		//ターゲットになっている座標から現在、紐付けされている座標の差をとる
		diff = target.transform.position - movedObject.transform.position;

		//現在、紐付けされている座標を初期値とする
		initPos = movedObject.transform.position;

		//Debug.Log(diff);
	}

	// Update is called once per frame
	void Update()
	{
		
		int moveType = 0;

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

		moveObject(movedObject,target.transform,moveType,T0);//velocity(1flame)
	}


	void moveObject(GameObject movedObject,Transform transform,int moveType,float T0)
	{
		/*
		 *	easingする前 
		 */
		if (!trigger)
		{
			diff = transform.position - movedObject.transform.position;
			initPos = movedObject.transform.position;
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
			return;
		}

		//Debug.Log("x:" + diff.x + "y:" + diff.y + "z:" + diff.z);
		//Debug.Log("aaaduration:" + duration + ", T0:" +  T0 + ", x:" + diff.x + ", y:" + diff.y + ", z:" + diff.z);

		switch (moveType)
		{

		//等速に移動(moveType0に相当)
		case 0:
			movedObject.transform.position =
				new Vector3(
					linear(duration, T0, diff.x),
					linear(duration, T0, diff.y),
					linear(duration, T0, diff.z)
				) + initPos;
			break;

			//だんだん速くなる(moveType3に相当)
		case 3:
			movedObject.transform.position =
				new Vector3(
					easeInQuad(duration, T0, diff.x),
					easeInQuad(duration, T0, diff.y),
					easeInQuad(duration, T0, diff.z)
				) + initPos;
			break;

			//だんだん遅くなる(moveType2に相当)
		case 2:
			movedObject.transform.position =
				new Vector3(
					easeOutQuad(duration, T0, diff.x),
					easeOutQuad(duration, T0, diff.y),
					easeOutQuad(duration, T0, diff.z)
				) + initPos;
			break;

			//だんだん速くなってだんだん遅くなる(moveType1に相当)
		case 1:


			if (duration < T0 / 2)
			{
				//だんだん速くなる
				inOutSwitch = false;
				movedObject.transform.position =
					new Vector3(
						easeInQuad(duration, T0 / 2, diff.x / 2),
						easeInQuad(duration, T0 / 2, diff.y / 2),
						easeInQuad(duration, T0 / 2, diff.z / 2)
					) + initPos;
			}
			else
			{
				//だんだん遅くなる
				if (!inOutSwitch)
				{
					diff = transform.position - movedObject.transform.position;
					initPos = movedObject.transform.position;
					inOutSwitch = true;
					tempDuration = 0;
				}

				movedObject.transform.position =
					new Vector3(
						easeOutQuad(tempDuration, T0 / 2, diff.x),
						easeOutQuad(tempDuration, T0 / 2, diff.y),
						easeOutQuad(tempDuration, T0 / 2, diff.z)
					) + initPos;

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

