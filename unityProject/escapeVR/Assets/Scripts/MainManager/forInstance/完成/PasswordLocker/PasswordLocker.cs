using UnityEngine;
using System.Collections;
using System;

public class PasswordLocker : MonoBehaviour {

	private Renderer _renderer;

	private int num1;
	private int num2;
	private int num3;
	private int num4;

	private float lightSpeed = 0.2f;

	//　光らせるキーをつけてください
	public GameObject key0;
	public GameObject key1;
	public GameObject key2;
	public GameObject key3;
	public GameObject key4;
	public GameObject key5;
	public GameObject key6;
	public GameObject key7;
	public GameObject key8;
	public GameObject key9;

	public GameObject shutter;

	// Use this for initialization
	void Start () {
		_renderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void forInstanceMotion(int actNum){	
		if (Input.GetKeyDown(KeyCode.Alpha0)) {
			PasswordKey key = key0.GetComponent<PasswordKey> ();
			key.hikaru ();
			StartCoroutine(DelayMethod(lightSpeed, () =>
				{
					key.kesu();
				}));
			push (0);
		}else if (Input.GetKeyDown(KeyCode.Alpha1)) {
			PasswordKey key = key1.GetComponent<PasswordKey> ();
			key.hikaru ();
			StartCoroutine(DelayMethod(lightSpeed, () =>
				{
					key.kesu();
				}));
			push (1);
		}else if (Input.GetKeyDown(KeyCode.Alpha2)) {
			PasswordKey key = key2.GetComponent<PasswordKey> ();
			key.hikaru ();
			StartCoroutine(DelayMethod(lightSpeed, () =>
				{
					key.kesu();
				}));
			push (2);
		}else if (Input.GetKeyDown(KeyCode.Alpha3)) {
			PasswordKey key = key3.GetComponent<PasswordKey> ();
			key.hikaru ();
			StartCoroutine(DelayMethod(lightSpeed, () =>
				{
					key.kesu();
				}));
			push (3);
		}else if (Input.GetKeyDown(KeyCode.Alpha4)) {
			PasswordKey key = key4.GetComponent<PasswordKey> ();
			key.hikaru ();
			StartCoroutine(DelayMethod(lightSpeed, () =>
				{
					key.kesu();
				}));
			push (4);
		}else if (Input.GetKeyDown(KeyCode.Alpha5)) {
			PasswordKey key = key5.GetComponent<PasswordKey> ();
			key.hikaru ();
			StartCoroutine(DelayMethod(lightSpeed, () =>
				{
					key.kesu();
				}));
			push (5);
		}else if (Input.GetKeyDown(KeyCode.Alpha6)) {
			PasswordKey key = key6.GetComponent<PasswordKey> ();
			key.hikaru ();
			StartCoroutine(DelayMethod(lightSpeed, () =>
				{
					key.kesu();
				}));
			push (6);
		}else if (Input.GetKeyDown(KeyCode.Alpha7)) {
			PasswordKey key = key7.GetComponent<PasswordKey> ();
			key.hikaru ();
			StartCoroutine(DelayMethod(lightSpeed, () =>
				{
					key.kesu();
				}));
			push (7);
		}else if (Input.GetKeyDown(KeyCode.Alpha8)) {
			PasswordKey key = key8.GetComponent<PasswordKey> ();
			key.hikaru ();
			StartCoroutine(DelayMethod(lightSpeed, () =>
				{
					key.kesu();
				}));
			push (8);
		}else if (Input.GetKeyDown(KeyCode.Alpha9)) {
			PasswordKey key = key9.GetComponent<PasswordKey> ();
			key.hikaru ();
			StartCoroutine(DelayMethod(lightSpeed, () =>
				{
					key.kesu();
				}));
			push (9);
		}
	}
		

	private void push(int num){
		num1 = num2;
		num2 = num3;
		num3 = num4;
		num4 = num;
		if (num1 == 8 && num2 == 7 && num3 == 2 && num4 == 0) {
			Shutter sh = shutter.GetComponent<Shutter> ();
			sh.forInstanceMotion (1);
		}
	}

	private IEnumerator DelayMethod(float waitTime, Action action){
		yield return new WaitForSeconds(waitTime);
		action();
	}
}
